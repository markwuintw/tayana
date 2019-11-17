<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="dealerArea.aspx.cs" Inherits="Tayana.sys.Tayana.dealerArea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <input type="button" onclick="history.back()" value="取消" class="btn btn-primary waves-effect">
            <div class="card" style="padding: 15px;">
                <div class="killbutton">
                    
                    <%--  --%>

                    <h3>新增區域別</h3>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="確定新增" OnClick="Button1_Click" />
                    <br>
                    <div style="background-color: #E9E9E9;margin: 15px -15px 0 -15px;display: block;width: auto;">&nbsp;</div>                    
                    <%--  --%>

                    <h3>目前經銷區域總表</h3>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" CssClass="table" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="rownumber" HeaderText="編號" InsertVisible="False" ReadOnly="True" SortExpression="rownumber" />
                            <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                            <asp:BoundField DataField="initdate" HeaderText="initdate" SortExpression="initdate" />
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="Button2" runat="server" CommandName="DELETE" Text="刪除" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <%--  --%>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
