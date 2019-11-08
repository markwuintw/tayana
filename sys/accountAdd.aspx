<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site2.Master" AutoEventWireup="true" CodeBehind="accountAdd.aspx.cs" Inherits="Tayana.sys.accountAdd"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
            <div class="block-header">
                <h2>
                    新增帳號
<%--                    <small>Taken from <a href="https://jqueryvalidation.org/" target="_blank">jqueryvalidation.org</a></small>--%>
                </h2>
            </div>
            <!-- Basic Validation -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
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
                        </div>
                        <div class="body">
                            <div class="form-group form-float">
                                    <div class="form-line">
                                        
                                        <asp:TextBox ID="accountyo" class="form-control" name="account"  required="" aria-required="true" runat="server" ClientIDMode="Static"></asp:TextBox>
                      <%--                  <input type="text" class="form-control" name="account" required="" aria-required="true" runat="server">--%>
                                        <label class="form-label">Account</label>
                                    </div>

                                <%--  驗證該帳號是否已存在  --%>
                                    <input id="Button2" type="button" value="驗證該帳號是否已存在" /><%--<asp:Label ID="accountAlert" runat="server" Text=""></asp:Label>--%>
                                    <span id="accountAlert"></span>
                                    <script>
                                        var checkbtn = document.getElementById("Button2");

                                        checkbtn.addEventListener("click",
                                            function () {
                                                var username = document.getElementById("accountyo").VALUE;
                                                console.log(username);
                                                var xhr = new XMLHttpRequest();
                                                xhr.open("GET", 'https://localhost:44330/checkusername.ashx?username=' + username);
                                                xhr.setRequestHeader("Accept", "application/text");
                                                xhr.send();

                                                xhr.onload = function () {
                                                    console.log(xhr);
                                                    var data = xhr.responseText;
                                                    console.log(data);
                                                    var message = document.getElementById("accountAlert");
                                                    message.innerText = data;
                                                }

                                            });
                                    </script>
                                </div>
                                
                                
                                <%-- 密碼欄及確認密碼欄是用JS，參考 https://stackoverflow.com/questions/9142527/can-you-require-two-form-fields-to-match-with-html5 ，重點在於"密碼欄"加 ClientIDMode="Static"，確認密碼欄加 oninput="check(this)" ，
                                    並在確認密碼欄加上JS程式
                                                        <script language='javascript' type='text/javascript'>
                                                                function check(input) {
                                                                if (input.value != document.getElementById('password').value) {
                                                                    input.setCustomValidity('Password Must be Matching.');
                                                                } else {
                                                                    // input is valid -- reset the error message
                                                                    input.setCustomValidity('');
                                                                }
                                                            }
                                                        </script> --%>
                                
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox ID="password" class="form-control" name="password" required="" aria-required="true" oninvalid="setCustomValidity('你他媽的給我輸入資料哦')" oninput="this.setCustomValidity('')" runat="server" TextMode="Password" ClientIDMode="Static" ></asp:TextBox>
<%--                                        <input type="text" class="form-control" name="password" required="" aria-required="true">--%>
                                        <label class="form-label">Password</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox  class="form-control" name="password_confirm" required="required" type="password" id="password_confirm" oninput="check(this)"  runat="server" TextMode="Password"></asp:TextBox>
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
                                        <asp:TextBox ID="name" class="form-control" name="name" required="" aria-required="true"  runat="server" ></asp:TextBox>
                                        <%--<input type="text" class="form-control" name="name" required="" aria-required="true">--%>
                                        <label class="form-label">Name</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:FileUpload ID="fuPic" runat="server" class="form-control" />
                                        <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                                        <%--<input type="text" class="form-control" name="name" required="" aria-required="true">--%>
                                        <label class="form-label">Photo</label>
                                    </div>
                                </div>
                                <div class="form-group form-float">
                                    <div class="form-line">
                                        <asp:TextBox ID="email" class="form-control" name="email" pattern="^(([-\w\d]+)(\.[-\w\d]+)*@([-\w\d]+)(\.[-\w\d]+)*(\.([a-zA-Z]{2,5}|[\d]{1,3})){1,2})$" 
                                                     required="required" runat="server"></asp:TextBox>
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
                                        <%--<asp:TextBox ID="permission" class="form-control" name="permission" runat="server"></asp:TextBox>--%>
                                        <div style="padding: 10px 0 0 0">
                                            <asp:CheckBoxList ID="CheckBoxList1" RepeatDirection="Horizontal" runat="server"  style="margin: 0 0 0 80px">
                                                <asp:ListItem Text="帳號管理" Value="p001" ></asp:ListItem>
                                                <asp:ListItem Text="ORID系統" Value="p002" ></asp:ListItem>
                                                <asp:ListItem Text="其他" Value="p003" ></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>

                                        <%--<input type="email" class="form-control" name="permission" required="" aria-required="true">--%>
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
            <%--                    <button class="btn btn-primary waves-effect" type="submit">SUBMIT</button>--%>
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
        </div>
</asp:Content>
