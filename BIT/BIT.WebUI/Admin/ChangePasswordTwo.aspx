<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="ChangePasswordTwo.aspx.cs" Inherits="BIT.WebUI.Admin.ChangePasswordTwo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Chance Password PIN</h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label">Old Password PIN</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtOldPassword" CssClass="form-control" placeholder="Old Password PIN" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter Old Password PIN" ControlToValidate="txtOldPassword" runat="server" ForeColor="#cc0066" Text="Enter Old Password PIN" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label">New Password PIN</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" placeholder="New Password PIN" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter New Password PIN" ControlToValidate="txtNewPassword" runat="server" ForeColor="#cc0066" Text="Enter New Password PIN" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label">Confirm New Password PIN</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtConfirmNewPassword" CssClass="form-control" placeholder="Confirm New Password PIN" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter New Password PIN Confirm" ControlToValidate="txtConfirmNewPassword" runat="server"  ForeColor="#cc0066" Text="Enter New Password PIN Confirm" Display="Dynamic" />
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmNewPassword" runat="server"  ForeColor="#cc0066"  ErrorMessage="Password PIN confirm is not valid"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div class="col-lg-offset-2 col-lg-3 ">
                            <asp:Button runat="server" ID="btnChangePass" CssClass="btn btn-info" Text="Change Password PIN" OnClick="btnChangePass_Click" />
                        </div>
                    </div>

                    <br />
                    <div class="form-group col-lg-12">
                        <asp:Label runat="server" ID="lblMessage" Visible="false" CssClass="text-warning"></asp:Label>
                    </div>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
