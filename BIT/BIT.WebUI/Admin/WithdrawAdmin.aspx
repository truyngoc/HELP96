<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master"
    AutoEventWireup="true" CodeBehind="WithdrawAdmin.aspx.cs" Inherits="BIT.WebUI.Admin.WithdrawAdmin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>WithDraw List</h3>
            </header>

            <asp:DataList runat="server" ID="dtlRecharge" class="table table-hover p-table">
                <HeaderTemplate>
                    <table class="table table-hover p-table">
                        <thead>
                            <tr>
                                <td>ID</td>
                                <td>Create Date</td>
                                <td>Username</td>
                                <td>Receive Wallet</td>
                                <td>Amount</td>
                                <td>Status</td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%# Eval("ID") %>
                            </td>
                            <td>
                                <%# Eval("Date_Create") %>                          
                            </td>
                            <td>
                                <%# Eval("Username") %>  
                            </td>

                            <td>
                                <asp:LinkButton ID="lnkBlockchain" runat="server" Font-Bold="true" ForeColor="#2d3fda"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblAm" Text='<%# Eval("Amount").ToString().Substring(0,Eval("Amount").ToString().Length -4) %>' Font-Bold="true" ForeColor="Red"></asp:Label>
                            </td>
                            <td><span class="label label-primary">
                                <%# getStatus(Eval("Status")) %>
                            </span>
                                </td>
                            <td>
                                <asp:LinkButton ID="lbkBtnConfirm" runat="server" Visible='<%# getConfirmVisible(Eval("Status")) %>' Text="Select" CommandArgument='<%# Eval("ID") %>' class="btn btn-info" OnClick="lbkBtnConfirm_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </section>
        <div class="pagination"></div>
    </section>
</asp:Content>
