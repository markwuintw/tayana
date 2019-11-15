using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tayana.sys
{
    /// <summary>
    /// checkusername 的摘要描述
    /// </summary>
    public class checkusername : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";//回傳的是文字所以用這行;ORID用Json

            string account = context.Request.QueryString["username"];

            //string account = context.Request.QueryString["username"];

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["login"].ConnectionString;

            SqlConnection getConnection = new SqlConnection(get);

            SqlCommand command = new SqlCommand($"select * from [loginList] where account=@userid  ", getConnection);

            command.Parameters.Add("@userid", SqlDbType.NVarChar);

            command.Parameters["@userid"].Value = account;

            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);

            DataTable user = new DataTable();

            loginAdapter.Fill(user);

            if (user.Rows.Count >0)
            {
                context.Response.Write("此帳號存在");
            }

            else
            {
                context.Response.Write("此帳號不存在");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}