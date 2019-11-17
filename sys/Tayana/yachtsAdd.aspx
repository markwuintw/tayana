<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="yachtsAdd.aspx.cs" Inherits="Tayana.sys.Tayana.yachtsAdd"  ValidateRequest="false" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ckeditor4/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <input type="button" onclick="history.back()" value="取消" class="btn btn-primary waves-effect">
            <div class="card" style="padding: 15px;">
                <div class="killbutton">
                    
                    <h3>0.SERIES</h3>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br/>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>

                    <h3>1.MODEL</h3>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>

                    <h3>2.NEW</h3>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text=" "  style="margin-top: 20px"/><br/>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>

                    <%--  --%>

<%--                    <h3>2.PHOTO</h3>

                    <ul class="ad-thumb-list" style="display: flex; list-style: none">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                <li>
                                    <a href="/images/top.gif">
                                        <img src="/images/top.gif">
                                    </a>
                                </li>
                                <li>
                                    <a href="/images/icon003.gif">
                                        <img src="/images/icon003.gif">
                                    </a>
                                </li>
                                <li>
                                    <a href="/images/icon003.gif">
                                        <img src="/images/icon003.gif">
                                    </a>
                                </li>
                                <li>
                                    <a href="/images/icon003.gif">
                                        <img src="/images/icon003.gif">
                                    </a>
                                </li>

                            </ul>

                    <asp:Image ID="Image1" runat="server" Height="93px" Width="151px" />
                    <asp:FileUpload  class="form-control" ID="FileUpload1" runat="server" />
                    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenFieldPho" runat="server" />
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)">◢</span><span id="cke_1_path_label" class="cke_voice_label">元件路徑</span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>--%>

                    
                    <%--  --%>

                    <h3>3.CONTENT</h3>
                    <textarea name="editor1" id="editor1" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor1', {
                            filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
                            filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?type=Images',
                            filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?type=Flash',
                            filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                            filebrowserImageUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                            filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
                        });
                    </script>

                    <h3>4.DIMENSIONS</h3>
                    <textarea name="editor2" id="editor2" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor2', {
                            filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
                            filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?type=Images',
                            filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?type=Flash',
                            filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                            filebrowserImageUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                            filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
                        });
                    </script>
                    
                    <%--  --%>

                    <h3>5.DOWNLOADS</h3>
                    <asp:FileUpload  class="form-control" ID="FileUpload2" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>
                    <%--  --%>

                    <h3>6.Layout & deck plan</h3>
                    <textarea name="editor4" id="editor4" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor4', {
                            filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
                            filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?type=Images',
                            filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?type=Flash',
                            filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                            filebrowserImageUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                            filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
                        });
                    </script>

                    <h3>7.DETAIL SPECIFICATION</h3>
                    <textarea name="editor5" id="editor5" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor5', {
                            filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
                            filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?type=Images',
                            filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?type=Flash',
                            filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                            filebrowserImageUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                            filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
                        });
                    </script>
                    <h3>8.Video</h3>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>

                </div>
                <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="確定新增" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>
