using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys.Tayana
{
    public partial class newsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName1=""; // 要習慣先給初始值，後方才能引用
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Label1.Text = "檔案型態錯誤!";
                    return;
                }

                //取得副檔名
                string Extension = Path.GetExtension(FileUpload1.FileName);
                //string Extension = FileUpload2.FileName.Split('.')[FileUpload2.FileName.Split('.').Length - 1];

                //新檔案名稱
                fileName1 = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);

                //上傳目錄為/upload/Images/
                FileUpload1.SaveAs(Server.MapPath(String.Format("~/upload/images/news/{0}", fileName1)));

            }

            string fileName2="";
            if (FileUpload2.HasFile)
            {
                if (FileUpload2.PostedFile.ContentType.IndexOf("pdf") == -1)
                {
                    Label2.Text = "檔案型態錯誤!";
                    return;
                }

                //取得副檔名
                string Extension = Path.GetExtension(FileUpload2.FileName);
                //string Extension = FileUpload2.FileName.Split('.')[FileUpload2.FileName.Split('.').Length - 1];

                //新檔案名稱
                fileName2 = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);

                //上傳目錄為/upload/Images/
                FileUpload2.SaveAs(Server.MapPath(String.Format("~/upload/images/news/{0}", fileName2)));

            }


            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"INSERT INTO news ( [top], [mainPhoto], [title], [brief], [photoList], [addition]) VALUES( @top, @mainPhoto, @title, @brief, @photoList, @addition)";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            command.Parameters.Add("@top", SqlDbType.NVarChar);
            command.Parameters["@top"].Value = CheckBoxTop.Checked.ToString() ?? "";

            command.Parameters.Add("@mainPhoto", SqlDbType.NVarChar);
            command.Parameters["@mainPhoto"].Value = fileName1 ?? "";

            command.Parameters.Add("@title", SqlDbType.NVarChar);
            command.Parameters["@title"].Value = title .Text?? "";

            command.Parameters.Add("@brief", SqlDbType.NVarChar);
            command.Parameters["@brief"].Value = brief.Text ?? "";

            command.Parameters.Add("@photoList", SqlDbType.NVarChar);
            command.Parameters["@photoList"].Value = editor1.Value ?? "";

            command.Parameters.Add("@addition", SqlDbType.NVarChar);
            command.Parameters["@addition"].Value = fileName2;

            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

            //SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。

            command.ExecuteNonQuery();

            connection.Close();

            Response.Redirect($"/sys/tayana/news.aspx");
        }
    }
}