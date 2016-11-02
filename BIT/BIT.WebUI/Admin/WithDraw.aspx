<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master"
    AutoEventWireup="true" CodeBehind="WithDraw.aspx.cs" Inherits="BIT.WebUI.Admin.WithDraw" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>WithDraw to BlockChain</h3>
            </header>
            <div class="form">
                <form enctype="multipart/form-data" class="cmxform form-horizontal tasi-form">
                    <div class="form-group col-lg-12">

                        <div class="col-md-12 col-md-offset-3">
                            <label class="control-label col-lg-2" for="firstname">C Wallet</label>
                            <div class="col-lg-5">
                                <asp:Label runat="server" ID="lblCWalletAmt"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-12 col-md-offset-3">
                            <label class="control-label col-lg-2" for="firstname">Remain Amount / Month</label>
                            <div class="col-lg-5">
                                <asp:Label runat="server" ID="lblQuota"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-12 col-md-offset-3">
                            <label class="control-label col-lg-2" for="firstname">Withdraw Amount </label>
                            <div class="col-lg-5">
                                <%--<asp:TextBox runat="server" ID="txtAmount" type="Number" ReadOnly="true"></asp:TextBox>--%>
                                <asp:DropDownList runat="server" ID="lstAmount">
                                    <asp:ListItem Text="240" Value="240" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="480" Value="480"></asp:ListItem>
                                    <asp:ListItem Text="960" Value="960"></asp:ListItem>
                                    <asp:ListItem Text="4800" Value="4800"></asp:ListItem>
                                    <asp:ListItem Text="9600" Value="9600"></asp:ListItem>
                                </asp:DropDownList> USD
                            </div>
                        </div>

                        <div class="col-md-12 col-md-offset-3">
                            <label class="control-label col-lg-2" for="firstname">Enter PIN 2 </label>
                            <div class="col-lg-2">
                                <asp:TextBox runat="server" ID="txtPin2" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div class="form-group col-lg-12">
                        <div style="text-align: center;" class="col-lg-12">
                            <asp:Button runat="server" ID="btnWithDraw" class="btn btn-info" Text="Withdraw" OnClick="btnWithDraw_Click" />
                        </div>
                    </div>
                </form>
            </div>
            <label></label>
        </section>
        <section class="panel">
            <header class="panel-heading">
                <h3>WithDraw to BlockChain List</h3>
            </header>
            <asp:DataList runat="server" ID="dtlWithDraw" class="table table-hover p-table">
                <HeaderTemplate>
                    <table class="table table-hover p-table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Withdraw Time</th>
                                <th>Amount</th>
                                <th>Status</th>
                                <th>Transaction</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblGHID"><%#Eval("ID") %></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblGHTime"><%# Eval("Date_Create") %></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblGHAmount"><%# Eval("Amount").ToString().Remove(6) %></asp:Label>
                                USD</td>
                            <td>
                                <span class="label label-success"><%# getGHStatus(Eval("Status")) %></span>
                            </td>
                            <td>
                                <a href='https://blockchain.info/tx/<%# Eval("TransactionId") %>' target='_blank'>
                                    <span class="label label-success"><%# Eval("TransactionId") %></span>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
               
                </FooterTemplate>
            </asp:DataList>
        </section>
    </section>
</asp:Content>
