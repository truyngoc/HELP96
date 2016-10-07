<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="PIN.aspx.cs" Inherits="BIT.WebUI.Admin.PIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Select Pack Invest </h3>
            </header>
            <div class="panel-body">
                <div class="container center_div">
                    <asp:HiddenField ID="hidPackage_transactionID" runat="server" />
                    <asp:HiddenField ID="hid_avaiableMonth" runat="server" Value="0" />
                    <asp:HiddenField ID="hidMonth" runat="server" />
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Address to payment</label>
                            <div class="col-lg-5">
                                <span class="badge">
                                    <asp:Image ID="imgAdminWallet"  Width="200" Height="200" runat="server" />
                                </span>
                                <br />
                                <asp:Label runat="server" ID="lblAdminWallet" ></asp:Label>
                            </div>
                    </div>
                    <div class="form-group col-lg-12">
                            <label class="control-label col-lg-3">Selected Invest Pack</label>
                            <div class="col-lg-6">
                                <asp:Label ID="lblCurrentPack" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group col-lg-12">
                            <label class="control-label col-lg-3">Select extend invest month</label>
                            <div class="col-lg-6">
                                <asp:DropDownList runat="server" ID="drTimeInvest" OnSelectedIndexChanged="drTimeInvest_SelectedIndexChanged" AutoPostBack="true" >
                                    <asp:ListItem Text="1 Month" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2 Month" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3 Month" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Amount</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" placeholder="Total payment: Invest Pack + Extend Fee" Enabled="false">1.2</asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Transaction</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTransaction" CssClass="form-control" placeholder="8494be30f36c1652617"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="control-label col-lg-3">Password PIN*</label>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPasswordPIN" CssClass="form-control" type="password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <div style="text-align: center;" class="col-lg-12">
                            <asp:Button runat="server" ID="btnUpdate" class="btn btn-info" Text="Buy Pack" OnClick="btnUpdate_Click1" />
                        </div>
                    </div>

                    <div class="form-group col-lg-12">
                        <asp:Label runat="server" ID="lblMessage" Visible="false" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>
        </section>
        <section class="panel">
            <header class="panel-heading">
                <h3>Invest History</h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <asp:DataList ID="grdListPH" runat="server" class="table table-hover p-table">
                        <HeaderTemplate>
                            <table class="table table-hover p-table">
                                <tr>
                                    <th>Create Date</th>
                                    <th>Pack Name</th>
                                    <th>Start Date</th>
                                    <th>Expire Date</th>
                                    <th>Date Count</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPHTime" Text='<%# Eval("CREATE_DATE") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblAmount" Text=''> </asp:Label>BTC
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblStartDate" Text='<%# Eval("FROM_DATE") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEndDate" Text='<%# Eval("TO_DATE") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label1" Text='<%# datecount(Eval("CREATE_DATE")) %>'></asp:Label>
                                </td>
                                <td>
                                    <span class="label label-primary">
                                        <asp:Label runat="server" ID="lblStatus" Text='<%# getStatus(Eval("STATUS")) %>'></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <a href="#">
                                        
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:DataList>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
