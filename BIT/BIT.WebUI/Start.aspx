<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="BIT.WebUI.Start" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #vision, #register, header {
            display: none;
        }
    </style>
    <div id="start">
        <h3 class="mid title_white" style="font-size: 40px!important">HOW TO START</h3>
        <div class="container">
            <div class="col-lg-12">
                <div class="col-lg-4">
                    <div class="iconstep mid">
                        <img src="https://bitsun.org/home/images/step1.png">
                        <h4>Step 1</h4>
                        <p class="text-center">To start cooperation, please register an account. It does not take much time and will require you to a minimum of information.</p>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="iconstep mid">
                        <img src="https://bitsun.org/home/images/step2.png">
                        <h4>Step 2</h4>
                        <p class="text-center">Sign in to your account to buy Pin. Enter an amount of PD and the system will automatically generate interest rate for you</p>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="iconstep mid">
                        <img src="https://bitsun.org/home/images/step3.png">
                        <h4>Step 3</h4>
                        <p class="text-center">Your profit is accrued on everyday. This means that after you finished step 2 have made a deposit you can see the first profits. The next and all following income will also accrue at an interval of 15 days.</p>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="iconstep mid">
                        <img src="https://bitsun.org/home/images/step4.png">
                        <h4>Step 4</h4>
                        <p class="text-center">When Receiving the notification from the system, you will transfer the amount of money follow the transaction list of the system, and then send the image of your transfer on confirm button.</p>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="iconstep mid">
                        <img src="https://bitsun.org/home/images/step5.png">
                        <h4>Step 5</h4>
                        <p class="text-center">Establishing the withdrawal order after the transaction is confirmed in step 4.</p>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="iconstep mid">
                        <img src="https://bitsun.org/home/images/step6.png">
                        <h4>Step 6</h4>
                        <p class="text-center">The system is automatic matched. You will be received the transaction list notification that transfers money for you. After you received money, you need to confirm with us about that.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
