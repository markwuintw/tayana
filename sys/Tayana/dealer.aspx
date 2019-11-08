<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="dealer.aspx.cs" Inherits="Tayana.sys.Tayana.dealer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Button ID="Button4" class="btn btn-primary waves-effect" runat="server" Text="新增區域別" OnClick="Button1_Click"  />
            <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="新增經銷商" OnClick="Button4_Click"  />
            <div class="card" >
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting1" OnRowEditing="GridView1_RowEditing1" CssClass="table" >
                    <Columns>
                        <asp:TemplateField HeaderText="編號">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="照片">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/sys/Tayana/images/"+Eval("photo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="country" HeaderText="區域別" SortExpression="country" />
                        <asp:BoundField DataField="city" HeaderText="經銷商" SortExpression="city" />
                        <asp:BoundField DataField="content" HeaderText="內文" SortExpression="content" HtmlEncode="False"/>
                        <asp:TemplateField HeaderText="功能">

                            <ItemTemplate>
                                <asp:Button ID="Button2" runat="server" CommandName="EDIT" Text="修改" />
                                &nbsp;<asp:Button ID="Button3" runat="server" CommandName="DELETE" Text="刪除" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tayanaConnectionString %>" SelectCommand="SELECT * FROM [dealers]"></asp:SqlDataSource>

</asp:Content>
