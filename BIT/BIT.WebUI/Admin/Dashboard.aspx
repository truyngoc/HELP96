<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BIT.WebUI.Admin.Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Fill Form in Popup" />
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1"
        CancelControlID="Button2" BackgroundCssClass="Background">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 350px; height: 300px;" id="irm1" src="Promotion.aspx" runat="server"></iframe>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Close" />
    </asp:Panel>


    <div style="clear: both;"></div>
    <div class="label_b" style="padding: 25px 0;">
        <div class="row state-overview">
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="symbol">
                            <img src="../images/c.png" />
                        </div>
                        <div class="value">
                            <p>C Wallet</p>
                            <h1 class="count">
                                <asp:Label ID="lblC_Wallet" runat="server" />
                                BTC
                            </h1>

                        </div>
                    </section>
                </div>
            </div>

            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="symbol">
                            <img src="../images/pin.png" />
                        </div>
                        <div class="value">
                            <p>Pin</p>
                            <h1 class="count">
                                <asp:Label ID="lblPIN_Wallet" runat="server" />
                            </h1>
                        </div>
                    </section>
                </div>
            </div>

            <div class="col-lg-3 col-sm-6">
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
            </div>
        </div>
        <!--state overview end-->

        <!--state overview start-->
        <div class="row state-overview">
            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="symbol">
                            <img src="../images/PD.png" />
                        </div>
                        <div class="value">
                            <p>Total PH</p>
                            <h1 class="count">
                                <asp:Label ID="lblTotalPH" runat="server" />
                            </h1>

                        </div>
                    </section>
                </div>
            </div>

            <div class="col-lg-3 col-sm-6">
                <div class="flip">
                    <section class="panel front divdashboard">
                        <div class="symbol">
                            <img src="../images/GD.png" />
                        </div>
                        <div class="value">
                            <p>Total GH</p>
                            <h1 class="count">
                                <asp:Label ID="lblTotalGH" runat="server" />
                            </h1>
                        </div>
                    </section>
                </div>
            </div>
        </div>

        <div class="row state-overview infor_b">
            <div class="col-lg-8 col-sm-6">
                <section class="panel front divdashboard">
                    <div class="panel-heading">
                        <strong>NOTIFICATION FOR SEPTEMPER</strong>
                    </div>
                    <%--<div class="panel-body">
                        Dear BitQuick24 Community,<br/>
                        <br/>
                        Thank you for choosing to join in BitQuick24, wish you all quickly go forward to SUSTAINABILITY PROSPEROUSNESS with BitQuick24.<br/>
                        It has been 4 month (exactly 12 months, because it took us 6 months for preparation, 2 months for market fund), with many difficulties both objective and subjective; what a joy and privilege when we can declare: BitQuick24 overcame Phase One, SCREENING Phase, the most difficult Phase of most of similar financial models.<br/>
                        To prepare for Phase Two &ndash; PLATFORM, we will deploy some updates toward a KNOWLEDGEABLE, ACTIVE, &amp; RESPONSIBLE community:
                        <br/>
                        -          Promotional program supports interlacedly, as a deserved reward for Leaders and active members in community.<br/>
                        -          Activating ID: To activate new ID, members must have at least 06 PIN. Leaders have the sense of initiative in managing PIN. We will limit scattered apportion littering community.
                        <br/>
                        -          Mananging CREATE PD Mechanism: Three continuous months if you can't introduce the new member join our BitQuick24 community, your Create PD function will be de-active in the following month. To re-active this function (opening the following month), simply just introduce at minimum 1 new member. Managing CREATE PD Mechanism will ensure fairness for Leaders, active members. There will no place for lazy investors because the PD-GD nature does not contribute to help individual and community grow.<br>
                        -          Utility:<br />
                        o   Reinforce account security with Capcha 2 steps<br/>
                        o   Integrate SMS &amp; Email Marketing<br/>
                        We are quite excited with the next developing journey of BitQuick24, and hope we can contribute some effort to your success, your team, and of BitQuick24 community.<br/>
                        Be with us to write a historial story, formation, development and  everlasting of an outstanding financial playground  out&ndash; BitQuick24. And apparently, in the historial story of BitQuick24 will always have your sucessful and prosperous picture.<br/>
                        TEAM &ndash; Together Everyone Achieve More<br/>
                        Thanks, we love you, love your team &amp; our community!<br/>
                        BitQuick24.
			<p></p>

                    </div>--%>
                </section>
            </div>
            <div class="col-lg-4 col-sm-6">
                <section class="panel front divdashboard">
                    <div class="panel-heading">
                        <strong>NOTIFICATION FOR AUGUST</strong>
                    </div>
                    <%--<div class="panel-body">
                        <p>
                            Hello members!<br/>
                            Currently the amount PD - GD went into a stable process. To fit the sustainable development of BitQuick24 we gift for you is 6 days waiting for command activated automatic PIN instead of 9 days as before.<br/>
                            We thank you for accompanying us during the past!<br/>
                        </p>

                    </div>--%>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
