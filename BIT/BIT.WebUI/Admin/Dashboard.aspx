<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BIT.WebUI.Admin.Dashboard" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <asp:Button ID="Button1" runat="server" Text="Fill Form in Popup" />
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1"
        CancelControlID="Button2" BackgroundCssClass="Background">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 350px; height: 300px;" id="irm1" src="Promotion.aspx" runat="server"></iframe>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Close" />
    </asp:Panel>--%>

    <div style="clear: both;"></div>
    <div class="label_b" style="padding: 25px 0;">
        <div class="header_function_name">
            <span id="CPMember_ctl00_lb_header_function">HOME HELP96.GLOBAL</span>
        </div>
        <!--state overview start-->
        <div class="row state-overview">
            <div class="col-lg-3 col-sm-6" style="margin: 30px;">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="content_show_home" style="">
                            TOTAL MEMBERS :
                            <asp:Label runat="server" ID="lblTotalDownLine" Style="color: red"></asp:Label>
                            <br />
                            <div style="height: 15px;"></div>
                            TOTAL F1 : 
                            <asp:Label runat="server" ID="lblDirectDownLine" Style="color: red"></asp:Label>
                        </div>
                    </section>
                </div>
            </div>

            <div class="col-lg-3 col-sm-6" style="margin: 30px;">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="content_show_home">
                            PIN :
                            <asp:Label runat="server" ID="lblPIN" Style="color: red"></asp:Label>
                            <br />
                            <div style="height: 15px;"></div>
                            PH : 
                            <asp:Label runat="server" ID="lblPH" Style="color: red"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GH :
                            <asp:Label runat="server" ID="lblGH" Style="color: red"></asp:Label>
                        </div>
                    </section>
                </div>
            </div>

            <div class="col-lg-3 col-sm-6" style="margin: 30px;">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="content_show_home">
                            R WALLET :
                            <asp:Label runat="server" ID="lblRWallet" Style="color: red"></asp:Label>
                            <br />
                            <div style="height: 15px;"></div>
                            C WALLET :
                            <asp:Label runat="server" ID="lblCWallet" Style="color: red"></asp:Label>
                        </div>
                    </section>
                </div>
            </div>

            <%--<div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="symbol">
                            <img src="../images/direct.png" />
                        </div>
                        <div class="value">
                            <p>Direct Downline</p>
                            <h1 class="count">
                                <asp:Label ID="lblDirectDownline" runat="server" />
                            </h1>

                        </div>
                    </section>
                </div>
            </div>

            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="symbol">
                            <img src="../images/total.png" />
                        </div>
                        <div class="value">
                            <p>Total Downline</p>
                            <h1 class="count">
                                <asp:Label ID="lblTotalDownline" runat="server" />
                            </h1>
                        </div>
                    </section>
                </div>
            </div>--%>
        </div>
        <!--state overview end-->

    </div>
</asp:Content>
