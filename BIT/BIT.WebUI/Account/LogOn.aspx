<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="BIT.WebUI.Account.LogOn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="span8" style="margin-top: -20px;">
        <h2 style="font-family: 'Times New Roman'"><b>Login form</b></h2>

        <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="*Username or Password is not valid" Visible="false"></asp:Label>
        <br />
        <asp:TextBox ID="txtUserName" runat="server" class="form-control" Style="width: 350px; height: 41px;" placeholder="Username" />
        <asp:RequiredFieldValidator ErrorMessage="Enter your username" ControlToValidate="txtUserName" runat="server" ForeColor="#cc0066" Text="Enter your username" Display="Dynamic" />
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" Style="width: 350px; height: 41px;" placeholder="Password" />
        <asp:RequiredFieldValidator ErrorMessage="Enter your password" ControlToValidate="txtPassword" runat="server" ForeColor="#cc0066" Text="Enter your password" Display="Dynamic" />
        <br>
        <%--<asp:LinkButton ID="btnLink" runat="server" Text="Lost your MAT_KHAU? Click here to reset MAT_KHAU via email."> </asp:LinkButton><br>--%>
        <a href="#">Lost your password? Click here to reset password via email</a>
        <br>
        <br>
        <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary" OnClick="btnLogin_Click" />

    </div>

</asp:Content>
