﻿<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="yachtsUpdate.aspx.cs" Inherits="Tayana.yachtsUpdate"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ckeditor4/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="killbutton">
                    
                    <h3>0.MODEL</h3>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/>
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)">◢</span><span id="cke_1_path_label" class="cke_voice_label">元件路徑</span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>

                    <h3 >1.NEW</h3>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text=" "  style="margin-top: 20px"/><br/>
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)">◢</span><span id="cke_1_path_label" class="cke_voice_label">元件路徑</span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>
                    <%--  --%>

                   <%-- <h3>2.PHOTO</h3>

                    <asp:Image ID="Image1" runat="server" Height="93px" Width="151px" />
                    <asp:FileUpload  class="form-control" ID="FileUpload1" runat="server" />
                    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenFieldPho" runat="server" />
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)">◢</span><span id="cke_1_path_label" class="cke_voice_label">元件路徑</span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>
                    --%><%--  --%>

                    <h3 style="display: inline-block">2.CONTENT</h3>
                    <textarea name="editor1" id="editor1" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor1', {});
                    </script>

                    <h3>3.DIMENSIONS</h3>
                    <textarea name="editor2" id="editor2" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor2', {});
                    </script>
                    
                    <%--  --%>

                    <h3>4.DOWNLOADS</h3>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text=""></asp:HyperLink>
                    <asp:FileUpload  class="form-control" ID="FileUpload2" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                    <%--  --%>

                    <h3>5.Layout & deck plan</h3>
                    <textarea name="editor4" id="editor4" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor4', {});
                    </script>
                    <h3>6.DETAIL SPECIFICATION</h3>
                    <textarea name="editor5" id="editor5" runat="server" clientidmode="Static"></textarea>
                    <script>
                        CKEDITOR.replace('editor5', {});
                    </script>
                    <h3>7.Video</h3>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)">◢</span><span id="cke_1_path_label" class="cke_voice_label">元件路徑</span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>

                </div>
                <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="確定修改" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>