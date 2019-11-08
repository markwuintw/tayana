using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using backGroundSystem_Orid.sys;
using Newtonsoft.Json;

namespace Tayana.sys
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e) //事件-滑鼠點擊 button 
        {
            if (username.Value=="") //html的input之id抓不到，因為<input>裡面沒有加  runat="server" 及 ID
            {
                Label1.Text = "username不能為空"; //網頁不會顯示，因為在前端就被JS擋下來沒有執行到這邊，可利用 中斷點 做驗證
            }

            else if (password.Value=="")
            {
                Label1.Text = "password不能為空";
            }

            //設立字串strConn，來匯入Web.config裡面的connectionStrings的login(connectionStrings的名字)的ConnectionString字串內容，可看作開啟通道的鑰匙及資訊。
            //需引用 using System.Data.SqlClient; //SQL provider
            //若資料庫安全性權限帳號是首次新增未登入過的，需先至資料庫登入並更改密碼才能成功連接
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["login"]
                .ConnectionString;


            //new一個類別為SqlConnection的通道(其名為Connection)，以 string strConn 內的登入資訊 連結到login這個資料庫。
            SqlConnection connection = new SqlConnection(strConn);

            string str_password = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Value, "MD5");


            ////建立字串Code，將SQL查詢語法放在裡面。
            ////其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
            ////記得加單引號，因為是字串格式，SQL裡面沒有雙引號而是單引號。
            //string code = $"SELECT  account, password  FROM loginList  WHERE   (account = '{username.Value}') AND (password = '{password.Value}')";

            //建立字串Code，將SQL查詢語法放在裡面。
            //其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
            string code = $"SELECT  *  FROM loginList  WHERE   (account = @account) AND (password = @password)";


            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            //參數化的慣用法，參數名稱前面加@，後面填資料格式(如整數，SqlDbType.Int)
            command.Parameters.Add("@account", SqlDbType.NVarChar);
            command.Parameters["@account"].Value = username.Value;

            command.Parameters.Add("@password", SqlDbType.NVarChar);
            command.Parameters["@password"].Value = str_password;




            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            // https://dotblogs.com.tw/mis2000lab/archive/2008/08/15/4919.aspx  DataReader與DataSet（資料集）

            SqlDataReader dataReader = command.ExecuteReader(); //dataReader讀取資料時，只能「唯讀、順向（Forward）」的動作。

            bool islogin = false;

            //if (dataReader.Read())
            //{
            //    islogin = true;
            //    Session["account"] = username.Value; //將帳號存至Session中的account
            //    Session["photo"] = dataReader["photo"]; //將帳號存至Session中的account
            //    Session["permission"] = dataReader["permission"];

            //}



            if (dataReader.Read())
            {
                islogin = true;
                login login = new login();
                login.account = username.Value;
                login.password = dataReader["password"].ToString();
                login.name = dataReader["name"].ToString();
                login.photo = dataReader["photo"].ToString();
                login.email = dataReader["email"].ToString();
                login.tel = dataReader["tel"].ToString();
                login.department = dataReader["department"].ToString();
                login.permission = dataReader["permission"].ToString();
                login.p001 = dataReader["p001"].ToString();
                login.p002 = dataReader["p002"].ToString();
                login.p003 = dataReader["p003"].ToString();

                string userData = JsonConvert.SerializeObject(login);//login物件

                SetAuthenTicket(userData, username.Value);

                
            }

            dataReader.Close();
            connection.Close();

            if (islogin)
            {
                Response.Redirect("mainPage.aspx");
            }
            else
            {
                Label1.Text = "帳號或密碼錯誤";
            }
        }
        void SetAuthenTicket(string userData, string userId) //cookies驗證 ， userData login物件反序列化成的字串， userId 登入時的account
        {
            //宣告一個驗證票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立Cookie
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //設定三小時過期
            authenticationcookie.Expires = DateTime.Now.AddHours(3);
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);

        }

    }
}