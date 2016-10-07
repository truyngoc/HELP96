<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="COMMAN_LIST.aspx.cs" Inherits="BIT.WebUI.Admin.COMMAN_LIST" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <!---ss PH-->
        <section class="panel">
            <header class="panel-heading">
                <h3>List Command</h3>
            </header>
            <div class="panel-body">
                <section class="panel">
                    <div class="table-responsive">
                        <asp:GridView ID="grdCommand" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="50"
                            OnPageIndexChanging="grdCommand_OnPageIndexChanging" CssClass="table table-hover p-table" UseAccessibleHeader="true" GridLines="None"
                            OnRowCommand="grdCommand_OnRowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Command code" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCommandCode" runat="server" Text='<%# Eval("CommandCode") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="User Create" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserCreate" runat="server" Text='<%# Eval("UserCreate") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Create date" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateCreate" runat="server" Text='<%# Eval("DateCreate" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                

                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDetail" runat="server" CommandName="cmdDetail" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-primary" Text="DETAIL" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                </section>
            </div>
        </section>
    </section>
</asp:Content>
