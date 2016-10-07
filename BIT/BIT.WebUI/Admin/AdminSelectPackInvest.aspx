<%@ Page Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="AdminSelectPackInvest.aspx.cs" Inherits="BIT.WebUI.Admin.AdminSelectPackInvest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
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
                                    <th>User</th>
                                    <th>Transaction</th>
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
                                    <asp:Label runat="server" ID="lblStartDate" Text='<%# Eval("USERNAME") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEndDate" Text='<%# Eval("TRANSACTION_PACKAGE") %>'></asp:Label>
                                </td>
                                <td>
                                    <span class="label label-primary">
                                        <asp:Label runat="server" ID="lblStatus" Text='<%# getStatus(Eval("STATUS_PH")) %>'></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <a href="#">
                                        <asp:LinkButton runat="server" ID="lnkConfirm" CommandArgument='<%# Eval("ID") %>' type="submit" class="btn btn-success" Text="Confirm" OnClick="lnkConfirm_Click" />
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
