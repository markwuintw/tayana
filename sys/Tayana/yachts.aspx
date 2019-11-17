<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="yachts.aspx.cs" Inherits="Tayana.sys.Tayana.yachts" %>

<%@ Register Src="~/pages.ascx" TagPrefix="uc1" TagName="pages" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="新增船型" OnClick="Button1_Click" />
            <div class="card" style="padding: 15px;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" GridLines="None" Height="381px" Width="978px" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" CssClass="table" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="編號" SortExpression="RowNumber" />

                        <asp:TemplateField HeaderText="船型">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=' <%# Eval("series").ToString()+" "+Eval("model").ToString() %> '></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

<%--                        <asp:BoundField DataField="model" HeaderText="型號" SortExpression="model" />--%>
                        <asp:BoundField DataField="new" HeaderText="新船型" SortExpression="new" />

                        <asp:TemplateField HeaderText="首頁照片">
                            <ItemTemplate>
                                <img id="Image1" runat="server" src='<%# "/upload/images/"+Eval("photo") %>' style="width: 500px; height: 300px; object-fit: cover;" />
                                <%--                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/upload/images/"+Eval("photo") %>' />--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="Button4" runat="server" CommandName="select" Text="新增圖檔" class="btn btn-primary waves-effect" />
                                <asp:Button ID="Button2" runat="server" Text="修改" CommandName="Edit" class="btn btn-primary waves-effect" />
                                <asp:Button ID="Button3" runat="server" Text="刪除" CommandName="Delete" class="btn btn-primary waves-effect" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <uc1:pages runat="server" ID="pages" />
            </div>
        </div>
    </div>
</asp:Content>
