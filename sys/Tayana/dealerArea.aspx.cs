using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys.Tayana
{
    public partial class dealerArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HiddenField HiddenField3 = (HiddenField)Master.FindControl("HiddenField1");
                HiddenField3.Value = "dealer";
                gridview1ListCS();
            }
        }

        protected void gridview1ListCS()
        {
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            // DROPDOWNLIST接資料庫

            string code = $"SELECT row_number() over (order by initdate asc) as RowNumber, id, country, initdate FROM  dealers";

            SqlCommand command = new SqlCommand(code, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            ////////////////////////////////////////////////////////////////////////////////////////////

            GridView1.DataSource = table;

            GridView1.DataBind();
            // 手動插入下拉式選項，需在繫結之後

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            // DROPDOWNLIST接資料庫

            string code = $"INSERT INTO dealers  (country)  VALUES  (@country)";

            SqlCommand command = new SqlCommand(code, connection);

            if (TextBox1.Text!="")
            {
                command.Parameters.Add("@country", SqlDbType.NVarChar);
                command.Parameters["@country"].Value = TextBox1.Text ?? "";
            }

            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            command.ExecuteNonQuery();

            connection.Close();

            Response.Redirect($"/sys/tayana/dealer.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                .ConnectionString;

            SqlConnection connection = new SqlConnection(strConn);

            // DROPDOWNLIST接資料庫

            string code = $"DELETE FROM dealers WHERE   (id = @id)";

            SqlCommand command = new SqlCommand(code, connection);


            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = id;

            connection.Open(); //一般而言，open 及 close 會同時打，以免忘記

            command.ExecuteNonQuery();

            connection.Close();

            Response.Redirect($"/sys/tayana/dealerarea.aspx");
        }
    }
}