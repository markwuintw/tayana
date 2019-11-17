<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOther.Master" AutoEventWireup="true" CodeBehind="dealers.aspx.cs" Inherits="Tayana.dealers" %>
<%@ Register TagPrefix="uc1" TagName="pages" Src="~/pages.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--遮罩-->
    <div class="bannermasks" style="height: 371px; width: 967px; position: absolute; left: 18px; top: 113px; z-index: 200; float: right;">
        <img src="/upload/images/DEALERS.jpg" alt="&quot;&quot;" width="967" height="371" />
    </div>
    <!--遮罩結束-->

    <!--------------------------------換圖開始---------------------------------------------------->

    <div class="banner" style="height: 370px;">
        <ul>
            <li>
                <img src="images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>
    </div>
    <!--------------------------------換圖結束---------------------------------------------------->
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!--------------------------------左邊選單開始---------------------------------------------------->
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <div class="left">
                <div class="left1">
                    <p><span>DEALERS</span></p>
                    <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href='<%# "/dealers.aspx?id="+Eval("id") %>'><%# Eval("country").ToString() %></a></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
            </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>

    <%--                <li><a href='dealers.aspx?id=17'>ASIA</a></li>

                <li><a href='dealers.aspx?id=39'>EUROPE</a></li>

                <li><a href='dealers.aspx?id=40'>NORTH AMERICA</a></li>

                <li><a href='dealers.aspx?id=43'>CENTRAL AMERICA</a></li>

                <li><a href='dealers.aspx?id=41'>SOUTH AMERICA</a></li>

                <li><a href='dealers.aspx?id=42'>AFRICA</a></li>

                <li><a href='dealers.aspx?id=44'>OCEANIA</a></li>--%>

    <!--------------------------------左邊選單結束---------------------------------------------------->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <!--------------------------------右邊選單開始---------------------------------------------------->
    <div id="crumb" style="top: 515px;">
        <a href="/index.aspx">Home</a> >> <a href="/dealers.aspx">Dealers </a>>><asp:Literal ID="Literal1" runat="server"></asp:Literal>
<%--        <a href="/index.aspx">Home</a> >> <a href="/dealers.aspx">Dealers </a>>> <a href="/dealers.aspx?id ="><span class="on1">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal></span></a>--%>
    </div>
    <div class="right">
        <div class="right1">
            <div class="title">
                <span>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal></span>
            </div>
            <!--------------------------------內容開始---------------------------------------------------->
            <asp:Repeater ID="Repeater2" runat="server">
                <HeaderTemplate>
                    <div class="box2_list">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="list02">
                            <ul style="display: flex">
                                <li class="list02li">
                                    <div>
                                        <img src='<%# "/sys/Tayana/images/"+Eval("photo") %>' style="border-width: 0px; height: 200px; width: 160px; object-fit: cover;" />
                                    </div>
                                </li>
                                <li class="list02li02" style="display: flex;flex-direction: column;"><span><%# Eval("city").ToString() %></span><br/>
                                    <%# Eval("content").ToString() %>
                                    <a href='' target='_blank'></a></li>
                            </ul>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                <div class="pagenumber"></div>
                </div>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:pages runat="server" id="pages" />


            <%--  <li>
                        <div class="list02">
                            <ul>
                                <li class="list02li">
                                    <div>
                                        <p>
                                            <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl01_Image1" src="upload/Images/s20190429090649.jpg" style="border-width: 0px;" />
                                        </p>
                                    </div>
                                </li>
                                <li class="list02li02"><span>Factory Representative Tayana Yachts USA</span><br />
                                    Factory Representative Tayana Yachts USA<br />
                                    Contact：Pamela Gingras<br />
                                    Address：Tayana NW LLC 2442 NW Market St PMB 274 Seattle, WA 98107<br />
                                    TEL：206-852-2920<br />
                                    E-Mail: pamela@tayananw.com
 <br />
                                    <a href='' target='_blank'></a></li>
                            </ul>
                        </div>
                    </li>

                    <li>
                        <div class="list02">
                            <ul>
                                <li class="list02li">
                                    <div>
                                        <p>
                                            <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl02_Image1" src="upload/Images/s20120402031910.jpg" style="border-width: 0px;" />
                                        </p>
                                    </div>
                                </li>
                                <li class="list02li02"><span>San Francisco</span><br />
                                    Pacific Yacht Imports<br />
                                    Contact：Mr. Neil Weinberg<br />
                                    Address：Grand Marina 2051 Grand Street# 12 Alameda, CA 94501, USA<br />
                                    TEL：(510)865-2541<br />
                                    FAX：(510)865-2369
E-Mail: tayana@mindspring.com
 <br />
                                    <a href='' target='_blank'></a></li>
                            </ul>
                        </div>
                    </li>

                    <li>
                        <div class="list02">
                            <ul>
                                <li class="list02li">
                                    <div>
                                        <p>
                                            <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl03_Image1" src="upload/Images/s20120402031803.jpg" style="border-width: 0px;" />
                                        </p>
                                    </div>
                                </li>
                                <li class="list02li02"><span>San Diego</span><br />
                                    Cabrillo Yacht sales<br />
                                    Contact：Mr. Dan Peter<br />
                                    Address：5060 N.Harbor Dr.san Diego,CA 92106<br />
                                    TEL：866-353-0409<br />
                                    FAX:(619)200-1024<br>
                                    E-Mail:danpeter@cabrilloyachtsales.com
 <br />
                                    <a href='' target='_blank'></a></li>
                            </ul>
                        </div>
                    </li>

                </ul>--%>



            <%--                <div class="pagenumber"></div>--%>



            <%--            </div>--%>

            <!--------------------------------內容結束------------------------------------------------------>
        </div>
    </div>

    <!--------------------------------右邊選單結束---------------------------------------------------->
</asp:Content>
