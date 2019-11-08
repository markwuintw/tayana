<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOther.Master" AutoEventWireup="true" CodeBehind="compan1.aspx.cs" Inherits="Tayana.compan1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--遮罩-->
    <div class="bannermasks" style=" height: 371px;
                                     width: 967px;
                                     position: absolute;
                                     left: 18px;
                                     top: 113px;
                                     z-index: 200;
                                     float: right; "><img src="/upload/images/company.jpg" alt="&quot;&quot;" width="967" height="371" /></div>
    <!--------------------------------換圖開始----------------------------------------------------> 

    <div class="banner">
        <ul>
            <li><img src="images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>

    </div> 
    <!--------------------------------換圖結束----------------------------------------------------> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!--------------------------------左邊選單開始----------------------------------------------------> 
    <div class="left"> 

        <div class="left1">
            <p><span>COMPANY </span></p>

            <ul>
        
                <li><a href='/company.aspx' target='_self'>About Us</a></li>
        
                <li><a href='/compan1.aspx' target='_self'>Certificat</a></li>
        
            </ul>
        

        </div>

    </div>


    <!--------------------------------左邊選單結束----------------------------------------------------> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <!--------------------------------右邊選單開始----------------------------------------------------> 
    <div id="crumb"><a href="index.aspx">Home</a> >> <a href="/company.aspx">Company  </a> >> <a href="/compan1.aspx"><span class="on1">Certificat</span></a></div>
    <div class="right"> 
        <div class="right1">
            <div class="title"> <span>Certificat</span></div>
  
            <!--------------------------------內容開始----------------------------------------------------> 
            <div class="box3">
                Tayana Yacht has the approval of ISO9001: 2000 quality certification by Bureau Veritas Certification (Taiwan) Co., Ltd in 2002. In August, 2011, formally upgraded to ISO9001: 2008. We will continue to adhere to quality-oriented, transparent and committed to delivering improvement customer satisfaction and build even stronger trusting relationships with customers.
                <br />
                <br />
 
                <div class="pit"> 
                    <ul>
                        <li><p><img src="/upload/images/certificat001.jpg" alt="Tayana " /></p></li>
                        <li><p><img src="/upload/images/certificat002.jpg" alt="Tayana " /></p></li>
                        <li><p><img src="/upload/images/certificat003.jpg" alt="Tayana " /></p></li>
                        <li><p><img src="/upload/images/certificat004.jpg" alt="Tayana " /></p></li>
                        <li><p><img src="/upload/images/certificat005.jpg" alt="Tayana " /></p></li>
                        <li><p><img src="/upload/images/certificat006.jpg" alt="Tayana " /></p></li>
                        <li>
                            <p><img src="/upload/images/certificat007.jpg" alt="Tayana " width="319" height="234" /></p></li>
                        <li>
                            <p><img src="/upload/images/certificat008.jpg" alt="Tayana " width="319" height="234" /></p></li>
                    </ul>
                </div>

            </div>




            <!--------------------------------內容結束------------------------------------------------------> 
        </div>
    </div>

    <!--------------------------------右邊選單結束----------------------------------------------------> 

</asp:Content>
