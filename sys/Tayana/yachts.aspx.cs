using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys.Tayana
{
    public partial class yachts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 寫至 MasterPage 的 Head 的 Tittle。
                Master.Page.Title = "MK後台- 遊艇型號總表";

                System.IO.Path.GetFileName(Request.PhysicalPath);
                HiddenField HiddenField1 = (HiddenField) Master.FindControl("HiddenField1");
                HiddenField1.Value = System.IO.Path.GetFileName(Request.PhysicalPath);

                showData();

            }

        }
        private void showData()
        {
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"SELECT  id, model, new, initTime FROM tayanaSummary where model!='首頁'";

            SqlCommand command = new SqlCommand(code, connection);

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            GridView1.DataSource = dataReader;
            //把這個資料表(GridView1)跟資料(reader)作雙向繫結
            GridView1.DataBind();

            connection.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"yachtsADD.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect($"yachtsPhotoAdd.aspx?id=17");
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
            string code = $"DELETE FROM tayanaSummary  WHERE   (id = {id})";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            //ExecuteNonQuery 本method直接翻譯是執行但不用回傳資料，但實際上仍有一個回傳值，會回傳一個INT(顯示受影響的資料筆數)，但一般而言並不會設變數來接。
            command.ExecuteNonQuery();

            connection.Close();

            showData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect($"yachtsUpdate.aspx?id={id}");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect($"yachtsPhotoAdd.aspx?id={id}");
        }


    }
}