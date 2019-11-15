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
    public partial class MasterPage : System.Web.UI.MasterPage
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

                Literal1.Text = $@"<li class=""menuli01""><a href=""/yachts1.aspx?id={idd}"" style=""height:70px; width:80px; display:inline-block; "">Yachts</a></li>";






                int id = Convert.ToInt32(Request.QueryString["id"]) == 0?10:Convert.ToInt32(Request.QueryString["id"]);

                Session["id"] = id;

                string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                    .ConnectionString;

                SqlConnection connection = new SqlConnection(strConn);

                //photoList 開始

                //string code = $"select* FROM tayanaPhotoList where fid=@id ORDER BY id desc";

                ////new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
                //SqlCommand command = new SqlCommand(code, connection);

                //command.Parameters.Add("@id", SqlDbType.Int);
                //command.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);

                //SqlDataAdapter adapter = new SqlDataAdapter(command);

                //DataTable table = new DataTable();

                //adapter.Fill(table);

                //leftList.Text += $@"<!--遮罩--><div class=""bannermasks""><img src = ""images/banner01_masks.png"" alt = ""&quot;&quot;"" /></div ><!--遮罩結束-->
                //    <div class=""banner""><div id = ""gallery"" class=""ad-gallery""><div class=""ad-image-wrapper"">
                //    </div><div class=""ad-controls"" style=""display: none""></div><div class=""ad-nav""><div class=""ad-thumbs""><ul class=""ad-thumb-list"">";

                //for (int i = 0; i < table.Rows.Count; i++)
                //{
                    //photoList.Text += $@"<li><a href=""/images/pit003.jpg""><img src=""/images/pit003.jpg""></a></li>";
                    //photoList.Text += $@"<li><a href=""/sys/tayana/images/{table.Rows[i][2].ToString()}""><img src=""/sys/tayana/images/{table.Rows[i][2].ToString()}""></a></li>";
                //}

                //photoList 結束

                //leftList 開始

                string code2 = $"SELECT  id, model, new, initTime, series FROM tayanaSummary ";

                //new一個類別為SqlCommand的指令(其名為Command)，而其用法為 new SqlCommand("SQL語法",通道名稱);  ，其中 SQL語法 可由精靈產生
                SqlCommand command2 = new SqlCommand(code2, connection);

                command2.Parameters.Add("@id", SqlDbType.Int);
                command2.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);

                HiddenField1.Value = @id.ToString();

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);

                DataTable table2 = new DataTable();

                adapter2.Fill(table2);



                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    if (table2.Rows[i][2].ToString()=="True")
                    {
                        leftList.Text += $@"<li><a href=""/yachts1.aspx?id={ table2.Rows[i][0].ToString()}""> {table2.Rows[i][4].ToString()} {table2.Rows[i][1].ToString()}(New Building)</a></li>";
                    }
                    else
                    {
                        leftList.Text += $@"<li><a href=""/yachts1.aspx?id={ table2.Rows[i][0].ToString()}""> {table2.Rows[i][4].ToString()} {table2.Rows[i][1].ToString()}</a></li>";
                    }
                }

                //leftList 結束

                connection.Close();
            }
        }

       
    }
}