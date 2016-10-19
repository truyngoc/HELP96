using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BIT.Objects;
using BIT.Controller;
using BIT.Common;
using System.Text;

namespace BIT.WebUI.Admin
{
    public partial class PIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
                else
                {
                    LoadDataOnForm(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
                }
            }
        }

        #region "Get data on form"

        public PIN_TRANS GetDataOnForm()
        {
            PIN_TRANS obj = new PIN_TRANS();

            obj.From = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
            obj.To = txtUserReceivePIN.Text.Trim();
            obj.Amout = Convert.ToInt32(txtAmount.Text);
            obj.Transaction_Type = Constants.PIN_TRANSACTION_TYPE_SOLD;
            obj.Create_Date = DateTime.Now;

            return obj;
        }

        #endregion

        #region "Load data to form"

        public void LoadDataOnForm(string CodeId)
        {
            ShowPINBalanceOfCurrentUser(CodeId);

            BindPINTransactionHistory(CodeId);
        }

        public void ShowPINBalanceOfCurrentUser(string CodeId)
        {
            WALLET_BC ctlWallet = new WALLET_BC();

            WALLET objWallet = ctlWallet.SelectItemByCodeId(CodeId);

            if (objWallet != null)
            {
                lblPINBalance.Text = objWallet.PIN_Wallet.HasValue ? objWallet.PIN_Wallet.ToString() : "0";
            }
        }

        public void BindPINTransactionHistory(string CodeId)
        {
            PIN_TRANS_BC ctlPIN_TRANS = new PIN_TRANS_BC();
            var lstTRANS = ctlPIN_TRANS.SelectItemsByCodeId(CodeId);

            rptPIN_TRANS.DataSource = lstTRANS;
            rptPIN_TRANS.DataBind();
        }

        #endregion


        #region "Send PIN"

        public void SendPIN()
        {
            MEMBERS_BC ctlMEMBERS = new MEMBERS_BC();
            PIN_TRANS_BC ctlPIN_TRANS = new PIN_TRANS_BC();
            PIN_TRANS obj = GetDataOnForm();

            // check user_to exist
            bool bExistAcc = ctlMEMBERS.IsExistsItem(obj.To);
            if (bExistAcc)
            {
                MEMBERS objMember = ctlMEMBERS.SelectItemByUserName(obj.To);

                obj.To = objMember.CodeId;

                // check PIN balance
                int iPIN_Balance = Convert.ToInt32(lblPINBalance.Text);
                int iPIN_Tranfer = (int)obj.Amout;
                if (iPIN_Balance >= iPIN_Tranfer)
                {
                    // check password PIN
                    if (Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN == txtPassword_PIN.Text)
                    {
                        // send
                        ctlPIN_TRANS.TranferPIN(obj);

                        ResetForm();

                        LoadDataOnForm(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);

                        TNotify.Alerts.Success("Send PIN to "+ txtUserReceivePIN.Text +" success.", true);
                    }
                    else
                    {
                        TNotify.Alerts.Danger("Wrong transaction password", true);
                    }
                }
                else
                {
                    // ko du PIN de giao dich
                    TNotify.Alerts.Danger("Not enough PIN for tranfer", true);
                }
            }
            else
            {
                // acc ko ton tai
                TNotify.Alerts.Danger("Account receive PIN not exist", true);
            }
        }
        public void ResetForm()
        {
            txtUserReceivePIN.Text = string.Empty;
            txtPassword_PIN.Text = string.Empty;
            txtAmount.Text = string.Empty;
        }
        #endregion

        protected void btnSendPIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Page.IsValid)
                {
                    SendPIN();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}