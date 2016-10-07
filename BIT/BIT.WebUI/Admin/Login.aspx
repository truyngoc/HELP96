<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BIT.WebUI.Admin.Login" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="Mosaddek" />
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina" />
    <link rel="shortcut icon" href="favicon.png" />
    <title>BitQuick24 Login</title>
    <meta name="csrf-token" content="AvJsvFUkFTxZxtYHOn19V6YN6zqQExtwl6k0WVSd" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.js"></script>
    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap-reset.css" rel="stylesheet" />
    <link href="../Content/font-awesome.css" rel="stylesheet" />
    <link href="../Content/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Content/owl.carousel.css" type="text/css" rel="stylesheet" />
    <link href="../Content/slidebars.css" rel="stylesheet" />
    <link href="../Content/AdminStyle.css" rel="stylesheet" />
    <link href="../Content/style-responsive.css" rel="stylesheet" />
    <style>
        .btn-login {
            padding: 10px 20px;
            font-weight: bold;
            text-transform: uppercase;
            background: #375A7F;
        }
    </style>
    <!-- Start Alexa Certify Javascript -->
    <script type="text/javascript">
        _atrk_opts = { atrk_acct: "1ArLn1QolK1052", domain: "bitquick24.org", dynamic: true };
        (function () { var as = document.createElement('script'); as.type = 'text/javascript'; as.async = true; as.src = "https://d31qbv1cthcecs.cloudfront.net/atrk.js"; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(as, s); })();
    </script>
    <noscript><img src="https://d5nxst8fruw4z.cloudfront.net/atrk.gif?account=1ArLn1QolK1052" style="display:none" height="1" width="1" alt="" /></noscript>
    <!-- End Alexa Certify Javascript -->
</head>
<body style="background-color: #E6E7E8;">
    <div class="container">
        <div style="text-align: center; margin: 60px auto 0; padding: 0 15px;"  class="logo-login">
            <a href="/" class="logo_login">
                <img src="../images/logo_BitQuick.png" />
            </a>
        </div>
        <form style="margin-top: 1px;" class="form-signin" runat="server">
            <br />
            <div class="text-center">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="*Username or Password is not valid" Visible="false"></asp:Label>
            </div>

            <div class="login-wrap">
                <asp:TextBox ID="txtUserName" runat="server" class="form-control" Style="height: 41px;" placeholder="Username" />
                <asp:RequiredFieldValidator ErrorMessage="Enter your username" ControlToValidate="txtUserName" runat="server" ForeColor="#cc0066" Text="Enter your username" Display="Dynamic" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" Style="height: 41px;" placeholder="Password" />
                <div style="padding: 5px 0;">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-info btn-login" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-info btn-login" />
                </div>
                <div>
                    <asp:LinkButton runat="server" ID="lnkLostPass" style="color: #ED1F24;" OnClick="lnkLostPass_Click" Text="Forgot your password ? Click here"> </asp:LinkButton>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
