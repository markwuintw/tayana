<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tayana.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TtayanaWorld (DEMO)</title>
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cycle.all.2.74.js"></script>
    <!--[if lt IE 7]>
        <script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
    <![endif]-->
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contain">
            <div class="sub">
                <p><a href="/index.aspx">Home</a></p>
            </div>

            <!--------------------------------選單開始---------------------------------------------------->
            <div class="menu">
                <ul>
                    <li class="menuli01"><a href="/yachts1.aspx?id=10" style="height: 70px; width: 80px; display: inline-block;">Yachts</a></li>
                    <li class="menuli02"><a href="/new_list.aspx" style="height: 70px; width: 80px; display: inline-block;">>NEWS</a></li>
                    <li class="menuli03"><a href="/Company.aspx" style="height: 70px; width: 80px; display: inline-block;">>COMPANY</a></li>
                    <li class="menuli04"><a href="/dealers.aspx" style="height: 70px; width: 80px; display: inline-block;">>DEALERS</a></li>
                    <li class="menuli05"><a href="/contact.aspx" style="height: 70px; width: 80px; display: inline-block;">>CONTACT</a></li>
                </ul>
            </div>
            <!--------------------------------選單開始結束---------------------------------------------------->
            <!--遮罩-->
            <div class="bannermasks">
                <img src="images/banner00_masks.png" alt="&quot;&quot;" />
            </div>
            <!--遮罩結束-->

            <div id="abgne-block-20110111">
                <div class="bd">
                    <div class="banner">
                        <ul>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <itemtemplate>
                                <li class="info"><a href="#"><img src='<%# "/upload/images/"+Eval("photo") %>' /></a>
                                    <!--文字開始--><div class="wordtitle">TAYANA <span><%# Eval("model") %></span><br /><p>SPECIFICATION SHEET</p></div><!--文字結束-->
                                    <!--新船型開始  54型才出現其餘隱藏 -->
                                    <div class="new">
                                        <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("new")%>' />，觀察用--%>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="images/new01.png" Visible='<%# Eval("new").ToString()=="False"?false:true %>' />
                                    </div>
                                    <!--新船型結束-->
                                </li>
                            </itemtemplate>
                            </asp:Repeater>
                        </ul>
                        <!--小圖開始-->
                        <div class="bannerimg title">
                            <ul>
                                <asp:Repeater ID="Repeater2" runat="server">
                                <itemtemplate>
                                    <li class="jj">
                                        <div>
                                            <p class="bannerimg_p">
                                                <img src='<%# "/upload/images/s"+Eval("photo") %>' alt="&quot;&quot;" />
                                            </p>
                                        </div>
                                    </li>
                                </itemtemplate></asp:Repeater>
                            </ul>
                        </div>
                        <!--小圖結束-->
                    </div>
                </div>
            </div>
            <!--------------------------------換圖結束---------------------------------------------------->

            <asp:Repeater ID="Repeater3" runat="server">
                <HeaderTemplate>
                    <!--------------------------------最新消息---------------------------------------------------->
                    <div class="news">
                    <div class="newstitle">
                        <p class="newstitlep1"  style=" height: 18px;">
                            <img src="images/news.gif" alt="news" />
                        </p>
                        <p class="newstitlep2"><a href="/new_list.aspx">More>></a></p>
                    </div>
                    <ul>
                </HeaderTemplate> 
                <itemtemplate>
                    <!--TOP第一則最新消息-->
                    <li>
<%--                        <div class="news02">
                        <div class="news01">--%>
                        <div class='<%# "news0"+ (Eval("top").ToString()=="True"?1:2) %>'>
                            <!--TOP標籤-->
                            <div class="newstop" style="top: 33px;">
                                <asp:Image ID="Image2" runat="server" ImageUrl="images/new_top01.png"  Visible='<%# Eval("top").ToString()=="False"?false:true %>' />
                            </div>
                            <!--TOP標籤結束-->
                            <div class="news02p1">
                                <p class="news02p1img">
                                    <img src='<%# "/upload/images/news/"+Eval("mainPhoto") %>' alt="&quot;&quot;" style="  height: 95px; width: 95px;" />
                                </p>
                            </div>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("title").ToString()%>' />
                            <p class="news02p2"><span><%# Eval("title").ToString().Length>22?Eval("title").ToString().Substring(0,22)+"..":Eval("title").ToString() %></span> <a href='<%# "/new_view/id="+ Eval("id") %>'><%# Eval("brief").ToString().Length>110?Eval("brief").ToString().Substring(0,110)+"...":Eval("brief").ToString() %></a></p>
                        </div>
                    </li>
                    <!--TOP第一則最新消息結束-->
                </itemtemplate>
                <FooterTemplate>
                </ul>
                </div>
                <!--------------------------------最新消息結束---------------------------------------------------->
                </FooterTemplate>
            </asp:Repeater>
            <!--------------------------------落款開始---------------------------------------------------->
            <div class="footer">

                <div class="footerp00">
                    <a href="#">
                        <img src="images/tog.jpg" alt="&quot;&quot;" /></a>
                    <p class="footerp001">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
                </div>
                <div class="footer01">
                    <span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br />
                    <span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span>
                </div>
            </div>
            <!--------------------------------落款結束---------------------------------------------------->

        </div>
    </form>
<script type="text/javascript">


    $(function () {

        // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
        var $block = $('#abgne-block-20110111'),
            timrt, speed = 4000;


        // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
        var $li = $('.title ul li', $block).hover(function () {
            // 當滑鼠移上時加上 .over 樣式
            $(this).addClass('over').siblings('.over').removeClass('over');
        }, function () {
            // 當滑鼠移出時移除 .over 樣式
            $(this).removeClass('over');
        }).click(function () {
            // 當滑鼠點擊時, 顯示相對應的 div.info
            // 並加上 .on 樣式

            $(this).addClass('on').siblings('.on').removeClass('on');
            $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq($(this).index()).fadeIn(1000);
        });

        // 幫 $block 加上 hover() 事件
        $block.hover(function () {
            // 當滑鼠移上時停止計時器
            clearTimeout(timer);
        }, function () {
            // 當滑鼠移出時啟動計時器
            timer = setTimeout(move, speed);
        });

        // 控制輪播
        function move() {
            var _index = $('.title ul li.on', $block).index();
            _index = (_index + 1) % $li.length;
            $li.eq(_index).click();

            timer = setTimeout(move, speed);
        }

        // 啟動計時器
        timer = setTimeout(move, speed);

    });

    var info = document.querySelectorAll('.info');
    console.log(info);

    info[0].classList.add("on");

    var jj = document.querySelectorAll('.jj');
    console.log(info);

    jj[0].classList.add("on");

    jj[0].classList.remove("jj");

</script>
</body>
</html>
