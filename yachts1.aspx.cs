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
    public partial class yachts1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                


                string id = Request.QueryString["id"]??$@"{idd}";

                string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                    .ConnectionString;

                SqlConnection connection = new SqlConnection(strConn);

                string code = $"SELECT  [id], [model], [series], [new], [CONTENT], [DIMENSIONS], [DOWNLOADS], [fileLocation], [Layout & deck plan], [DETAIL SPECIFICATION], [Video], [initTime] FROM tayanaSummary where id =@id ";

                SqlCommand command = new SqlCommand(code, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    Literal1.Text = dataReader["series"].ToString()+ " " + dataReader["model"].ToString();

                    Literal2.Text = dataReader["series"].ToString() + " " + dataReader["model"].ToString();

                    Literal3.Text +=$@"<li><a class=""menu_yli01"" href=""yachts1.aspx?id={id}"">overView</a></li>"+ Environment.NewLine;

                    Literal3.Text += $@"<li><a class=""menu_yli02"" href=""yachts2.aspx?id={id}"">Layout & deck pla</a>n</li>" + Environment.NewLine;

                    Literal3.Text += $@"<li><a class=""menu_yli03"" href=""yachts3.aspx?id={id}"">Specification</a></li>" + Environment.NewLine;

                    //if (dataReader["Video"].ToString() != "")
                    //{
                    //    Literal3.Text +=
                    //        $@"<li><a class=""menu_yli04"" href=""yachts4.aspx?id={id}"">Vedio</a></li>";
                    //}

                    Literal4.Text = dataReader["CONTENT"].ToString();

                    //Literal5.Text = dataReader["DIMENSIONS"].ToString();

                    if (dataReader["DIMENSIONS"].ToString() != "")
                    {
                        Literal5.Text = $@"<div class=""box3""><h4>{dataReader["model"]} DIMENSIONS</h4>{dataReader["DIMENSIONS"].ToString()}</div>";
                    }

                    if (dataReader["DOWNLOADS"].ToString()!="")
                    {
                        Literal6.Text += $@"<div class=""downloads""><p><img src=""images/downloads.gif"" alt="" & quot; &quot; "" /></p><ul><asp:Literal ID=""Literal6"" runat=""server""></asp:Literal><li><a href = ""/sys/tayana/images/{dataReader["fileLocation"].ToString()}"">{dataReader["DOWNLOADS"].ToString()}</a></li></ul></div>";
                    }



                    connection.Close();
                }

            }
        }
    }
}