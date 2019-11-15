<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="yachtsPhotoAdd.aspx.cs" Inherits="Tayana.sys.Tayana.yachtsPhotoAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <input type="button" onclick="history.back()" value="取消" class="btn btn-primary waves-effect">
            <div class="card">
                <div class="killbutton" style="padding: 0 14px;">
                    <br>
                    <h3><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h3>
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)"></span><span id="cke_1_path_label" class="cke_voice_label"></span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>
                    <%--<ul class="ad-thumb-list" style="display: flex; flex-wrap: wrap; list-style: none">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </ul>--%>
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)"></span><span id="cke_1_path_label" class="cke_voice_label"></span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>
                    <asp:FileUpload class="form-control" ID="FileUpload2" runat="server" AllowMultiple="true"  />
                    <br>
                    <asp:Button ID="Button1" class="btn btn-primary waves-effect" runat="server" Text="確定上傳" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" class="btn btn-primary waves-effect" runat="server" Text="回上一頁" OnClick="Button2_Click" />
                    <br>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)"></span><span id="cke_1_path_label" class="cke_voice_label"></span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>
                    <span id="cke_1_bottom" class="cke_bottom cke_reset_all" role="presentation" style="user-select: none;"><span id="cke_1_resizer" class="cke_resizer cke_resizer_vertical cke_resizer_ltr" title="調整大小" onmousedown="CKEDITOR.tools.callFunction(0, event)"></span><span id="cke_1_path_label" class="cke_voice_label"></span><span id="cke_1_path" class="cke_path" role="group" aria-labelledby="cke_1_path_label"><span class="cke_path_empty">&nbsp;</span></span></span>
                    <br>
                    <div style="background-color: #DADADA; height: 20px; margin: 0 -14px;"></div>
                    <h4>目前已儲存的圖片，如下：</h4>
                    <br>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" GridLines="None" Height="381px" Width="978px" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" CssClass="table"  >
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="編號" SortExpression="RowNumber" />
                            <asp:TemplateField HeaderText="圖檔" SortExpression="photo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <img ID="Image1" runat="server" src='<%# "/upload/images/" +Eval("photo") %>' style=" width: 250px; Height:250px; object-fit: cover"/>
<%--                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/upload/images/" +Eval("photo") %>' Width="250px" Height="250px" object-fit="cover" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="photo" HeaderText="檔案名稱" SortExpression="photo" />
                            <asp:BoundField DataField="initTime" HeaderText="上傳日期" SortExpression="initTime" />
                            <asp:BoundField DataField="home" HeaderText="首頁精選" SortExpression="home" />
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    &nbsp;<asp:Button ID="Button5" runat="server" CommandName="home" Text="首頁精選" BackColor="#1f91f3" BorderColor="#1f91f3" ForeColor="white" border-radius="4px" border-style="solid" Width="76px" Height="30px" />
                                    &nbsp;<asp:Button ID="Button4" runat="server" CommandName="Delete" Text="刪除" BackColor="#1f91f3" BorderColor="#1f91f3" ForeColor="white" border-radius="4px" border-style="solid"  Width="76px" Height="30px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
