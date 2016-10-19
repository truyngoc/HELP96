<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="GH_DETAIL.aspx.cs" Inherits="BIT.WebUI.Admin.GH_DETAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #p_time {
            width: 100%;
            color: red;
            font-size: 25px;               
            text-align: center;
            font-family: 'Open Sans', sans-serif;            
        }
    </style>

    <section class="wrapper">
        <br />
        <!---ss PH-->
        <section class="panel">
            <header class="panel-heading">
                <h3>GH details</h3>
            </header>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        Page refresh after <span id="p_time">30</span> seconds
                    </div>

                </div>
                <section class="panel">
                        <%--<asp:DataList ID="grdCMD" runat="server" class="table table-hover p-table">
                        <HeaderTemplate>
                            <table class="table table-hover p-table">
                                <tr>
                                    <th>No.</th>
                                    <th>Sender</th>
                                    <th>Create date </th>
                                    <th>Amount</th>
                                    <th>Time remaining (hours)</th>
                                    <th>Transaction</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblSTT" Text='<%#Container.ItemIndex + 1 %> '></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSender" runat="server" Text='<%# AccountBriefInfoByCodeId(Eval("CodeId_From").ToString()) %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("DateCreate" , "{0:dd/MM/yyyy HH:mm}") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount").ToString().Substring(0,5) %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblTimeRemaining" runat="server" Text='<%# showTimeRemaining((DateTime)Eval("DateCreate"), (int)Eval("Status")) %>' />
                                </td>
                               
                                <td>
                                    <asp:HyperLink ID="linkTransaction" runat="server" NavigateUrl='<%# TransactionLink(Eval("TransactionId")) %>' Text="View" Visible='<%# visibleTransactionLink(Eval("TransactionId")) %>' Target="_blank"></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString((int)Eval("Status")) %>' CssClass='<%# CssStatus((int)Eval("Status")) %>' />
                                </td>
                                <td>
                                    <a href="#">
                                        <asp:LinkButton runat="server" ID="btnConfirm" Visible='<%# visibleConfirmButton(Eval("ConfirmGH"), Eval("ConfirmPH"),Eval("Status")) %>'  type="submit" class="btn btn-success" Text="CONFIRM"  CommandArgument='<%# Eval("ID") %>'  OnClick="btnConfirm_Click"/>
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:DataList>--%>

                        <asp:GridView ID="grdCommandDetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="50"
                            OnPageIndexChanging="grdCommandDetails_OnPageIndexChanging" CssClass="table table-hover p-table" UseAccessibleHeader="true" GridLines="None"
                            OnRowCommand="grdCommandDetails_OnRowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sender" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSender" runat="server" Text='<%# AccountBriefInfoByCodeId(Eval("CodeId_From").ToString()) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sponsor sender" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSponsor" runat="server" Text='<%# AccountSponsorBriefInfoByCodeId(Eval("CodeId_From").ToString()) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Create date" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("DateCreate" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# formatAmount((decimal)Eval("Amount")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Time remaining (hours)" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTimeRemaining" runat="server" Text='<%# showTimeRemaining((DateTime)Eval("DateCreate"), (int)Eval("Status")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Transaction" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="linkTransaction" runat="server" NavigateUrl='<%# TransactionLink(Eval("TransactionId")) %>' Text="View" Visible='<%# visibleTransactionLink(Eval("TransactionId")) %>' Target="_blank"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString((int)Eval("Status")) %>' CssClass='<%# CssStatus((int)Eval("Status")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Button ID="btnConfirm" runat="server" CommandName="cmdConfirm" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-primary" Text="CONFIRM" Visible='<%# visibleConfirmButton(Eval("ConfirmGH"), Eval("ConfirmPH"),Eval("Status")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                </section>
            </div>
        </section>
    </section>

    <script type="text/javascript">
        var jgt = 30;
        document.getElementById('p_time').innerHTML = jgt;
        function stime() {
            document.getElementById('p_time').innerHTML = jgt; jgt = jgt - 1;
            if (jgt == 0) { clearInterval(timing); location = window.location; }
        }
        var timing = setInterval("stime();", 1000);
    </script>
</asp:Content>

