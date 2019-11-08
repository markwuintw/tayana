<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Tayana.sys.Tayana.news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="新增最新消息" OnClick="Button1_Click"  />
            <div class="card">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" CssClass="table">
                    <Columns>
                        <asp:TemplateField HeaderText="置頂" SortExpression="top">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("top") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("top") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="initDate" HeaderText="發表日期" SortExpression="initDate" />
                        <asp:TemplateField HeaderText="封面照片" SortExpression="mainPhoto">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("mainPhoto") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="127px" ImageUrl='<%# "/upload/images/news/" +Eval("mainphoto") %>' Width="158px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="title" HeaderText="標題" SortExpression="title" />
                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" CommandName="EDIT" Text="修改" />
                                <asp:Button ID="Button2" runat="server" CommandName="DELETE" Text="刪除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tayanaConnectionString %>" SelectCommand="SELECT * FROM [news]"></asp:SqlDataSource>
</asp:Content>
