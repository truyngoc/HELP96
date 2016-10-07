<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Commission.aspx.cs" Inherits="BIT.WebUI.Admin.Commission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <section class="panel">
        <section class="wrapper">
            <br />
            <section class="panel">
                <header class="panel-heading">
                    <h3>COMMISSION HISTORY</h3>
                </header>
            </section>
            <section class="panel">
                <asp:DataList runat="server" ID="dtlGH" class="table table-hover p-table">
                    <HeaderTemplate>
                        <table class="table table-hover p-table">
                            <thead>
                                <tr>
                                    <th>FROM</th>
                                    <th>CREATE DATE</th>
                                    <th>AMOUNT</th>
                                    <th>TYPE</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblUserFrom"><%# Eval("UserFrom") %></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label1"><%# Eval("CreateDate") %></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblGHAmount"><%# Eval("Amount").ToString().Remove(6) %></asp:Label>
                                    BTC
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label2"><%# Eval("Type") %></asp:Label>
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
