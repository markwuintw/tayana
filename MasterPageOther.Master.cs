using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana
{
    public partial class MasterPageOther : System.Web.UI.MasterPage  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConn3 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection3 = new SqlConnection(strConn3);

            string code3 = $"SELECT top(1) id FROM tayanaSummary order by initTime asc ";

            //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
            SqlCommand command3 = new SqlCommand(code3, connection3);

            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);

            DataTable table3 = new DataTable();

            adapter3.Fill(table3);

            string idd = table3.Rows[0][0].ToString();

            Literal1.Text = $@"<li class=""menuli01""><a href=""/yachts1.aspx?id={idd}"" style=""height:70px; width:80px; display:inline-block; "">Yachts</a></li>";
        }
    }
}