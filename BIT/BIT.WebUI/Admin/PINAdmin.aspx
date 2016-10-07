<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="PINAdmin.aspx.cs" Inherits="BIT.WebUI.Admin.PINAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>Extend Package History</h3>
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
                                    <asp:Label runat="server" ID="lblAmount" Text='<%# Eval("AMOUNT") %>'> </asp:Label>BTC
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
                                        <asp:LinkButton runat="server" ID ="lnkSave" Text="Confirm" CommandArgument= '<%# Eval("ID") %>' OnClick="lnkSave_Click"></asp:LinkButton>
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
