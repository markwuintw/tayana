<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="accountManager.aspx.cs" Inherits="Tayana.sys.accountManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="新增帳號" OnClick="Button1_Click" />
                    <div class="card">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" GridLines="None" Height="381px" Width="978px" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" CssClass="table">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="account" HeaderText="account" SortExpression="account" />
                                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                                <asp:TemplateField HeaderText="photo" SortExpression="photo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Height="131px" Width="142px" ImageUrl='<%# "/sys/" + Eval("photo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                <asp:BoundField DataField="tel" HeaderText="tel" SortExpression="tel" />
                                <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />
                                <asp:BoundField DataField="permission" HeaderText="permission" SortExpression="permission" />
                                <asp:TemplateField HeaderText="功能" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button2" class="btn btn-primary waves-effect" runat="server" Height="40px"  Text="修改" Width="81px" CommandName="Edit" />
                                        <asp:Button ID="Button3" class="btn btn-primary waves-effect" runat="server" CommandName="delete" Height="40px" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" Text="刪除" Width="81px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:login %>" SelectCommand="SELECT [id], [account], [name], [photo], [email], [tel], [department], [permission] FROM [loginList]"></asp:SqlDataSource>
</asp:Content>
