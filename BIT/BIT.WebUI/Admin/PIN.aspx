<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="PIN.aspx.cs" Inherits="BIT.WebUI.Admin.PIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Pin Transfer</h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <div class="form-group col-lg-12">
                        <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Visible="false" Text=""></asp:Label>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3" for="firstname">Username Transfer *</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtUserReceivePIN" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter Username Transfer" ControlToValidate="txtUserReceivePIN" runat="server" ForeColor="#cc0066" Text="Enter Username Transfer" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3" for="firstname">Amount Transfer *</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter Amount Transfer" ControlToValidate="txtAmount" runat="server" ForeColor="#cc0066" Text="Enter Amount Transfer" Display="Dynamic" />

                            PIN balance:<strong style="color: #8075C4;">
                                <asp:Label runat="server" ID="lblPINBalance"></asp:Label>
                            </strong>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3" for="firstname">Transaction Password*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPassword_PIN" CssClass="form-control" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter Transaction Password" ControlToValidate="txtPassword_PIN" runat="server" ForeColor="#cc0066" Text="Enter Transaction Password" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div style="text-align: center;" class="col-lg-12">
                            <asp:Button runat="server" ID="btnSendPIN" CssClass="btn btn-info" BackColor="#3F51B5" Text="SEND PIN" OnClick="btnSendPIN_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="panel">
            <header class="panel-heading">
                <h3>Pin History Transaction</h3>
            </header>

            <asp:Repeater ID="rptPIN_TRANS" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Time transfer</th>
                                <th>Notes</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("Create_Date", "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblNotes" runat="server" Text='<%# Eval("Transaction_Type") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amout") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>

        </section>
    </section>
</asp:Content>
