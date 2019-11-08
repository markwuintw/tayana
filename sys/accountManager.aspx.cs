using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys
{
    public partial class accountManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 寫至 MasterPage 的 Head 的 Tittle。
                Master.Page.Title = "MK後台- 帳號總覽";

                
                 HiddenField HiddenField1 = (HiddenField) Master.FindControl("HiddenField1");
                 HiddenField1.Value = System.IO.Path.GetFileName(Request.PhysicalPath);

                 showData2();
            }
        }
        private void showData()
        {
            //設立字串strConn，來匯入Web.config裡面的connectionStrings的speaker(名字)的ConnectionString字串內容，可看作開啟通道的鑰匙及資訊。
            //需引用 using System.Data.SqlClient; //SQL provider
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["login"].ConnectionString;

            //new一個類別為SqlConnection的通道(其名為Connection)，以 string strConn 內的登入資訊 連結到login這個資料庫。
            SqlConnection connection = new SqlConnection(strConn);

            //建立字串Code，將SQL查詢語法放在裡面。
            //其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
            //比較特別的是，使用到子查詢概念，主要能分成下方兩種。
            //1. SELECT "欄位1" FROM "表格"  WHERE "欄位2"[比較運算素]  (SELECT "欄位1" FROM "表格" WHERE "條件");
            //2. SELECT "欄位1",(SELECT "限制欄位SUM/COUNT..." FROM "表格" WHERE "條件") FROM "表格"  WHERE "欄位2" ;
            SqlCommand command = new SqlCommand(@"SELECT  loginList.* FROM loginList  ORDER BY id", connection);

            connection.Open();

            //DataReader是"連線資料"，其內容為指標，指向的是資料表會從第0個ROW開始，是名叫一個 BOF 的地方 begin of file
            //ExecuteReader 如果在SqlCommand物件中使用(本例的command)，則返回SqlDataReader物件。
            /*可以通過這個物件來檢查查詢結果，它提供了“游水”式的執行方式，即從結果中讀取一行之後，移動到另一行，則前一行就無法再用。
             有一點要注意的是執行之後，要等到手動去呼叫Read()方法之後，DataReader物件才會移動到結果集的第一行，
             同時此方法也返回一個Bool值，表明下一行是否可用，返回True則可用，返回False則到達結果集末尾。*/
            //https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/269327/
            SqlDataReader dataReader = command.ExecuteReader();

            //GridView1是GridView的ID，reader的指標不管是用 BIND 或是 READ 都會把指標移動
            GridView1.DataSource = dataReader;
            //把這個資料表(GridView1)跟資料(reader)作雙向繫結
            GridView1.DataBind();

            connection.Close();

        }
        private void showData2()
        {
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["login"].ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            //使用"離線資料庫"，

            SqlDataAdapter dataAdapter = new SqlDataAdapter(@"SELECT  loginList.* FROM loginList  ORDER BY id", connection);

            //SqlCommand command = new SqlCommand(@"SELECT  留言板.*,(select COUNT(*) from [回覆] where pid =[留言板].id) as 回覆 FROM 留言板  ORDER BY 發表日期 DESC", connection);
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);


            ////DataSet和DataTable二擇一即可，通常只用DataTable抓要用的資料表而已，方便後續呼叫
            //DataSet dataSet = new DataSet();
            //dataAdapter.Fill(dataSet, "資料表名字");//自動作OPEN，塞完資料，再自動作CLOSE
            //GridView1.DataSource = dataSet;

            ////DataSet和DataTable二擇一即可，通常只用DataTable抓要用的資料表而已，方便後續呼叫
            //DataTable dataTable = new DataTable();
            //dataAdapter.Fill(dataTable);//自動作OPEN，塞完資料，再自動作CLOSE
            //GridView1.DataSource = dataTable;

            //DataSet和DataTable二擇一即可，通常只用DataTable抓要用的資料表而已，方便後續呼叫
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);//自動作OPEN，塞完資料，再自動作CLOSE

            ////新增一個欄位，應用如購物車
            //dataTable.Columns.Add("編號", typeof(string));

            ////建立全新一筆資料，所以全部欄位都要給他
            //DataRow newRow = dataTable.NewRow();
            //newRow["id"] = 999;
            //newRow["id"] = 999;
            //newRow["id"] = 999;
            //newRow["id"] = 999;
            //newRow["id"] = 999;
            //dataTable.Rows.Add(newRow);

            ////移除第四筆
            //dataTable.Rows.Remove(dataTable.Rows[3]);

            ////修改資料-1 (跑完全部資料，效率差)
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    if (row["欄位名稱"].ToString() == "搜尋條件內容")
            //    {
            //        row["欄位名稱"] = "欲修改的內容";
            //    }
            //}

            ////修改資料- 2 ，重點在[]，搜尋出來的結果，因為電腦不知道會有幾個所以是陣列
            //DataRow[] rows = dataTable.Select("欄位名稱 = '搜尋條件內容'");
            //if (rows.Length > 0)
            //{
            //    rows[0]["欄位名稱"] = "欲修改的內容";
            //}


            GridView1.DataSource = dataTable;
            GridView1.DataBind();


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["login"]
                .ConnectionString;

            //new一個類別為SqlConnection的通道(其名為Connection)，以 string strConn 內的登入資訊 連結到speaker這個資料庫。
            SqlConnection connection = new SqlConnection(strConn);

            //建立字串Code，將SQL查詢語法放在裡面。
            //其中，可藉由內建精靈方式自動生成程式碼，點選資料庫-新增查詢-右鍵-在編輯器中設計查詢-進行勾選-完成即可生成SQL查詢語法程式碼。
            string code = $"DELETE FROM loginList  WHERE   (id = {id})";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command = new SqlCommand(code, connection);

            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            //ExecuteNonQuery 本method直接翻譯是執行但不用回傳資料，但實際上仍有一個回傳值，會回傳一個INT(顯示受影響的資料筆數)，但一般而言並不會設變數來接。
            command.ExecuteNonQuery();

            connection.Close();

            showData2();

        }



        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect($"accountUpdate.aspx?id={id}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"accountADD.aspx");
        }
    }
    
}