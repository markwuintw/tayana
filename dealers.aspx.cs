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
                int id = Convert.ToInt32(Request.QueryString["id"]);

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

                Literal1.Text = table.Rows[0][1].ToString();

                Literal2.Text = table.Rows[0][1].ToString();

                dataListCS();

            }
        }

        protected void dataListCS()
        {
            string commandString = "SELECT *  FROM dealercity where fid=@id order by initdate ASC";

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

        }


    }
}