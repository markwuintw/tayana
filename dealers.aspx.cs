using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana
{
    public partial class dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //連結經銷商頁面要顯示哪一個區域別的經銷商

                string strConn3 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                    .ConnectionString;

                SqlConnection connection3 = new SqlConnection(strConn3);

                string code3 = $"SELECT top(1) id FROM dealers order by initdate asc ";

                //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
                SqlCommand command3 = new SqlCommand(code3, connection3);

                SqlDataAdapter adapter3 = new SqlDataAdapter(command3);

                DataTable table3 = new DataTable();

                adapter3.Fill(table3);

                string idd = table3.Rows[0][0].ToString();

                string id = Request.QueryString["id"] ?? $@"{idd}";


                //int id = Convert.ToInt32(Request.QueryString["id"] == null ? $"{idd}" : Request.QueryString["id"]);

                //int id = Convert.ToInt32(Request.QueryString["id"] ?? "11");//URL沒有參數page代表在第一頁

                leftList();

                dataListCS();

                dataListCountCS(id);
            }
        }

        protected void leftList()
        {
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"SELECT *  FROM dealers order by initdate ASC";

            SqlCommand command = new SqlCommand(code, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            Repeater1.DataSource = table;

            Repeater1.DataBind();

            //int id = Convert.ToInt32(Request.QueryString["id"] == null ? "11" : Request.QueryString["id"]);

            string code1 = $"SELECT id,country  FROM dealers where id=@id";

            SqlCommand command1 = new SqlCommand(code1, connection);

            command1.Parameters.Add("@id", SqlDbType.Int);
            command1.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"] ?? "11");//URL沒有參數page代表在第一頁

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);

            DataTable table1 = new DataTable();

            adapter1.Fill(table1);

            Literal1.Text = $@"<a href=""/dealers.aspx?id={table1.Rows[0][0].ToString()}""><span class=""on1"">{table1.Rows[0][1].ToString()}</span></a>";

            Literal2.Text = table1.Rows[0][1].ToString();
        }

        protected void dataListCS()
        {
            string commandString = "WITH dealersss AS(SELECT  ROW_NUMBER() OVER(ORDER BY dealercity.initdate asc) AS RowNumber, (select country from dealers where id = dealercity.fid) as country,* FROM  dealercity WHERE   fid=@id ) select* from dealersss  where ROWNUMBER >=((@page - 1) * 5 + 1)  and ROWNUMBER <=(@page * 5)";

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            SqlCommand command3 = new SqlCommand(commandString, connection);

            command3.Parameters.Add("@id", SqlDbType.Int);
            command3.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);//URL沒有參數page代表在第一頁

            command3.Parameters.Add("@page", SqlDbType.Int);
            command3.Parameters["@page"].Value = Convert.ToInt32(Request.QueryString["page"] ?? "1");//URL沒有參數page代表在第一頁

            //command3.Parameters.Add("@id", SqlDbType.Int);
            //command3.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"] ?? "1");

            SqlDataAdapter DataAdapter3 = new SqlDataAdapter(command3);

            // create the DataSet 
            DataTable dataSet3 = new DataTable();
            // fill the DataSet using our DataAdapter 

            DataAdapter3.Fill(dataSet3);

            Repeater2.DataSource =dataSet3;

            Repeater2.DataBind();

            //Literal1.Text = $@"<a href=""/dealers.aspx?id={dataSet3.Rows[0][3].ToString()}""><span class=""on1"">{dataSet3.Rows[0][1].ToString()}</span></a>";

            //Literal2.Text = dataSet3.Rows[0][1].ToString();

        }
        protected void dataListCountCS(string id)
        {

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"SELECT COUNT(*) AS total  FROM  dealercity WHERE   fid=@id ";

            SqlCommand command = new SqlCommand(code, connection);

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);//URL沒有參數page代表在第一頁

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            int itemsCount = table.Rows.Count > 0 ? Convert.ToInt32(table.Rows[0][0].ToString()) : 0;//

            //分頁控制項丟入參數做測試

            pages.totalitems = itemsCount;//每頁數量
            pages.limit = 5;//資料總量
            pages.targetpage = $"dealers.aspx?id={id}";
            pages.showPageControls();//顯示分頁控制項 
        }

    }
}