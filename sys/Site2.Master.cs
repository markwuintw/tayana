using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using backGroundSystem_Orid.sys;
using Newtonsoft.Json;

namespace Tayana.sys
{
    public partial class Site2 : System.Web.UI.MasterPage
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

                Literal1.Text = $@"<a href=""/yachts1.aspx?id={idd}"" class=""waves-effect waves-block"">Yachts</a>";



                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("index.aspx");

                }

                string str_userData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                login myperson = JsonConvert.DeserializeObject<login>(str_userData);



                account.Text = HttpContext.Current.User.Identity.Name;//顯示名稱
                accountPhoto.Attributes["src"] = "/sys/" + myperson.photo;





                //if (Session["account"] != null)
                //{
                //    account.Text = Session["account"].ToString();
                //    accountPhoto.Attributes["src"] = Session["photo"].ToString(); //id.Attributes["src"]


                //}
                //else
                //{
                //    Response.Redirect("index.aspx");
                //}


                //string[] a = Session["permission"].ToString().Split(',');


                //...................................................................................................................


                //權限
                string[] a = myperson.permission.ToString().Split(',');

                string p001 = "p001"; //a[0]
                string p002 = "p002"; //a[1]
                string p003 = "p003"; //a[2]

                int indexA1 = Array.IndexOf(a, p001);
                int indexA2 = Array.IndexOf(a, p002);
                int indexA3 = Array.IndexOf(a, p003); //尚未用到


                //...................................................................................................................


                //所在頁面
                int[] b = new int[4];
                //int HF=0;


                if (HiddenField1.Value == "accountADD.aspx" || HiddenField1.Value == "accountUpdate.aspx" || HiddenField1.Value == "accountManager.aspx")
                {
                    b[0] = 999;
                }

                if ( HiddenField1.Value == "yachts")
                {
                    b[1] = 888;
                }

                if ( HiddenField1.Value == "news")
                {
                    b[2] = 777;
                }

                if ( HiddenField1.Value == "dealer")
                {
                    b[3] = 666;
                }

                int indexB1 = Array.IndexOf(b, 999);
                int indexB2 = Array.IndexOf(b, 888);
                int indexB3 = Array.IndexOf(b, 777);
                int indexB4 = Array.IndexOf(b, 666);



                //...................................................................................................................



                if (indexA1 >= 0)
                {
                    if (indexB1 >= 0)
                    {
                        pMenu.Text += @"<li class=""active"">
                        <a href = ""/sys/accountManager.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">supervisor_account</i>
                        <span>帳號管理-p001</span>
                        </a>
                        </li>";
                    }
                    else
                    {
                        pMenu.Text += @"<li>
                        <a href = ""/sys/accountManager.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">supervisor_account</i>
                        <span>帳號管理-p001</span>
                        </a>
                        </li>";
                    }
                }

                if (indexA2 >= 0)
                {
                    if (indexB2 >= 0)
                    {
                        pMenu.Text += @"<li class=""active"">
                        <a href = ""/sys/Tayana/yachts.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">poll</i>
                        <span>Tayana-p002</span>
                        </a>
                        </li>";
                    }
                    else
                    {
                        pMenu.Text += @"<li>
                        <a href = ""/sys/Tayana/yachts.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">poll</i>
                        <span>Tayana-p002</span>
                        </a>
                        </li>";
                    }

                    if (indexB3 >= 0)
                    {
                        pMenu.Text += @"<li class=""active"">
                        <a href = ""/sys/Tayana/news.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">poll</i>
                        <span>最新消息</span>
                        </a>
                        </li>";
                    }
                    else
                    {
                        pMenu.Text += @"<li>
                        <a href = ""/sys/Tayana/news.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">poll</i>
                        <span>最新消息</span>
                        </a>
                        </li>";
                    }

                    if (indexB4 >= 0)
                    {
                        pMenu.Text += @"<li class=""active"">
                        <a href = ""/sys/Tayana/dealer.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">poll</i>
                        <span>經銷商</span>
                        </a>
                        </li>";
                    }
                    else
                    {
                        pMenu.Text += @"<li>
                        <a href = ""/sys/Tayana/dealer.aspx"" class=""toggled waves-effect waves-block"">
                        <i class=""material-icons"">poll</i>
                        <span>經銷商</span>
                        </a>
                        </li>";
                    }
                }





                //pMenu.Text += @"<li>
                //        <a href = ""/sys/Tayana/news.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">poll</i>
                //        <span>最新消息</span>
                //        </a>
                //        </li>";

                //pMenu.Text += @"<li>
                //        <a href = ""/sys/Tayana/dealer.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">poll</i>
                //        <span>經銷商</span>
                //        </a>
                //        </li>";

                //pMenu.Text += @"<li><a href=""javascript: void(0);""class=""menu - toggle waves - effect waves - block""><i class=""material-icons"">swap_calls</i><span>User Interface(UI)</span></a>
                //    <ul class=""ml-menu""><li><a href = ""pages/ui/alerts.html"" class="" waves-effect waves-block"">Alerts</a></li><li><a href = ""pages/ui/animations.html"" class="" waves-effect waves-block"">Animations</a>
                //    </li><li><a href = ""pages/ui/badges.html"" class="" waves-effect waves-block"">Badges</a></li><li><a href = ""pages/ui/breadcrumbs.html"" class="" waves-effect waves-block"">Breadcrumbs</a>
                //    </li></ul></li>";


                //pMenu.Text += @"<li>
                //        <a href = ""/company.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">poll</i>
                //        <span>Company</span>
                //        </a>
                //        </li>";

                //pMenu.Text += @"<li>
                //        <a href = ""/dealers.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">poll</i>
                //        <span>Dealer</span>
                //        </a>
                //        </li>";

                //pMenu.Text += @"<li>
                //        <a href = ""/contact.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">poll</i>
                //        <span>Contact</span>
                //        </a>
                //        </li>";



                //if (indexA1 >= 0 & indexA2 >= 0 )
                //{
                //    if (indexB1 >= 0)
                //    {
                //        pMenu.Text += @"<li class=""active"">
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p001</span>
                //        </a>
                //        </li>";

                //        pMenu.Text += @"<li>
                //        <a href = ""oridMainPage.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>ORID系統-p002</span>
                //        </a>
                //        </li>";
                //    }
                //    else if(indexB2 >= 0)
                //    {
                //        pMenu.Text += @"<li>
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p001</span>
                //        </a>
                //        </li>";

                //        pMenu.Text += @"<li class=""active"">
                //        <a href = ""oridMainPage.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>ORID系統-p002</span>
                //        </a>
                //        </li>";
                //    }
                //    else
                //    {
                //        pMenu.Text += @"<li>
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p001</span>
                //        </a>
                //        </li>";

                //        pMenu.Text += @"<li>
                //        <a href = ""oridMainPage.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>ORID系統-p002</span>
                //        </a>
                //        </li>";
                //    }
                //}
                //else if (indexA1 >= 0 & indexA2 < 0)
                //{
                //    if (indexB1 >= 0)
                //    {
                //        pMenu.Text += @"<li class=""active"">
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p001</span>
                //        </a>
                //        </li>";
                //    }
                //    else
                //    {
                //        pMenu.Text += @"<li>
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p001</span>
                //        </a>
                //        </li>";
                //    }
                //}
                //else if (indexA1 < 0 & indexA2 >= 0)
                //{
                //    if (indexB2 >= 0)
                //    {
                //        pMenu.Text += @"<li class=""active"">
                //        <a href = ""oridMainPage.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>ORID系統-p002</span>
                //        </a>
                //        </li>";
                //    }
                //    else
                //    {
                //        pMenu.Text += @"<li>
                //        <a href = ""oridMainPage.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>ORID系統-p002</span>
                //        </a>
                //        </li>";
                //    }
                //}











                //if (indexA1 >= 0)
                //{
                //    if ( HF == 999)
                //    {
                //        pMenu.Text += @"<li class=""active"">
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p001</span>
                //        </a>
                //        </li>";
                //    }
                //    else
                //    {
                //        pMenu.Text += @"<li>
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p001</span>
                //        </a>
                //        </li>";
                //    }

                //}

                //int index2 = Array.IndexOf(a, p002);
                //if (index2 >= 0)
                //{
                //    if (HF == 999)
                //    {
                //        pMenu.Text += @"<li class=""active"">
                //        <a href = ""oridMainPage.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>ORID系統-p002</span>
                //        </a>
                //        </li>";
                //    }
                //    else
                //    {
                //        pMenu.Text += @"<li>
                //        <a href = ""oridMainPage.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>ORID系統-p002</span>
                //        </a>
                //        </li>"; 
                //    }
                //}

                //int index3 = Array.IndexOf(a, p003);
                //if (index3 >= 0)
                //{
                //    if (HF == 999)
                //    {
                //        pMenu.Text += @"<li class=""active"">
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p003</span>
                //        </a>
                //        </li>";
                //    }
                //    else
                //    {
                //        pMenu.Text += @"<li>
                //        <a href = ""accountManager.aspx"" class=""toggled waves-effect waves-block"">
                //        <i class=""material-icons"">supervisor_account</i>
                //        <span>帳號管理-p003</span>
                //        </a>
                //        </li>";
                //    }
                //}
            }
        }
    }
}