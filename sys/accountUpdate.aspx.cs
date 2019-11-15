using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys
{
    public partial class accountUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 寫至 MasterPage 的 Head 的 Tittle。
                Master.Page.Title = "MK後台- 修改帳號";

                System.IO.Path.GetFileName(Request.PhysicalPath);
                HiddenField HiddenField1 = (HiddenField)Master.FindControl("HiddenField1");
                HiddenField1.Value = System.IO.Path.GetFileName(Request.PhysicalPath);

                string id = Request.QueryString["id"];

                string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["login"]
                    .ConnectionString;

                SqlConnection connection = new SqlConnection(strConn);

                string code = $"SELECT  id, account, password, name, photo, email, tel, department, permission FROM loginList WHERE(id = {id})";

                SqlCommand command = new SqlCommand(code, connection);

                connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

                // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

                SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。



                if (dataReader.Read())
                {
                   
                    account.Text ="帳號："+ dataReader["account"].ToString();
                    //password.Text = dataReader["password"].ToString();

                    HiddenFieldPas.Value = dataReader["password"].ToString();

                    name.Text = dataReader["name"].ToString();
                    Image1.ImageUrl = dataReader["photo"].ToString();

                    HiddenFieldPho.Value = dataReader["photo"].ToString();
                    email.Text = dataReader["email"].ToString();

                    tel.Text = dataReader["tel"].ToString();
                    department.Text = dataReader["department"].ToString();

                    //dataReader["permission"].ToString()="p001,p002,p003,";
                    //a[]= {p001,p002,p003,,};
                    //a[0]="p001";
                    //a[1]="p002";
                    //a[2]="p003";
                    //a[3]=""

                    //CheckBoxList1.Items.Count=3

                    //dataReader["permission"].ToString()="p001,";
                    //a[]= {p001,,};
                    //a[0]="p001";
                    //a[1]="";

                    //CheckBoxList1.Items.Count=1

                    string[] a = dataReader["permission"].ToString().Split(',');

                    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                    {
                        int index = Array.IndexOf(a, CheckBoxList1.Items[i].Value);
                        if (index >= 0)
                        {
                            CheckBoxList1.Items[i].Selected = true;
                        }
                    }


                    permission.Text = dataReader["permission"].ToString();
                }

                dataReader.Close();
                connection.Close();

            }





        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //if (username.Value == "") //html的input之id抓不到，因為<input>裡面沒有加  runat="server" 及 ID
            //{
            //    Label1.Text = "username不能為空"; //網頁不會顯示，因為在前端就被JS擋下來沒有執行到這邊，可利用 中斷點 做驗證
            //}

            //else if (password.Value == "")
            //{
            //    Label1.Text = "password不能為空";
            //}


            string fileName;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {

                    Message.Text = "檔案型態錯誤!";
                    return;
                }

                //取得副檔名
                string Extension = FileUpload1.FileName.Split('.')[FileUpload1.FileName.Split('.').Length - 1];
                //新檔案名稱
                fileName = String.Format("images/{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                FileUpload1.SaveAs(Server.MapPath(String.Format("~/{0}", fileName)));

                
            }
            else
            {
                if (HiddenFieldPho.Value!="")
                {
                    fileName = HiddenFieldPho.Value;
                }
                else
                {
                    Message.Text = "沒有上傳檔案";
                    return;
                }
            }

            //設立字串strConn，來匯入Web.config裡面的connectionStrings的login(connectionStrings的名字)的ConnectionString字串內容，可看作開啟通道的鑰匙及資訊。
            //需引用 using System.Data.SqlClient; //SQL provider
            //若資料庫安全性權限帳號是首次新增未登入過的，需先至資料庫登入並更改密碼才能成功連接
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["login"]
                .ConnectionString;


            //new一個類別為SqlConnection的通道(其名為Connection)，以 string strConn 內的登入資訊 連結到login這個資料庫。
            SqlConnection connection = new SqlConnection(strConn);


            ////建立字串Code，將SQL查詢語法放在裡面。
            ////其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
            ////記得加單引號，因為是字串格式，SQL裡面沒有雙引號而是單引號。
            //string code = $"SELECT  account, password  FROM loginList  WHERE   (account = '{username.Value}') AND (password = '{password.Value}')";

            string id = Request.QueryString["id"];

            string save_cblJL = "";

            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)

            {

                if (this.CheckBoxList1.Items[i].Selected == true)

                {

                    save_cblJL += this.CheckBoxList1.Items[i].Value + ",";

                }

            }

            //建立字串Code，將SQL查詢語法放在裡面。
            //其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
            string code = $"Update loginList set password = @password, name = @name, photo = @photo, email = @email, tel = @tel, department = @department, permission = @permission WHERE   (id =@id)";

            string str_password = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5");


            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            //參數化的慣用法，參數名稱前面加@，後面填資料格式(如整數，SqlDbType.Int)
            //command.Parameters.Add("@account", SqlDbType.NVarChar);
            //command.Parameters["@account"].Value = account.Text;

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = id;

            if (password.Text == "")
            {
                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].Value = HiddenFieldPas.Value;
            }
            else
            {
                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].Value = str_password;
            }


            command.Parameters.Add("@name", SqlDbType.NVarChar);
            command.Parameters["@name"].Value = name.Text;

    
            command.Parameters.Add("@photo", SqlDbType.NVarChar);
            command.Parameters["@photo"].Value =  fileName;

            command.Parameters.Add("@email", SqlDbType.NVarChar);
            command.Parameters["@email"].Value = email.Text;

            command.Parameters.Add("@tel", SqlDbType.NVarChar);
            command.Parameters["@tel"].Value = tel.Text;

            command.Parameters.Add("@department", SqlDbType.NVarChar);
            command.Parameters["@department"].Value = department.Text;





            command.Parameters.Add("@permission", SqlDbType.NVarChar);
            command.Parameters["@permission"].Value = save_cblJL;



            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

            //SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。

            command.ExecuteNonQuery();

            connection.Close();

            Response.Redirect("accountManager.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("accountManager.aspx");
        }
    }
}