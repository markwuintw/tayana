<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="dealerAdd.aspx.cs" Inherits="Tayana.sys.Tayana.dealerAdd" ValidateRequest="false" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <input type="button" onclick="history.back()" value="取消" class="btn btn-primary waves-effect">
            <div class="card" style="padding: 15px;">
                <div class="killbutton">
                    
                    <%--  --%>

                    <h3>區域</h3>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>
                    <%--  --%>

                    <h3>經銷商</h3>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>                    
                    <%--  --%>

                    <h3>照片</h3>
                    <asp:Image ID="Image1" runat="server" />
                    <asp:FileUpload  class="FileUpload1" ID="FileUpload1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                    <%--  --%>

                    <h3>內文</h3>
                    <textarea name="editor1" id="editor1" runat="server" clientidmode="Static" htmlEscape="false"></textarea>
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
                    
                    <%--  --%>

                </div>
                <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="確定新增" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>
