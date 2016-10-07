<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="OrderChangeInfo.aspx.cs" Inherits="BIT.WebUI.Admin.OrderChangeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel" runat="server" id="sessionSearch">
            <header class="panel-heading">
                <h3>Search by Username </h3>
            </header>
            <div class="panel-body">
                <div class="container center_div">
                    <asp:HiddenField ID="hidCodeId" runat="server" />
                    <asp:HiddenField ID="hidMonth" runat="server" />
                    <asp:HiddenField ID="hidPack" runat="server" />
                    <div class="form-group col-lg-12">
                        <div class="col-lg-5">
                            <asp:TextBox runat="server" ID="txtUsername" placeholder="User name"></asp:TextBox>
                            <asp:Button runat ="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="panel">
            <header class="panel-heading">
                <h3>Orders History</h3>
            </header>
            <div class="panel-body">
                <div class="form">
                    <asp:DataList ID="grdMembers" runat="server" class="table table-hover p-table">
                        <HeaderTemplate>
                            <table class="table table-hover p-table">
                                <tr>
                                    <th>Create Date</th>
                                    <th>User name</th>
                                    <th>Upline </th>
                                    <th>Transaction</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPHTime" Text='<%# Eval("CREATEDATE") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblUserName" Text='<%# Eval("UserName") %>'> </asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblUpline" Text='<%# Eval("Upline") %>' />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkTransaction" runat="server" OnClick="lnkTransaction_Click" CommandArgument='<%# Eval("Transaction") %>' Text='<%#Eval("Transaction").ToString() %>' Font-Bold="true" ForeColor="#2d3fda"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEndDate" Text='<%# getStatus(Eval("STA").ToString()) %>' ForeColor="Red" Font-Bold="true"></asp:Label>
                                </td>
                               
                                <td>
                                    <a href="#">
                                        <asp:LinkButton runat="server" ID="btnConfirm" Visible='<%# ShowConfirm(Eval("Upline").ToString(),Eval("STA").ToString()) %>'  type="submit" class="btn btn-success" Text="Confirm"  CommandArgument='<%# Eval("Username") %>'  OnClick="btnConfirm_Click" />
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
