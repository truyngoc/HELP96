<%@ Page Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="SelectPackInvest.aspx.cs" Inherits="BIT.WebUI.Admin.SelectPackInvest" %>

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
                    <asp:HiddenField ID="hidCodeId" runat="server" />
                    <asp:HiddenField ID="hidMonth" runat="server" />
                    <asp:HiddenField ID="hidPack" runat="server" />
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
                            <label class="control-label col-lg-3">Select Pack</label>
                            <div class="col-lg-6">
                                <asp:DropDownList runat="server" ID="drPackSelectTion" OnSelectedIndexChanged="drPackSelectTion_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList> BTC
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
                        <label class="control-label col-lg-3">Total Amount</label>
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
                                    <asp:Label runat="server" ID="lblAmount" Text='<%# Eval("PACKAGEID") %>'> </asp:Label>BTC
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblStartDate" Text='<%# Eval("START_DATE") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEndDate" Text='<%# Eval("END_DATE") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label1" Text='<%# datecount(Eval("START_DATE"),Eval("END_DATE"),Eval("ID")) %>'></asp:Label>
                                </td>
                                <td>
                                    <span class="label label-primary">
                                        <asp:Label runat="server" ID="lblStatus" Text='<%# getStatus(Eval("STATUS_PH"),Eval("STATUS_GH")) %>'></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <a href="#">
                                        <asp:LinkButton runat="server" ID="lnkExtend" Visible='<%# getExtendVisible( Eval("END_DATE"),Eval("STATUS_GH")) %>' type="submit" class="btn btn-success" Text="Extend" OnClick="lnkExtend_Click" />
                                        <asp:LinkButton runat="server" ID="btnGH1" Visible='<%# getGH1Enable(Eval("START_DATE"),Eval("STATUS_GH")) %>' CommandArgument='<%# Eval("ID") %>' type="submit" class="btn btn-success" Text="GH1" OnClick="btnGH1_Click" />
                                        <asp:LinkButton runat="server" ID="btnGH2" Visible='<%# getGH2Enable(Eval("START_DATE"),Eval("STATUS_GH")) %>' CommandArgument='<%# Eval("ID") %>' type="submit" class="btn btn-success" Text="GH2" OnClick="btnGH2_Click" />
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
