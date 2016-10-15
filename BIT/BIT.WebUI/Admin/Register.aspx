<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BIT.WebUI.Admin.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="wrapper">
        <div class="header_function_name">
            <span id="CPMember_ctl00_lb_header_function">REGISTRATION HELP96.GLOBAL</span>
        </div>
        <br />

        <section class="panel">
            <div class="panel-body">
                <div class="form">
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="SUCCESS" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-12 margin-top-05 Info_Tip_Header">
                        <div style="float: left; padding-right: 10px;">
                            <img alt="" src="../Images/Icon_key.png" />
                        </div>
                        <div style="float: left; margin-top: 3px;">ACCOUNT INFORMATION</div>
                        <div style="float: left; font-size: 12px; color: Red; padding-left: 25px; margin-top: 3px; font-weight: normal;"><span id="CPMember_ctl00_Message_Accouting"></span></div>
                    </div>
                    <%--<div class="col-lg-12">
                        <div class="col-lg-1">
                        </div>
                        <div class="col-lg-11">
                            <asp:Label runat="server"></asp:Label>
                            Đường link đăng ký tài khoản:
                           
                            <asp:LinkButton ID="lblLink" runat="server"></asp:LinkButton>
                        </div>
                    </div>--%>
                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="Username" class="control-label">Username*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Username"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your username" ControlToValidate="txtUserName" runat="server" ForeColor="#cc0066" Text="Enter your username" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="Email" class="control-label">Email*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control email_user" placeholder="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your email" ControlToValidate="txtEmail" runat="server" ForeColor="#cc0066" Text="Enter your email" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email is not valid" ControlToValidate="txtEmail" ForeColor="#cc0066" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="password" class="control-label">Password*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Password" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password" ControlToValidate="txtPassword" runat="server" ForeColor="#cc0066" Text="Enter your password" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="confirm_password" class="control-label">Password Confirm* </label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control" placeholder="Password Confirm" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password confirm" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" Text="Enter your password confirm" Display="Dynamic" />
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" ErrorMessage="Password confirm is not valid" Display="Dynamic"></asp:CompareValidator>
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="password" class="control-label">Transfer Pass*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPassword_PIN" CssClass="form-control" placeholder="Password PIN" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password PIN" ControlToValidate="txtPassword_PIN" runat="server" ForeColor="#cc0066" Text="Enter your password PIN" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="confirm_password" class="control-label">Confir Transfer*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtConfirmPassword_PIN" CssClass="form-control" placeholder="Password PIN Confirm" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your password PIN confirm" ControlToValidate="txtConfirmPassword_PIN" runat="server" ForeColor="#cc0066" Text="Enter your password PIN confirm" Display="Dynamic" />
                            <asp:CompareValidator ID="CompareValidator2" ControlToCompare="txtPassword_PIN" ControlToValidate="txtConfirmPassword_PIN" runat="server" ForeColor="#cc0066" ErrorMessage="Password PIN confirm is not valid" Display="Dynamic"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-lg-12 margin-top-05 Info_Tip_Header">
                        <div style="float: left; padding-right: 10px;">
                            <img alt="" src="../Images/icon_member.png" />
                        </div>
                        <div style="float: left;">PERSONAL INFORMATION</div>
                        <div style="float: left; font-size: 12px; color: Red; padding-left: 25px; font-weight: normal;"><span id="CPMember_ctl00_Message_infomation"></span></div>
                    </div>
                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="firstname" class="control-label">Fullname*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" placeholder="Fullname"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your fullname" ControlToValidate="txtFullName" runat="server" ForeColor="#cc0066" Text="Enter your fullname" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="username" class="control-label">Wallet*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtWallet" CssClass="form-control" placeholder="Wallet"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your wallet" ControlToValidate="txtWallet" runat="server" ForeColor="#cc0066" Text="Enter your wallet" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="phone" class="control-label">Phone number*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" placeholder="Phone number"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your phone number" ControlToValidate="txtPhone" runat="server" ForeColor="#cc0066" Text="Enter your phone number" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="country" class="control-label">Country*</label>
                        </div>
                        <div class="col-lg-5">
                            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your country" ControlToValidate="ddlCountry" runat="server" ForeColor="#cc0066" value="VIET NAM" Display="Dynamic" Enabled="false" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="country" class="control-label">Terms of use</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtTerm" runat="server" TextMode="MultiLine" Width="500px" Height="100px" Text="Registration to Investment Community HELP96 is free! We do insist that you abide by the rules and policies detailed below. If you agree to the terms, please check the 'Agree with terms and conditions' checkbox and press the 'Register' button below.

- Each leader/investor only use 1 ID with verified ID/passport picture.

- By agreeing to these rules, you warrant that you will not break that and commit the consistent, longterm development with us.

- Independent investors, voluntary and self-responsibility for investment funds

- The owners of BITQUICK24 reserve the rich to block, delete any usename which commit the rules above.">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-2">
                            <label for="country" class="control-label">Agree with term and condition</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:CheckBox ID="chk" runat="server" />
                        </div>
                    </div>

                    <div class="col-lg-12 margin-top-05 Info_Tip_Header">
                        <div style="float: left; padding-right: 10px;">
                            <img alt="" src="../Images/Icon_home.png" /></div>
                        <div style="float: left; padding-top: 2px;">BANK INFORMATION</div>
                        <div style="float: left; font-size: 12px; color: Red; padding-left: 25px; font-weight: normal;"><span id="CPMember_ctl00_Span1"></span></div>
                    </div>

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="phone" class="control-label">Account own*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtAcountOwn" CssClass="form-control" placeholder="Account own"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your phone number" ControlToValidate="txtPhone" runat="server" ForeColor="#cc0066" Text="Enter your phone number" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="phone" class="control-label">Account number*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="Account own"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your phone number" ControlToValidate="txtPhone" runat="server" ForeColor="#cc0066" Text="Enter your phone number" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="country" class="control-label">Bank name*</label>
                        </div>
                        <div class="col-lg-5">
                            <asp:DropDownList runat="server" ID="DropDownList1" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your country" ControlToValidate="ddlCountry" runat="server" ForeColor="#cc0066" value="VIET NAM" Display="Dynamic" Enabled="false" />
                        </div>
                    </div>
                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2">
                            <label for="phone" class="control-label">Branch bank*</label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" placeholder="Account own"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter your phone number" ControlToValidate="txtPhone" runat="server" ForeColor="#cc0066" Text="Enter your phone number" Display="Dynamic" />
                        </div>
                    </div>

                     

                    <div class="col-lg-12 margin-top-05">
                        <div class="col-lg-2"></div>
                        <div class="col-lg-2" style="text-align: center;">
                            <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-info" Text="Register" OnClick="btnRegister_Click" />
                        </div>
                        <asp:Label ID="lblUserNameSponsor" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </section>
    </section>


    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(".email_user").change(function () {
            var email = $(this).val();
            var name = email.substring(0, email.lastIndexOf("@"));

            $('.username_user').val(name);
        });

        function getUsername() {

        };

    </script>
</asp:Content>
