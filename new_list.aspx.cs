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
    public partial class new_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                dataListCS();

                dataListCountCS();
            }
        }

        protected void dataListCS()
        {

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            //string code3 = $"SELECT  *  FROM   news   order by  [top] desc , initdate desc";
            string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("App_Code/sql/newsDataListCS.sql"));

            SqlCommand command3 = new SqlCommand(commandString, connection);

            command3.Parameters.Add("@page", SqlDbType.Int);
            command3.Parameters["@page"].Value = Convert.ToInt32(Request.QueryString["page"] ?? "1");//URL沒有參數page代表在第一頁

            SqlDataAdapter DataAdapter3 = new SqlDataAdapter(command3);

            // create the DataSet 
            DataTable dataSet3 = new DataTable();
            // fill the DataSet using our DataAdapter 

            DataAdapter3.Fill(dataSet3);

            Repeater1.DataSource = dataSet3;

            Repeater1.DataBind();
        }

        protected void dataListCountCS()
        {

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            string code = $"SELECT COUNT(*) AS total FROM news WHERE 1=1";

            SqlCommand command = new SqlCommand(code, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            int itemsCount = table.Rows.Count > 0 ? Convert.ToInt32(table.Rows[0][0].ToString()) : 0;//

            //分頁控制項丟入參數做測試

            pages.totalitems = itemsCount;//每頁數量
            pages.limit = 5;//資料總量
            pages.targetpage = "new_list.aspx";
            pages.showPageControls();//顯示分頁控制項 
        }

    }
}