using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Web.Management;


namespace Tayana
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //ctl00_ContentPlaceHolder1_Name.Value
            //ctl00_ContentPlaceHolder1_Email.Value
            //ctl00_ContentPlaceHolder1_Phone.Value
            //ctl00_ContentPlaceHolder1_Country.Value
            //ctl00_ContentPlaceHolder1_Yachts.Value
            //ctl00_ContentPlaceHolder1_Comments.Value

            StringBuilder content = new StringBuilder();
            content.AppendLine(@"<table style = ""border: solid black 1px; "" >");
            content.AppendLine($@"<tr ><th > Name :  </th ><td > {ctl00_ContentPlaceHolder1_Name.Value} </td ></tr >");
            content.AppendLine($@"<tr ><th > Email :	</th ><td > {ctl00_ContentPlaceHolder1_Email.Value} </td ></tr >");
            content.AppendLine($@"<tr ><th > Phone : </th ><td > {ctl00_ContentPlaceHolder1_Phone.Value} </td ></tr >");
            content.AppendLine($@"<tr ><th > Country : </th ><td > {ctl00_ContentPlaceHolder1_Country.Value} </td ></tr >");
            content.AppendLine($@"<tr ><th > Brochure of interest : </th ><td > {ctl00_ContentPlaceHolder1_Yachts.Value} </td ></tr >");
            content.AppendLine($@"<tr ><th > Comments: </th ><td > {ctl00_ContentPlaceHolder1_Comments.Value} </td ></tr >");
            content.AppendLine($@"</table >");

            
            //GmailTest(content);

            if (GmailTest(content).ToString()=="True")
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Email 已成功寄出');if(alert){ window.location='/contact.aspx';}</script>");
            }
            else
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Email 未能寄出，請重新確認Email是否正確，謝謝');if(alert){ window.location='/contact.aspx';}</script>");

            }

        }


        public static bool  GmailTest(StringBuilder content)

        {

            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new MailAddress("mask.mark.bra@gmail.com", "吳馬克", System.Text.Encoding.UTF8);
                /* 上面3個參數分別是發件人地址（可以隨便寫），發件人姓名，編碼*/
                mail.To.Add("markwuintw@gmail.com");//可以發送給多人
                mail.Bcc.Add("maxwuintw1989@gmail.com");//可以抄送副本給多人 
                mail.Subject = $"TayanaContact-{DateTime.Now.ToString("yyyy/M/d HH:mm:ss.fff")}";//郵件標題
                mail.SubjectEncoding = System.Text.Encoding.UTF8;//郵件標題編碼

                mail.Body = $"{content}";//郵件內容
                mail.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
                mail.IsBodyHtml = true;//是否是HTML郵件 

                //mail.Attachments.Add(new Attachment(@"D:\test2.docx"));  //附件
                mail.Priority = MailPriority.High;//郵件優先級 

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("mask.mark.bra@gmail.com", "lumia925");

                //GMAIL固定..................................................

                client.Host = "smtp.gmail.com";//設定smtp Server
                client.Port = 587;//設定Port
                client.EnableSsl = true;//配合gmail預設開啟驗證

                //GMAIL固定..................................................

                client.Send(mail);//寄出信件
                client.Dispose();//釋放記憶體
                return true;

            }
            catch 
            {
                return false;
            }

        }


        public static void SendGmailMail(string fromAddress, string toAddress, string Subject, string MailBody, string password)

        {



            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);

            mailMessage.Subject = Subject;//標題

            mailMessage.IsBodyHtml = true;//是否以HTML顯示

            mailMessage.Body = MailBody;//內文

            // SMTP Server

            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");

            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(fromAddress, password);

            mailSender.Credentials = basicAuthenticationInfo;

            mailSender.Port = 587;

            mailSender.EnableSsl = true;



            try

            {



                mailSender.Send(mailMessage);

                mailMessage.Dispose();

            }

            catch

            {

                return;

            }

            mailSender = null;

        }
    }
}