<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="yachts3.aspx.cs" Inherits="Tayana.yachts3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">--%>
<%--    <!--遮罩-->
    <div class="bannermasks">
        <img src="images/banner01_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <div class="banner">
        <div id="gallery" class="ad-gallery">
            <div class="ad-image-wrapper">
            </div>
            <div class="ad-controls" style="display: none">
            </div>
            <div class="ad-nav">
                <div class="ad-thumbs">
                    <ul class="ad-thumb-list">
                        <li>
                            <a href="images/test1.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>--%>
<%--</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <%-- <div class="left">
        <div class="left1">
            <p><span>YACHTS</span></p>
            <ul>
                <li><a href="#">Dynasty 72</a></li>
                <li><a href="#">Tayana 64</a></li>
                <li><a href="#">Tayana 58</a></li>
                <li><a href="#">Tayana 55</a></li>
            </ul>
        </div>
    </div>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <!--------------------------------右邊選單開始---------------------------------------------------->
    <div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >> <a href="#"><span class="on1"><asp:Literal ID="Literal1" runat="server"></asp:Literal><%--Dynasty 72--%></span></a></div>
    <div class="right">
        <div class="right1">
            <div class="title"><span><asp:Literal ID="Literal2" runat="server"></asp:Literal><%--Dynasty 72--%></span></div>

            <!--------------------------------內容開始---------------------------------------------------->

                        <!--次選單-->
                        <div class="menu_y">
                            <ul>
                                <li class="menu_y00">YACHTS</li>
                                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                <%--<li><a class="menu_yli01" href="/yachts1.aspx">Interior</a></li>
                                <li><a class="menu_yli02" href="/yachts2.aspx">Layout & deck pla</a>n</li>
                                <li><a class="menu_yli03" href="/yachts3.aspx">Specification</a></li>--%>
                            </ul>
                        </div>
                        <!--次選單-->
                        <div class="box5">
                            <h4>DETAIL SPECIFICATION</h4>
                            <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                            <%-- <p>HULL STRUCTURE & DECKS</p>
                            <ul>
                                <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                                <li>White formica counters in hgalley. Teak veneer ctt</li>
                                <li>White formica counters in hgalley. Teak veneer c</li>
                                <li>White formica counters in hgalley. Teak veneer c</li>
                                <li>WTeak veneer ctte table 0005</li>
                                <li>WTeak veneer ctte table 0005</li>
                            </ul>

                            <p>HULL STRUCTURE & DECKS</p>
                            <ul>
                                <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                                <li>White formica counters in hgalley. Teak veneer ctt</li>
                                <li>White formica counters in hgalley. Teak veneer c</li>
                                <li>White formica counters in hgalley. Teak veneer c</li>
                                <li>WTeak veneer ctte table 0005</li>
                                <li>WTeak veneer ctte table 0005</li>
                            </ul>--%>
                        </div>
                        <div class="box5">
                            <h4>YouTube</h4>
                            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                        </div>
                        <p class="topbuttom">
                            <img src="images/top.gif" alt="top" /></p>
                        <!--------------------------------內容結束------------------------------------------------------>
                    </div>
                </div>
</asp:Content>
