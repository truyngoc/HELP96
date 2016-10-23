<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="ManagerPHGH.aspx.cs" Inherits="BIT.WebUI.Admin.ManagerPHGH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <br />
        <!---ss PH-->
        <section class="panel">
            <header class="panel-heading">
                <h3>Danh sách lệnh</h3>
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
                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Tìm" OnClick="btnSearch_Click" />
                    </div>
                </div>
                <section class="panel">


                    <div class="table-responsive">
                        <asp:GridView ID="grdCommandDetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="100000"
                            OnPageIndexChanging="grdCommandDetails_OnPageIndexChanging" CssClass="table table-hover p-table" UseAccessibleHeader="true" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PH" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSender" runat="server" Text='<%# AccountBriefInfoByCodeId(Eval("CodeId_From").ToString()) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="GH" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# AccountBriefInfoByCodeId(Eval("CodeId_To").ToString()) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ngày tạo" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("DateCreate" , "{0:dd/MM/yyyy HH:mm}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="USD" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount").ToString().Substring(0,3) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Còn lại" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWaitting" runat="server" Text='<%# showTimeRemaining((DateTime)Eval("DateCreate"),(int)Eval("Status")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Trạng thái" ItemStyle-HorizontalAlign="Left">
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

