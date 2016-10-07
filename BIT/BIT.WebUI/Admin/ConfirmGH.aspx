<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="ConfirmGH.aspx.cs" Inherits="BIT.WebUI.Admin.ConfirmGH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Confirm GH </h3>
            </header>
            <div class="panel-body">                
                <div class="container center_div">
                    <asp:HiddenField ID="hidID" runat="server" />
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Address GH</label>
                            <div class="col-lg-5">
                                <span class="badge">
                                    <asp:Image ID="imgGHWallet" Width="200" Height="200" runat="server" />
                                </span>
                                <br />
                                <asp:Label runat="server" ID="lblGHWallet"></asp:Label>
                            </div>
                    </div>
                    
                    
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Total Amount</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" readonly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Transaction</label>
                        <div class="col-lg-6">                            
                            <asp:HyperLink ID="linkTransaction" runat="server" target="_blank"></asp:HyperLink>
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Password PIN*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPasswordPIN" CssClass="form-control" placeholder="Input Password PIN to confirm PH" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter Password PIN" ControlToValidate="txtPasswordPIN" runat="server" ForeColor="#cc0066" Text="Enter Password PIN" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div class="col-lg-3"></div>
                        <div class="col-lg-6">
                            <asp:Button runat="server" ID="btnConfirmGH" class="btn btn-info" Text="CONFIRM" OnClick="btnConfirmGH_Click" OnClientClick="javascript:return confirm('Are you absolutely sure you want to confirm GH?')"  />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
    </section>
</asp:Content>
