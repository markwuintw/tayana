using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys.Tayana
{
    public partial class yachtsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HiddenField HiddenField3 = (HiddenField)Master.FindControl("HiddenField1");
                HiddenField3.Value = "yachts";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string fileName="";
            string fileNameStore = "";

            if (FileUpload2.HasFile)
            {
                if (FileUpload2.PostedFile.ContentType.IndexOf("pdf") == -1)
                {

                    Label1.Text = "檔案型態錯誤!";
                    return;
                }

                //取得檔名
                string fileName0 = FileUpload2.FileName.Split('.')[0];

                //取得副檔名
                string Extension = FileUpload2.FileName.Split('.')[FileUpload2.FileName.Split('.').Length - 1];

                //檔案名稱
                fileName = $"{fileName0}.{Extension}";

                //儲存名稱
                fileNameStore = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);

                //上傳目錄為/upload/Images/
                FileUpload2.SaveAs(Server.MapPath(String.Format("~/sys/Tayana/images/{0}" , fileNameStore)));

            }


            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"INSERT INTO tayanaSummary ( [series], [model], [new], [CONTENT], [DIMENSIONS], [DOWNLOADS], [fileLocation], [Layout & deck plan], [DETAIL SPECIFICATION], [Video]) VALUES( @series, @model, @new, @CONTENT, @DIMENSIONS, @DOWNLOADS, @fileLocation, @Layout, @DETAIL, @Video)";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            command.Parameters.Add("@series", SqlDbType.NVarChar);
            command.Parameters["@series"].Value = TextBox3.Text ?? "";

            command.Parameters.Add("@model", SqlDbType.NVarChar);
            command.Parameters["@model"].Value = TextBox1.Text ?? "";

            command.Parameters.Add("@new", SqlDbType.NVarChar);
            command.Parameters["@new"].Value = CheckBox1.Checked.ToString() ?? "";

            command.Parameters.Add("@CONTENT", SqlDbType.NVarChar);
            command.Parameters["@CONTENT"].Value = editor1.Value??"";

            command.Parameters.Add("@DIMENSIONS", SqlDbType.NVarChar);
            command.Parameters["@DIMENSIONS"].Value = editor2.Value ?? "";

            command.Parameters.Add("@DOWNLOADS", SqlDbType.NVarChar);
            command.Parameters["@DOWNLOADS"].Value = fileName;

            command.Parameters.Add("@fileLocation", SqlDbType.NVarChar);
            command.Parameters["@fileLocation"].Value = fileNameStore;

            command.Parameters.Add("@Layout", SqlDbType.NVarChar);
            command.Parameters["@Layout"].Value = editor4.Value ?? "";

            command.Parameters.Add("@DETAIL", SqlDbType.NVarChar);
            command.Parameters["@DETAIL"].Value = editor5.Value ?? "";

            command.Parameters.Add("@Video", SqlDbType.NVarChar);
            command.Parameters["@Video"].Value = TextBox2.Text ?? "";


            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

            //SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。

            command.ExecuteNonQuery();

            connection.Close();

            Response.Redirect($"yachts.aspx");
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    string fileName;
        //    if (FileUpload2.HasFile)
        //    {
        //        if (FileUpload2.PostedFile.ContentType.IndexOf("image") == -1)
        //        {

        //            Message.Text = "檔案型態錯誤!";
        //            return;
        //        }

        //        //取得檔名
        //        string fileName0 = FileUpload2.FileName.Split('.')[0];

        //        //取得副檔名
        //        string Extension = FileUpload2.FileName.Split('.')[FileUpload2.FileName.Split('.').Length - 1];

        //        //新檔案名稱
        //        fileName = $"{fileName0}.{Extension}";

        //        //上傳目錄為/upload/Images/
        //        FileUpload2.SaveAs(Server.MapPath(String.Format("~/sys/Tayana/images/{0}", fileName)));

        //    }

        //    string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
        //        .ConnectionString;

        //    SqlConnection connection = new SqlConnection(strConn);

        //    string code = $"SELECT  [id], [fid], [photo], [initTime] FROM tayanaPhotoList where fid =@id";

        //    //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
        //    SqlCommand command = new SqlCommand(code, connection);

        //    command.Parameters.Add("@id", SqlDbType.Int);
        //    command.Parameters["@id"].Value =  ;


        //    connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

        //    // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

        //    //SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。

        //    command.ExecuteNonQuery();

        //    connection.Close();

        //    Response.Redirect($"yachts.aspx");


        //}
    }
}