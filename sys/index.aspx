 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tayana.sys.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <meta charset="UTF-8">
        <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
        <title>Sign In | Bootstrap Based Admin Template - Material Design</title>
        <!-- Favicon-->
        <link rel="icon" href="/sys/favicon.ico" type="image/x-icon">

        <!-- Google Fonts -->
        <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&amp;subset=latin,cyrillic-ext" rel="stylesheet" type="text/css">
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css">

        <!-- Bootstrap Core Css -->
        <link href="/sys/plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

        <!-- Waves Effect Css -->
        <link href="/sys/plugins/node-waves/waves.css" rel="stylesheet">

        <!-- Animation Css -->
        <link href="/sys/plugins/animate-css/animate.css" rel="stylesheet">

        <!-- Custom Css -->
        <link href="/sys/css/style.css" rel="stylesheet">

</head>

<body class="login-page ls-closed">
<form id="form1" runat="server">
    <div class="login-box">
        <div class="logo">
            <a href="javascript:void(0);">Admin<b>BYMarkWu</b></a>
            <small>Admin BootStrap Based - Material Design</small>
        </div>
        <div class="card">
            <div class="body">
                <%--<form id="sign_in" method="POST" novalidate="novalidate">--%>
                    <div class="msg">Sign in to start your session</div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">person</i>
                        </span>
                        <div class="form-line">
                            <input type="text" class="form-control" name="username" id="username" placeholder="Username" required="" autofocus="" aria-required="true" runat="server"/>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <input type="password" class="form-control" name="password" id="password" placeholder="Password" required="" aria-required="true" runat="server"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 p-t-5">
                            <input type="checkbox" name="rememberme" id="rememberme" class="filled-in chk-col-pink">
                            <label for="rememberme">Remember Me</label>
                        </div>
                        <div class="col-xs-4">
                            <%--<button class="btn btn-block bg-pink waves-effect" type="submit">SIGN IN</button>--%>
                            <asp:Button ID="Button1" runat="server" class="btn btn-block bg-pink waves-effect" Text="SIGN IN" OnClick="Button1_Click" />
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row m-t-15 m-b--20">
<%--                        <div class="col-xs-6">
                            <a href="sign-up.html">Register Now!</a>
                        </div>--%>
                        <div class="col-xs-6 align-right">
                            <a href="forgot-password.html">Forgot Password?</a>
                        </div>
                    </div>
                <%--</form>--%>
            </div>
        </div>
    </div>

    <!-- Jquery Core Js -->
    <script src="/sys/plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Js -->
    <script src="/sys/plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Waves Effect Plugin Js -->
    <script src="/sys/plugins/node-waves/waves.js"></script>

    <!-- Validation Plugin Js -->
    <script src="/sys/plugins/jquery-validation/jquery.validate.js"></script>

    <!-- Custom Js -->
    <script src="/sys/js/admin.js"></script>
    <script src="/sys/js/pages/examples/sign-in.js"></script>
</form>
</body>
</html>
