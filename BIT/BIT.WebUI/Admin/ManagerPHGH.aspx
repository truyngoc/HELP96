
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="ManagerPHGH.aspx.cs" Inherits="BIT.WebUI.Admin.ManagerPHGH" %>

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
                <div class="row">
                    <div class="col-md-12">
                        <asp:CheckBoxList ID="cblStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cblStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="" Selected="True">&nbsp;&nbsp;ALL&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="0">&nbsp;&nbsp;PENDING&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="1">&nbsp;&nbsp;PH_SUCCESS&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">&nbsp;&nbsp;SUCCESS&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="3">&nbsp;&nbsp;EXPIRED&nbsp;&nbsp;</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
                <section class="panel">


                    <div class="table-responsive">
                        <asp:GridView ID="grdCommandDetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="50"
                            OnPageIndexChanging="grdCommandDetails_OnPageIndexChanging" CssClass="table table-hover p-table" UseAccessibleHeader="true" GridLines="None">
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

                                <asp:TemplateField HeaderText="Receiver" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# AccountBriefInfoByCodeId(Eval("CodeId_To").ToString()) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Create date" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("DateCreate" , "{0:dd/MM/yyyy HH:mm}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount").ToString().Substring(0,5) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# StatusToString((int)Eval("Status")) %>' CssClass='<%# CssStatus((int)Eval("Status")) %>' />
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

