using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.sys
{
    public partial class mainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HiddenField HiddenField1 = (HiddenField)Master.FindControl("HiddenField1");
                HiddenField1.Value = System.IO.Path.GetFileName(Request.PhysicalPath);
            }
        }
    }
}