<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOther.Master" AutoEventWireup="true" CodeBehind="new_list.aspx.cs" Inherits="Tayana.new_list" %>
<%@ Import Namespace="System.Xml.Serialization" %>
<%@ Register Src="~/pages.ascx" TagPrefix="uc1" TagName="pages" %>

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
        <img src="images/banner02_masks.png" alt="&quot;&quot;" /></div>
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
                <span>NEWS</span></p>
            <ul>
                <li><a href="#">News & Events</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <!--------------------------------右邊選單開始---------------------------------------------------->
            <div id="crumb">
                <a href="index.aspx">Home</a> >> <a href="#">News </a>>> <a href="#"><span class="on1">News &
                    Events</span></a></div>
            <div class="right">
                <div class="right1">
                    <div class="title">
                        <span>News & Events</span></div>
                    <!--------------------------------內容開始---------------------------------------------------->
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <div class="box2_list">
                            <ul>
                        </HeaderTemplate>
                        <itemtemplate> 
                            <li>
                                <div class="list01">
                                    <ul>
                                        <li>
                                            <div>
                                                <p>
                                                    <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl01_Image1" src='<%# "/upload/images/news/"+Eval("mainPhoto") %>' style="border-width:0px;object-fit: cover;width: 187px;height: 121px;" /></p>
                                            </div>
                                        </li>
                                        <li><span><%# Convert.ToDateTime(Eval("initDate")).ToString("yyyy/MM/dd")%></span><br />
                                            <a href='<%# "/new_view.aspx?id="+Eval("id") %>'><%# Eval("title").ToString().Length>20?Eval("title").ToString().Substring(0,20)+"...":Eval("title").ToString() %></a></li><br/>
                                        <li><%# Eval("brief").ToString().Length>120?Eval("brief").ToString().Substring(0,120)+"...":Eval("brief").ToString() %></li>
                                            
                                    </ul>
                                </div>
                            </li>
                        </itemtemplate> 
                        <FooterTemplate>
                        </ui>

<%--                        <div class="pagenumber">
                            <div class="pagination">共<span style="color:red" >62</span>筆資料<span class="disabled">上一頁</span><span class="current">1</span><a href="new_list.aspx?page=2">2</a><a href="new_list.aspx?page=3">3</a><a href="new_list.aspx?page=4">4</a><a href="new_list.aspx?page=5">5</a><a href="new_list.aspx?page=6">6</a><a href="new_list.aspx?page=7">7</a><a href="new_list.aspx?page=2">下一頁</a></div>

                        </div>
                        
                        </div>--%>
                        </FooterTemplate>
                    </asp:Repeater>
                <uc1:pages runat="server" id="pages" />
                <%--<li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl01_Image1" src="upload/Images/s20190213042410.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2019/6/18</span><br />
                                                <a href="new_view.aspx?id=029707b3-0d52-4ebf-a251-3425831443cd">New TAYANA 54ft  under construction (keep updating)</a></li><br/>
                                                 <li>
                                                New TAYANA 54ft  under construction (keep updating)</li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl02_Image1" src="upload/Images/s20181222084915.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2018/12/22</span><br />
                                                <a href="new_view.aspx?id=12f8c3e2-f2fa-4054-8d72-d8e1d2674dc9">Merry Christmas</a></li><br/>
                                                 <li>
                                                Merry Christmas</li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl03_Image1" src="upload/Images/s20181221091618.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2018/12/21</span><br />
                                                <a href="new_view.aspx?id=99dd0c52-d8e4-43e5-a383-cdd56f60fcc2">TAYANA NEW V460 </a></li><br/>
                                                 <li>
                                                TAYANA NEW V460 </li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl04_Image1" src="upload/Images/s20181001022844.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2018/10/1</span><br />
                                                <a href="new_view.aspx?id=4006cbc7-f79e-4dad-a00c-77a0a96d3e38">TAYANA V460 Electromechanical Testing</a></li><br/>
                                                 <li>
                                                TAYANA V460 Electromechanical Testing</li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl05_Image1" src="upload/Images/s20180326040909.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2018/3/19</span><br />
                                                <a href="new_view.aspx?id=5dde0138-88b6-40bf-b159-f097e9acbf7d">2018 Taiwan INT’L Boat Show</a></li><br/>
                                                 <li>
                                                2018 Taiwan INT’L Boat Show was rounded off on March 18th</li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl06_Image1" src="upload/Images/s20180124103525.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2018/1/23</span><br />
                                                <a href="new_view.aspx?id=78eaabf3-9bcb-4024-b3ea-5813e660a6cf">New Tayana V460 yacht left tooling</a></li><br/>
                                                 <li>
                                                New Tayana V460 yacht left tooling</li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl07_Image1" src="upload/Images/s20180109082057.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2018/1/9</span><br />
                                                <a href="new_view.aspx?id=04148b52-4402-425b-b1ff-d231e88c25b7">TAYANA Yachts Club at Anping Marina, Taiwan</a></li><br/>
                                                 <li>
                                                Located on the SW coast of the island, Anping is a recently built government marina in the historic city of Tainan. </li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl08_Image1" src="upload/Images/s20170928112910.JPG" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2017/9/28</span><br />
                                                <a href="new_view.aspx?id=938885f4-b52e-450d-a74b-6ce8662d613c">TAYANA 48 "OAHANCHI" will be finished</a></li><br/>
                                                 <li>
                                                TAYANA 48 "OAHANCHI" will be finished</li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl09_Image1" src="upload/Images/s20170726032949.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2017/7/26</span><br />
                                                <a href="new_view.aspx?id=5a8eb12f-5fcb-482a-a125-b300447b760a">TAYANA 48 setting mast</a></li><br/>
                                                 <li>
                                                TAYANA 48 setting mast</li>
                                            
                                        </ul>
                                    </div>
                                </li>
                            
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                       <img id="ctl00_ContentPlaceHolder1_Repeater1_ctl10_Image1" src="upload/Images/s20170420053150.jpg" style="border-width:0px;" /></p>
                                                </div>
                                            </li>
                                            <li><span>2017/4/20</span><br />
                                                <a href="new_view.aspx?id=86bed98b-7e15-447c-aa97-5f91ed429107">Tayana V42 Vessel Delivery</a></li><br/>
                                                 <li>
                                                Tayana V42 Vessel Delivery</li>
                                            
                                        </ul>
                                    </div>
                                </li>--%>
                            
                           <%-- </ui>
                            
                        <div class="pagenumber">
                            <div class="pagination">共<span style="color:red" >62</span>筆資料<span class="disabled">上一頁</span><span class="current">1</span><a href="new_list.aspx?page=2">2</a><a href="new_list.aspx?page=3">3</a><a href="new_list.aspx?page=4">4</a><a href="new_list.aspx?page=5">5</a><a href="new_list.aspx?page=6">6</a><a href="new_list.aspx?page=7">7</a><a href="new_list.aspx?page=2">下一頁</a></div>

                        </div>
                        
                    </div>--%>
                    <!--------------------------------內容結束------------------------------------------------------>
                </div>
            </div>
            <!--------------------------------右邊選單結束---------------------------------------------------->
</asp:Content>
