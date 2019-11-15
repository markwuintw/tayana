using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys.Tayana
{
    public partial class yachtsPhotoAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id=0;
            if (!IsPostBack)
            {
                HiddenField HiddenField3 = (HiddenField)Master.FindControl("HiddenField1");
                HiddenField3.Value = "yachts";

                id = Convert.ToInt32(Request.QueryString["id"]);

                //Session["id"] = id;

                WhereAmI();

                string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                    .ConnectionString;

                SqlConnection connection = new SqlConnection(strConn);

                string code = $"with tayanaPhotoListtt as ( select ROW_NUMBER() OVER (ORDER BY tayanaPhotoList.home desc) AS RowNumber,(select model from tayanaSummary where id=tayanaPhotoList.fid )as model,* from tayanaPhotoList where fid=@id ) select * from tayanaPhotoListtt";

                //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
                SqlCommand command = new SqlCommand(code, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"] ?? "");

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                GridView1.DataSource = table;
                //把這個資料表(GridView1)跟資料(reader)作雙向繫結
                GridView1.DataBind();

                //Label2.Text = "型號： Model "+table.Rows[0][1].ToString();

                connection.Close();

                //for (int i = 0; i < table.Rows.Count; i++)
                //{
                //    Literal1.Text += $@"<li><img src = ""{table.Rows[i][2].ToString()}""></li> ";
                //}

                

            }
            
        }

        protected void WhereAmI()
        {
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"select model from tayanaSummary where id=@id ";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request.QueryString["id"];

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            Label2.Text = "型號： Model " + table.Rows[0][0].ToString();

            connection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/sys/tayana/yachts.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName="";
            if (FileUpload2.HasFile)  
            {
                for (int i = 0; i < Request.Files.Count; i++)  //http://popoplanet.blogspot.com/2017/05/cfileupload-upload-multiple-files.html
                {
                    foreach (var postedFile in FileUpload2.PostedFiles)
                    {

                        if (postedFile.ContentType.IndexOf("image") == -1)
                        {
                            Label1.Text = "檔案型態錯誤!";
                            return;
                        }

                        //取得檔名
                        string fileName0 = postedFile.FileName.Split('.')[0];

                        //取得副檔名
                        string Extension = postedFile.FileName.Split('.')[postedFile.FileName.Split('.').Length - 1];

                        //新檔案名稱
                        fileName = $"{fileName0}.{Extension}";

                        //上傳目錄為/upload/Images/
                        postedFile.SaveAs(Server.MapPath(String.Format("~/upload/images/{0}", fileName)));

                        ChangeImageSize(fileName, Server.MapPath(String.Format("~/upload/images/")), 59);
                    }
                }
            }

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);



            foreach (var postedFile in FileUpload2.PostedFiles)
            {


                string code = $"INSERT INTO tayanaPhotoList ( [fid], [photo] ) VALUES( @id, @photo )";

                //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
                SqlCommand command = new SqlCommand(code, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);

                command.Parameters.Add("@photo", SqlDbType.NVarChar);
                command.Parameters["@photo"].Value = postedFile.FileName.Split('.')[0] + "." +
                                                     postedFile.FileName.Split('.')[
                                                         postedFile.FileName.Split('.').Length - 1];

                connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

                command.ExecuteNonQuery();

                connection.Close();
            }

            
            Response.Redirect($"yachtsPhotoAdd.aspx?id={Convert.ToInt32(Request.QueryString["id"])}");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            //new一個類別為SqlConnection的通道(其名為Connection)，以 string strConn 內的登入資訊 連結到speaker這個資料庫。
            SqlConnection connection = new SqlConnection(strConn);

            //建立字串Code，將SQL查詢語法放在裡面。
            //其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
            string code = $"DELETE FROM tayanaPhotoList  WHERE   (id = {id})";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            //ExecuteNonQuery 本method直接翻譯是執行但不用回傳資料，但實際上仍有一個回傳值，會回傳一個INT(顯示受影響的資料筆數)，但一般而言並不會設變數來接。
            command.ExecuteNonQuery();

            //connection.Close();

            //string idd = Session["id"].ToString();

            Response.Redirect($"yachtsPhotoAdd.aspx?id={id}");
        }
        protected void ChangeImageSize(string FileName, string FilePath, int SmallHeight)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(FilePath + FileName);
            //絕對路徑，http://wangshifuola.blogspot.com/2011/10/aspnetimage-resize.html
            ImageFormat ThisFormat = img.RawFormat;
            int FixHeight = SmallHeight;
            int FixWidth = FixHeight * img.Width / img.Height;

            Bitmap ImgOutput = new Bitmap(img, FixWidth, FixHeight);
            ImgOutput.Save(FilePath + "s" + FileName, ThisFormat);

            img.Dispose();
            ImgOutput.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "home":
                {

               
                    Button BTN = (Button)e.CommandSource;    //先抓到這個按鈕（我們設定了CommandName）

                    GridViewRow myRow = (GridViewRow)BTN.NamingContainer;  
                    
                    //NamingContainer取得GridView的列數

                    string id1 = GridView1.DataKeys[myRow.RowIndex].Value.ToString();//抓取ID
                    string id2 = GridView1.DataKeys[myRow.RowIndex].Values["id"].ToString(); //抓取ID
                    string id3 = GridView1.DataKeys[myRow.RowIndex][0].ToString();//抓取ID

                    string keyId = GridView1.Rows[myRow.DataItemIndex].Cells[0].Text;

                    string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                        .ConnectionString;

                    SqlConnection connection = new SqlConnection(strConn);

                    string code = $" UPDATE TayanaPhotoList  SET home = 0  where fid = @id";

                    //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
                    SqlCommand command = new SqlCommand(code, connection);

                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);

                    connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

                    //ExecuteNonQuery 本method直接翻譯是執行但不用回傳資料，但實際上仍有一個回傳值，會回傳一個INT(顯示受影響的資料筆數)，但一般而言並不會設變數來接。
                    command.ExecuteNonQuery();

                    connection.Close();

                    string code2 = $" UPDATE  TayanaPhotoList  SET  home =1 where  id=@keyId";

                    //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
                    SqlCommand command2 = new SqlCommand(code2, connection);

                    command2.Parameters.Add("@keyId", SqlDbType.Int);
                    command2.Parameters["@keyId"].Value = id1;

                    connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

                    //ExecuteNonQuery 本method直接翻譯是執行但不用回傳資料，但實際上仍有一個回傳值，會回傳一個INT(顯示受影響的資料筆數)，但一般而言並不會設變數來接。
                    command2.ExecuteNonQuery();

                    connection.Close();

                    Response.Redirect($"yachtsPhotoAdd.aspx?id={Request.QueryString["id"]}");

                    break;
                }
            }
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Button BTN = (Button)e.CommandSource;

        //    string id = GridView1.SelectedIndex[e.GetHa].Value.ToString();

        //    string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
        //        .ConnectionString;

        //    //new一個類別為SqlConnection的通道(其名為Connection)，以 string strConn 內的登入資訊 連結到speaker這個資料庫。
        //    SqlConnection connection = new SqlConnection(strConn);

        //    //建立字串Code，將SQL查詢語法放在裡面。
        //    //其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
        //    string code = $"DELETE FROM tayanaPhotoList  WHERE   (id = {id})";

        //    //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
        //    SqlCommand command = new SqlCommand(code, connection);

        //    connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

        //    //ExecuteNonQuery 本method直接翻譯是執行但不用回傳資料，但實際上仍有一個回傳值，會回傳一個INT(顯示受影響的資料筆數)，但一般而言並不會設變數來接。
        //    command.ExecuteNonQuery();

        //    connection.Close();

        //    string idd = Session["id"].ToString();

        //    Response.Redirect($"yachtsPhotoAdd.aspx?id={idd}");
        //}
    }
}