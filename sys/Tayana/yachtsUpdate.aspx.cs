using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana
{
    public partial class yachtsUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                    .ConnectionString;

                SqlConnection connection = new SqlConnection(strConn);

                string code = $"SELECT  [id], [model], [new], [CONTENT], [DIMENSIONS], [DOWNLOADS], [Layout & deck plan], [DETAIL SPECIFICATION], [Video], [initTime] FROM tayanaSummary where id =@id  ";

                SqlCommand command = new SqlCommand(code, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {

                    TextBox1.Text = dataReader["model"].ToString();

                    CheckBox1.Checked = Convert.ToBoolean(dataReader["new"].ToString());

                    editor1.Value = HttpUtility.HtmlDecode( dataReader["CONTENT"].ToString());

                    editor2.Value = HttpUtility.HtmlDecode(dataReader["DIMENSIONS"].ToString());

                    HyperLink1.Text = dataReader["DOWNLOADS"].ToString();

                    HyperLink1.NavigateUrl = "/sys/Tayana/images/" + dataReader["DOWNLOADS"].ToString();

                    editor4.Value = HttpUtility.HtmlDecode(dataReader["Layout & deck plan"].ToString());

                    editor5.Value = HttpUtility.HtmlDecode(dataReader["DETAIL SPECIFICATION"].ToString());

                    TextBox2.Text = dataReader["Video"].ToString();

                    connection.Close();
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (FileUpload2.HasFile)
            {
                string fileName;
                if (FileUpload2.PostedFile.ContentType.IndexOf("pdf") == -1)
                {

                    Label1.Text = "檔案型態錯誤!";
                    return;
                }

                //取得檔名
                string fileName0 = FileUpload2.FileName.Split('.')[0];

                //取得副檔名
                string Extension = FileUpload2.FileName.Split('.')[FileUpload2.FileName.Split('.').Length - 1];

                //新檔案名稱
                fileName = $"{fileName0}.{Extension}";

                //上傳目錄為/upload/Images/
                FileUpload2.SaveAs(Server.MapPath(String.Format("~/sys/Tayana/images/{0}", fileName)));


            }


            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"Update tayanaSummary  set [model]=@model, [new]=@new, [CONTENT]=@CONTENT, [DIMENSIONS]=@DIMENSIONS, [DOWNLOADS]=@DOWNLOADS, [Layout & deck plan]=@Layout, [DETAIL SPECIFICATION]=@DETAIL, [Video]=@Video  WHERE   (id =@id) ";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            command.Parameters.Add("@model", SqlDbType.NVarChar);
            command.Parameters["@model"].Value = TextBox1.Text ?? "";

            command.Parameters.Add("@new", SqlDbType.NVarChar);
            command.Parameters["@new"].Value = CheckBox1.Checked.ToString() ?? "";

            command.Parameters.Add("@CONTENT", SqlDbType.NVarChar);
            command.Parameters["@CONTENT"].Value = editor1.Value ?? "";

            command.Parameters.Add("@DIMENSIONS", SqlDbType.NVarChar);
            command.Parameters["@DIMENSIONS"].Value = editor2.Value ?? "";

            if (FileUpload2.HasFile)
            {
                command.Parameters.Add("@DOWNLOADS", SqlDbType.NVarChar);
                command.Parameters["@DOWNLOADS"].Value = FileUpload2.FileName.Split('.')[0] + "." +
                                                         FileUpload2.FileName.Split('.')[
                                                             FileUpload2.FileName.Split('.').Length - 1];
            }
            else
            {
                command.Parameters.Add("@DOWNLOADS", SqlDbType.NVarChar);
                command.Parameters["@DOWNLOADS"].Value = HyperLink1.Text;
            }

            command.Parameters.Add("@Layout", SqlDbType.NVarChar);
            command.Parameters["@Layout"].Value = editor4.Value ?? "";

            command.Parameters.Add("@DETAIL", SqlDbType.NVarChar);
            command.Parameters["@DETAIL"].Value = editor5.Value ?? "";

            command.Parameters.Add("@Video", SqlDbType.NVarChar);
            command.Parameters["@Video"].Value = TextBox2.Text ?? "";

            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = Request.QueryString["id"] ?? "";

            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

            //SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。

            command.ExecuteNonQuery();

            connection.Close();

            Response.Redirect($"yachts.aspx");
        }
    }
}