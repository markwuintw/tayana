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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                    .ConnectionString;

                SqlConnection connection = new SqlConnection(strConn);

                string code = $"SELECT  tayanaSummary.*,(select TOP(1) photo from TayanaPhotoList WHERE fid=tayanaSummary.id and (home = 1)) as photo FROM    tayanaSummary ";

                SqlCommand command = new SqlCommand(code, connection);

                SqlDataAdapter DataAdapter = new SqlDataAdapter(command);

                // create the DataSet 
                DataTable dataSet = new DataTable();
                // fill the DataSet using our DataAdapter 

                DataAdapter.Fill(dataSet);

                //if (dataSet.Rows[0]["new"].ToString()=="True")
                //{
                //    Literal1.Text = @"<div class=""new""><img src = ""images/new01.png"" alt = ""new"" /></ div >";
                //}

                Repeater1.DataSource = dataSet;
                
                Repeater1.DataBind();

                Repeater2.DataSource = dataSet;
                
                Repeater2.DataBind();


                string code3 = $"SELECT top(3) *  FROM   news   order by  [top] desc , initdate desc";

                SqlCommand command3 = new SqlCommand(code3, connection);

                SqlDataAdapter DataAdapter3 = new SqlDataAdapter(command3);

                // create the DataSet 
                DataTable dataSet3 = new DataTable();
                // fill the DataSet using our DataAdapter 

                DataAdapter3.Fill(dataSet3);

                Repeater3.DataSource = dataSet3;

                Repeater3.DataBind();
            }
        }
    }
}