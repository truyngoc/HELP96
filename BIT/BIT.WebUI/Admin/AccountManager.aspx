<%@ Page Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="AccountManager.aspx.cs" Inherits="BIT.WebUI.Admin.AccountManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .rounded_corners {
            /*border: 1px solid #A1DCF2;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
            overflow: hidden;*/
        }

            .rounded_corners td, .rounded_corners th {
                border: 1px solid #A1DCF2;
                font-family: Arial;
                font-size: 15pt;
                /*text-align: center;*/
                padding: 5px;
            }

            .rounded_corners table table td {
                border-style: none;
            }
    </style>


    <section class="wrapper">
        <br />
        <section class="panel">
            <header class="panel-heading">
                <h3>ACCOUNT MANAGER</h3>
            </header>
            <div class="panel-body">
                <div class="row">
                    <label class="control-label col-md-2">Username: </label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />
                    </div>
                    <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info" BackColor="#3F51B5" Text="Search" OnClick="btnSearch_Click" />
                </div>
                <br />
                <div class="form">
                    <div class="rounded_corners">
                        <asp:GridView ID="grdMEMBERS" runat="server" HeaderStyle-BackColor="#3AC0F2" Font-Size="XX-Large" Font-Bold="true"
                            HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                            RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" AllowPaging="true" PageSize="30"
                            OnPageIndexChanging="OnPageIndexChanging" OnRowCommand="grdMEMBERS_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Username" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                               

                                <asp:TemplateField HeaderText="Fullname" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFullname" runat="server" Text='<%# Eval("Fullname") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Phone" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Wallet" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWallet" runat="server" Text='<%# Eval("Wallet") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="Sys_Wallet" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSys_Wallet" runat="server" Text='<%# Eval("Sys_Wallet") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="CreateDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString(Convert.ToInt32(Eval("Status"))) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" runat="server" CausesValidation="false" CommandName="cmdEdit"
                                            CommandArgument='<%# Eval("ID") %>' ImageUrl="/Images/edit-icon.png" ToolTip="Edit" Width="16" Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDelete" runat="server" CausesValidation="false" CommandName="cmdDelete"
                                            CommandArgument='<%# Eval("ID") %>' ImageUrl="/Images/delete-icon.png" ToolTip="Delete"  Width="16" Height="16" 
                                            OnClientClick="return confirm('Are you sure you want delete ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnLock" runat="server" CausesValidation="false" CommandName="cmdLock"
                                            CommandArgument='<%# Eval("ID") %>' ImageUrl="/Images/key-icon.png" ToolTip="Lock account"  Width="16" Height="16"
                                            OnClientClick="return confirm('Are you sure you want lock account ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </section>
    </section>
</asp:Content>

