<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="CreatePHCommunity.aspx.cs" Inherits="BIT.WebUI.Admin.CreatePHCommunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>--%>

    <%--<script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* wider than 768px fixed width */
        @media screen and (min-width: 768px) {

            .modal-dialog {
                width: 975px;
            }
        }

        /*less than 768px the modal will fill the width which is then set to auto*/
        .mydialog {
            width: 75%;
        }

        /* can giua cho table tren man hinh */
        .center-table {
            margin: auto 0 auto !important;
            float: none !important;
        }

        .fdb-panel-header-10 {
            color: #fff; /* mau chu */
            background-color: #428bca; /* mau nen */
            border-color: #428bca;
            border-top-left-radius: 4px; /* bo vien tron */
            border-top-right-radius: 4px;
            padding: 10px; /* do cao cua title */
        }

        .fdb-panel-header-15 {
            color: #fff; /* mau chu */
            background-color: #428bca; /* mau nen */
            border-color: #428bca;
            border-top-left-radius: 4px; /* bo vien tron */
            border-top-right-radius: 4px;
            padding: 15px; /* do cao cua title */
        }
    </style>

    <section class="wrapper">
        <br />
        <!---ss PH-->
        <section class="panel">
            <header class="panel-heading">
                <h3>PH - Provide Help Community</h3>
            </header>
            <asp:Panel ID="pnlPH" runat="server">
                <div class="panel-body">
                    <div class="form">
                        <div class="form-group col-lg-12">
                            <div class="col-md-6 col-md-offset-3">
                                <label class="control-label col-lg-7" for="firstname">Available PH Amount: </label>
                                <div class="col-lg-3">
                                    <span class="badge">
                                        <asp:Label runat="server" ID="lblRemainAmount">180</asp:Label>
                                        USD
                                </span>

                                    &nbsp;<i class="fa fa-usd" aria-hidden="true"></i>
                                </div>


                            </div>

                            <div class="col-md-6 col-md-offset-3 margin-top-05">
                                <label class="control-label col-lg-7">Password PIN:</label>
                                <div class="col-lg-5">
                                    <asp:TextBox runat="server" ID="txtTransPass" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ErrorMessage="Enter password PIN" ControlToValidate="txtTransPass" runat="server" ForeColor="#cc0066" Text="Enter password PIN" Display="Dynamic" ValidationGroup="createPH" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-lg-12">
                            <div style="text-align: center;" class="col-lg-12">
                                <asp:Button runat="server" ID="btnCreatePH" class="btn btn-info" Text="Create PH" OnClick="btnCreatePH_Click" ValidationGroup="createPH" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </section>
        <!---End Of ss PH-->
        <!--ss Gridview PH-->
        <section class="panel">
            <asp:DataList ID="grdCMD" runat="server" class="table table-hover p-table">
                <HeaderTemplate>
                    <table class="table table-hover p-table">
                        <tr>
                            <th>No.</th>
                            <th>PH Time</th>
                            <th>Amount</th>
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
                            <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate" , "{0:dd/MM/yyyy HH:mm}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount").ToString().Substring(0,5) %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString((int)Eval("Status")) %>' CssClass='<%# CssStatus((int)Eval("Status")) %>' />
                        </td>
                        <td>
                            <a href="#">
                                <asp:LinkButton runat="server" ID="btnDetail" Visible='<%# VisibleDetailButton((int)Eval("ID")) %>' type="submit" class="btn btn-success" Text="Detail" CommandArgument='<%# Eval("ID") %>' OnClick="btnDetail_Click" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
               
                </FooterTemplate>
            </asp:DataList>

            <%--<asp:GridView ID="grdPH" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="50" OnRowCommand="grdPH_OnRowCommand"
                    OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-hover p-table" UseAccessibleHeader="true" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PH Time" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString((int)Eval("Status")) %>' CssClass='<%# CssStatus((int)Eval("Status")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDetail" type="submit" class="btn btn-success" Text="Details" CommandArgument='<%# Eval("ID") %>' CommandName="CmdDetail" Visible='<%# VisibleDetailButton((int)Eval("ID")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>
        </section>
        <!--end of ss Gridview PH-->
    </section>


</asp:Content>
