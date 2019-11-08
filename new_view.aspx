<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOther.Master" AutoEventWireup="true" CodeBehind="new_view.aspx.cs" Inherits="Tayana.new_view" %>

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
                                     float: right; ">
        <img src="images/banner02_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->
    <!--------------------------------換圖開始---------------------------------------------------->
    <div class="banner">
        <ul>
            <li>
                <img src="images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>
    </div>
    <!--------------------------------換圖結束---------------------------------------------------->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="left">
        <div class="left1">
            <p>
                <span>NEWS</span>
            </p>
            <ul>
                <li><a href="#">News & Events</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <!--------------------------------右邊選單開始---------------------------------------------------->
    <div id="crumb"><a href="index.aspx">Home</a> >> <a href="#">News </a>>> <a href="#"><span class="on1">News & Events</span></a></div>
    <div class="right">
        <div class="right1">
            <div class="title"><span>News & Events</span></div>

            <!--------------------------------內容開始---------------------------------------------------->
            <div class="box3">
                <h4><span id="ctl00_ContentPlaceHolder1_title">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></span></h4>
                
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                <div>
                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                </div>
                <%--<p>
                    <img alt="" src="/upload/images/IMG_9088.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9085.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9091.jpg" style="width: 700px; height: 933px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9168(1).jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9169.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9167.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9171.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9172.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9246.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/IMG_9247.jpg" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/DSCN0224.JPG" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/DSCN0225.JPG" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/DSCN0227.JPG" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/DSCN0233.JPG" style="width: 700px; height: 525px;" />
                </p>
                <p>
                    <img alt="" src="/upload/images/DSCN0234.JPG" style="width: 700px; height: 525px;" />
                </p>--%>

            </div>

            <!--下載開始-->

            <!--下載結束-->

            <div class="buttom001"><a href="javascript:window.history.back();">
                <img src="images/back.gif" alt="&quot;&quot;" width="55" height="28" /></a></div>

            <!--------------------------------內容結束------------------------------------------------------>
        </div>
    </div>

    <!--------------------------------右邊選單結束---------------------------------------------------->
</asp:Content>
