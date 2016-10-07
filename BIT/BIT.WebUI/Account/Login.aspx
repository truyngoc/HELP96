<%@ Page Title="Log in" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BIT.WebUI.Login" Async="true" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="Mosaddek" />
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina" />
    <link rel="shortcut icon" href="img/favicon.png" />
    <title>BIT Quick Login</title>
    <meta name="csrf-token" content="AvJsvFUkFTxZxtYHOn19V6YN6zqQExtwl6k0WVSd" />
    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap-reset.css" rel="stylesheet" />
    <!--external css-->
    <link href="../Content/font-awesome.css" rel="stylesheet" />
    <link href="../Content/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Content/owl.carousel.css" type="text/css" />
    <!--right slidebar-->
    <link href="../Content/slidebars.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="../Content/AdminStyle.css" rel="stylesheet" />
    <link href="../Content/style-responsive.css" rel="stylesheet" />
    <%--  <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />--%>
    <%--   <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/ValidationEngine.css" rel="stylesheet" />--%>
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.js"></script>
    <%--<script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js"></script>--%>
    <script src='https://www.google.com/recaptcha/api.js'></script>

    <!-- Start Alexa Certify Javascript -->
<script type="text/javascript">
    _atrk_opts = { atrk_acct: "1ArLn1QolK1052", domain: "bitquick24.org", dynamic: true };
    (function () { var as = document.createElement('script'); as.type = 'text/javascript'; as.async = true; as.src = "https://d31qbv1cthcecs.cloudfront.net/atrk.js"; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(as, s); })();
</script>
<noscript><img src="https://d5nxst8fruw4z.cloudfront.net/atrk.gif?account=1ArLn1QolK1052" style="display:none" height="1" width="1" alt="" /></noscript>
<!-- End Alexa Certify Javascript -->  
    <style>
        .btn-login {
            padding: 10px 20px;
            font-weight: bold;
            text-transform: uppercase;
            background: #375A7F;
        }
    </style>
</head>
<body >
    <div class="container" style="background-color: #E6E7E8 !important; border-bottom: 10px solid #F6921E;">
        <div style="text-align: center; margin: 60px auto 0; padding: 15px;" class="logo-login">
            <a href="#">
                <img style="width: 250px; height: 115px" src="../images/logo_BitQuick.png" />
            </a>
        </div>
        <form style="margin-top: 20px;" class="form-signin" runat="server">
            <br />
            <div class="text-center">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="*Username or Password is not valid" Visible="false"></asp:Label>
            </div>

            <div class="login-wrap">
                <%--<div style="text-align: center;">
                    <h3 style="color: #ED1F24; text-align: center; margin: 0px 0px 20px 0px; font-size: 28px; text-transform: uppercase; border-bottom: 2px solid #e73437; display: inline-block;">Login</h3>
                </div>--%>
                <asp:TextBox ID="txtUserName" runat="server" class="form-control" Style="height: 41px;" placeholder="Username" />
                <asp:RequiredFieldValidator ErrorMessage="Enter your username" ControlToValidate="txtUserName" runat="server" ForeColor="#cc0066" Text="Enter your username" Display="Dynamic" />

                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" Style="height: 41px;" placeholder="Password" />

                <div class="g-recaptcha" data-sitekey="6Lc7JCgTAAAAAJPLLmyUqfbCHldvwljeIDaTEaRc">
             
                </div>

                <div style="padding: 5px 0;">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-info " OnClick="btnLogin_Click" />
                    <asp:Button ID="btnRegister" runat="server" Text="Sign up" class="btn btn-info" OnClick="btnRegister_Click" CausesValidation="false" />
                    <span class="pull-right"><a style="color: #ED1F24;" href="#">Forgot Password ?</a></span>
                </div>
            </div>
        </form>
    </div>
</body>
</html>


