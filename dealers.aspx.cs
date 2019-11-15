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
                int id = Convert.ToInt32(Request.QueryString["id"] == null ? "11" : Request.QueryString["id"]);

                //int id = Convert.ToInt32(Request.QueryString["id"] ?? "11");//URL沒有參數page代表在第一頁

                leftList();

                dataListCS();

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
            string commandString = "WITH dealersss AS(SELECT  ROW_NUMBER() OVER(ORDER BY dealercity.initdate asc) AS RowNumber, (select country from dealers where id = dealercity.fid) as country,* FROM  dealercity WHERE   fid=@id ) select* from dealersss ";

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            SqlCommand command3 = new SqlCommand(commandString, connection);

            command3.Parameters.Add("@id", SqlDbType.Int);
            command3.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"] ?? "11");//URL沒有參數page代表在第一頁

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


    }
}