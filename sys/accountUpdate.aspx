<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="accountUpdate.aspx.cs" Inherits="Tayana.sys.accountUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
            <div class="block-header">
                <h2>
                    修改帳號
<%--                    <small>Taken from <a href="https://jqueryvalidation.org/" target="_blank">jqueryvalidation.org</a></small>--%>
                </h2>
            </div>
            <!-- Basic Validation -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card" style="padding: 15px;">
                        <%--<div class="header">
                            <h2>帳號資訊</h2>
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Action</a></li>
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Another action</a></li>
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>--%>
                        <div class="body">
                            </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:HiddenField ID="hidID" runat="server" />
<%--                                        <asp:TextBox ID="account" class="form-control" name="account" required="" aria-required="true" runat="server"></asp:TextBox>--%>
                                        <asp:Label ID="account" class="form-control" runat="server" Text="Label" Font-Bold="True" Font-Size="20px"></asp:Label>
                      <%--                  <input type="text" class="form-control" name="account" required="" aria-required="true" runat="server">--%>
                                        <%--<label class="form-label">Account</label>--%>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox ID="password" class="form-control" name="password"  runat="server"  TextMode="Password" ClientIDMode="Static" ></asp:TextBox>
<%--                                        <input type="text" class="form-control" name="password" required="" aria-required="true">--%>
                                        <label class="form-label">Password</label>
                                        <asp:HiddenField ID="HiddenFieldPas" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox  class="form-control" name="password_confirm"  type="password" id="password_confirm" oninput="check(this)"  runat="server" TextMode="Password"></asp:TextBox>
                                        <script language='javascript' type='text/javascript'>
                                            function check(input) {
                                                if (input.value != document.getElementById('password').value) {
                                                    input.setCustomValidity('Password Must be Matching.');
                                                } else {
                                                    // input is valid -- reset the error message
                                                    input.setCustomValidity('');
                                                }
                                            }
                                        </script>
                                        <label class="form-label">password_confirm</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox ID="name" class="form-control" name="name" required="" aria-required="true" runat="server"></asp:TextBox>
                                        <%--<input type="text" class="form-control" name="name" required="" aria-required="true">--%>
                                        <label class="form-label">Name</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:Image ID="Image1" runat="server" Height="93px" Width="151px" />
                                        <asp:FileUpload  class="form-control" ID="FileUpload1" runat="server" />
                                        <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="HiddenFieldPho" runat="server" />
                <%--                        <asp:TextBox ID="photo" class="form-control" name="photo" required="" aria-required="true" runat="server"></asp:TextBox>--%>

                                        <%--<input type="text" class="form-control" name="name" required="" aria-required="true">--%>
                                        <label class="form-label">Photo</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox ID="email" class="form-control" name="email" required="" aria-required="true" runat="server"></asp:TextBox>

                                       <%-- <input type="text" class="form-control" name="email" required="" aria-required="true">--%>
                                        <label class="form-label">Email</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox ID="tel" class="form-control" name="tel" required="" aria-required="true" runat="server"></asp:TextBox>

                                   <%--     <input type="text" class="form-control" name="tel" required="" aria-required="true">--%>
                                        <label class="form-label">Tel</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox ID="department" class="form-control" name="department" required="" aria-required="true" runat="server"></asp:TextBox>

                                <%--        <input type="text" class="form-control" name="department" required="" aria-required="true">--%>
                                        <label class="form-label">Department</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:CheckBoxList ID="CheckBoxList1" RepeatDirection="Horizontal" runat="server">
                                            <asp:ListItem Text="帳號管理" Value="p001"></asp:ListItem>
                                            <asp:ListItem Text="ORID系統" Value="p002"></asp:ListItem>
                                            <asp:ListItem Text="其他" Value="p003"></asp:ListItem>
                                        </asp:CheckBoxList>
                                        <asp:TextBox ID="permission" class="form-control" name="permission"  runat="server"></asp:TextBox>
                                        <%--                         <input type="email" class="form-control" name="permission" required="" aria-required="true">--%>
                                        <label class="form-label">Permission</label>
                                    </div>
                                </div>
                                <%--<div class="form-group">
                                    <input type="radio" name="gender" id="male" class="with-gap">
                                    <label for="male">Male</label>

                                    <input type="radio" name="gender" id="female" class="with-gap">
                                    <label for="female" class="m-l-20">Female</label>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <textarea name="description" cols="30" rows="5" class="form-control no-resize" required="" aria-required="true"></textarea>
                                        <label class="form-label">Description</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <input type="password" class="form-control" name="password" required="" aria-required="true">
                                        <label class="form-label">Password</label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <input type="checkbox" id="checkbox" name="checkbox">
                                    <label for="checkbox">I have read and accept the terms</label>
                                </div>--%>
                                <asp:Button  class="btn btn-primary waves-effect" ID="Button1" runat="server" Text="SUBMIT" OnClick="Button1_Click1" />
                                <%--<button class="btn btn-primary waves-effect" type="submit">SUBMIT</button>--%>
                                <asp:LinkButton ID="LinkButton1" class="btn btn-primary waves-effect" runat="server" OnClick="LinkButton1_Click">取消</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            
            <!-- #END# Basic Validation -->
            <!-- Advanced Validation -->
        <%--    <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>ADVANCED VALIDATION</h2>
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Action</a></li>
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Another action</a></li>
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="body">
                            <form id="form_advanced_validation" method="POST" novalidate="novalidate">
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <input type="text" class="form-control" name="minmaxlength" maxlength="10" minlength="3" required="" aria-required="true">
                                        <label class="form-label">Min/Max Length</label>
                                    </div>
                                    <div class="help-info">Min. 3, Max. 10 characters</div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <input type="text" class="form-control" name="minmaxvalue" min="10" max="200" required="" aria-required="true">
                                        <label class="form-label">Min/Max Value</label>
                                    </div>
                                    <div class="help-info">Min. Value: 10, Max. Value: 200</div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <input type="url" class="form-control" name="url" required="" aria-required="true">
                                        <label class="form-label">Url</label>
                                    </div>
                                    <div class="help-info">Starts with http://, https://, ftp:// etc</div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <input type="text" class="form-control" name="date" required="" aria-required="true">
                                        <label class="form-label">Date</label>
                                    </div>
                                    <div class="help-info">YYYY-MM-DD format</div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <input type="number" class="form-control" name="number" required="" aria-required="true">
                                        <label class="form-label">Number</label>
                                    </div>
                                    <div class="help-info">Numbers only</div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <input type="text" class="form-control" name="creditcard" pattern="[0-9]{13,16}" required="" aria-required="true">
                                        <label class="form-label">Credit Card</label>
                                    </div>
                                    <div class="help-info">Ex: 1234-5678-9012-3456</div>
                                </div>
                                <button class="btn btn-primary waves-effect" type="submit">SUBMIT</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Advanced Validation -->
            <!-- Validation Stats -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                                VALIDATION STATS
                            </h2>
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Action</a></li>
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Another action</a></li>
                                        <li><a href="javascript:void(0);" class=" waves-effect waves-block">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="body">
                            <form id="form_validation_stats">
                                <div class="form-group form-float">
                                    <div class="form-line focused warning">
                                        <input type="text" class="form-control" name="warning" value="Warning" required="">
                                        <label class="form-label">Form Validation - Warning</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line focused error">
                                        <input type="text" class="form-control" name="error" value="Error" required="">
                                        <label class="form-label">Form Validation - Error</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line focused success">
                                        <input type="email" class="form-control" name="success" value="Success" required="">
                                        <label class="form-label">Form Validation - Success</label>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>--%>
            <!-- #END# Validation Stats -->
</asp:Content>
