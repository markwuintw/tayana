using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys.Tayana
{
    public partial class dealerAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDownListCS();

            }
        }
        protected void dropDownListCS()
        {
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            // DROPDOWNLIST接資料庫

            string code = $"SELECT * FROM  dealers";

            SqlCommand command = new SqlCommand(code, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            ////////////////////////////////////////////////////////////////////////////////////////////

            DropDownList1.DataSource = table;

            DropDownList1.DataTextField = "country";  //在此輸入的是資料表的欄位名稱，選項名稱

            DropDownList1.DataValueField = "id"; //在此輸入的是資料表的欄位名稱，實際值

            DropDownList1.DataBind(); //上方兩行要加

            // 手動插入下拉式選項，需在繫結之後

            ListItem item = new ListItem("選擇區域", "");

            DropDownList1.Items.Insert(0, item); //位置0最前面
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (FileUpload1.HasFile)
            {
                
                if (FileUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {

                    Label1.Text = "檔案型態錯誤!";
                    return;
                }

                //取得副檔名
                string Extension = FileUpload1.FileName.Split('.')[FileUpload1.FileName.Split('.').Length - 1];

                //新檔案名稱
                fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);

                //上傳目錄為/upload/Images/
                FileUpload1.SaveAs(Server.MapPath(String.Format("~/sys/Tayana/images/{0}", fileName)));

            }


            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            // DROPDOWNLIST接資料庫

            string code = $"INSERT INTO dealerCity (fid, city, photo, [content]) VALUES(@id, @city, @photo, @Content)";

            SqlCommand command = new SqlCommand(code, connection);

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = DropDownList1.SelectedValue ?? "";

            command.Parameters.Add("@city", SqlDbType.NVarChar);
            command.Parameters["@city"].Value = TextBox1.Text ?? "";

            if (FileUpload1.HasFile)
            {
                command.Parameters.Add("@photo", SqlDbType.NVarChar);
                command.Parameters["@photo"].Value = fileName; ;
            }
            

            command.Parameters.Add("@Content", SqlDbType.NVarChar);
            command.Parameters["@Content"].Value = editor1.Value ?? "";


            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

            //SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。

            command.ExecuteNonQuery();

            connection.Close();

            Response.Redirect($"/sys/tayana/dealer.aspx");

        }
    }
}