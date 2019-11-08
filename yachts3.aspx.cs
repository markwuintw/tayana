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
    public partial class yachts3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                string strConn = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["tayanaConnectionString"]
                    .ConnectionString;

                SqlConnection connection = new SqlConnection(strConn);

                string code =
                    $"SELECT  [id], [model], [new], [CONTENT], [DIMENSIONS], [DOWNLOADS], [Layout & deck plan], [DETAIL SPECIFICATION], [Video], [initTime] FROM tayanaSummary where id =@id ";

                SqlCommand command = new SqlCommand(code, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    Literal1.Text = dataReader["model"].ToString();

                    Literal2.Text = dataReader["model"].ToString();

                    Literal3.Text +=
                        $@"<li><a class=""menu_yli01"" href=""yachts1.aspx?id={id}"">overView</a></li><li><a class=""menu_yli02"" href=""yachts2.aspx?id={id}"">Layout & deck pla</a>n</li><li><a class=""menu_yli03"" href=""yachts3.aspx?id={id}"">Specification</a></li>";

                    if (dataReader["Video"].ToString() != "")
                    {
                        Literal3.Text +=
                            $@"<li><a class=""menu_yli04"" href=""yachts4.aspx?id={id}"">Vedio</a></li>";
                    }

                    Literal4.Text = dataReader["DETAIL SPECIFICATION"].ToString();

                    //TextBox1.Text = dataReader["model"].ToString();

                    //CheckBox1.Checked = Convert.ToBoolean(dataReader["new"].ToString());

                    //editor1.Value = HttpUtility.HtmlDecode(dataReader["CONTENT"].ToString());

                    //editor2.Value = HttpUtility.HtmlDecode(dataReader["DIMENSIONS"].ToString());

                    //HyperLink1.Text = dataReader["DOWNLOADS"].ToString();

                    //HyperLink1.NavigateUrl = "/sys/Tayana/images/" + dataReader["DOWNLOADS"].ToString();

                    //editor4.Value = HttpUtility.HtmlDecode(dataReader["Layout & deck plan"].ToString());

                    //editor5.Value = HttpUtility.HtmlDecode(dataReader["DETAIL SPECIFICATION"].ToString());

                    //TextBox2.Text = dataReader["Video"].ToString();

                    connection.Close();
                }


            }
        }
    }
}