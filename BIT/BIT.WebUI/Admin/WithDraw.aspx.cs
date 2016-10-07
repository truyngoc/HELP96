using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Net;
using System.Text;

using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class WithDraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId != "0")
                {
                    getCWalletAmount();
                    LoadAmountWithDraw();
                    bindDataList();
                }
                else
                {
                    Response.Redirect("~/Admin/WithdrawAdmin.aspx");
                }
            }
        }

        public void LoadAmountWithDraw()
        {
            int Quota = Singleton<WITHDRAW_BC>.Inst.GetQuotaWithDraw(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            switch (Singleton<BITCurrentSession>.Inst.SessionMember.Level)
            {
                case "0": 
                    txtAmount.Text = "0.3";
                    lblQuota.Text = (1.5 - Quota).ToString();
                    break;
                case "1":
                    txtAmount.Text = "0.3";
                    lblQuota.Text = (1.5 - Quota).ToString();
                    break;
                case "2":
                    txtAmount.Text = "0.5";
                    lblQuota.Text = (15 - Quota).ToString();
                    break;
                case "3":
                    txtAmount.Text = "1";
                    lblQuota.Text = (30 - Quota).ToString();
                    break;
                case "4":
                    txtAmount.Text = "1.3";
                    lblQuota.Text = (40 - Quota).ToString();
                    break;
                case "5":
                    txtAmount.Text = "1.5";
                    lblQuota.Text = (50 - Quota).ToString();
                    break;
                default:
                    break;
            }
            

        }
        public string getGHStatus(object status)
        {
            string ghStatus = string.Empty;
            if (status.ToString() == "1")
                ghStatus = "Success";
            else
                ghStatus = "Pending";
            return ghStatus;
        }

        public void getCWalletAmount()
        {
            WALLET userWallet = Singleton<WALLET_BC>.Inst.SelectItemByCodeId(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            lblCWalletAmt.Text = userWallet.C_Wallet.ToString();
        }

        public void bindDataList()
        {
            List<WITHDRAW> lstWD = Singleton<WITHDRAW_BC>.Inst.SelectAllItems(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            dtlWithDraw.DataSource = lstWD;
            dtlWithDraw.DataBind();
        }

        protected void btnWithDraw_Click(object sender, EventArgs e)
        {
            try
            {
                decimal withdrawAmount = 0;
                //check dieu kien
                if (txtAmount.Text != string.Empty)
                {
                    withdrawAmount = Convert.ToDecimal(txtAmount.Text);
                    if (withdrawAmount > Convert.ToDecimal(lblCWalletAmt.Text))
                    {
                        TNotify.Toastr.Warning("Not enought BTC to withdraw !", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                        return;
                    }
                }
                else
                {
                    TNotify.Toastr.Warning("Please input amount withdraw !", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                    return;
                }
                if (txtPin2.Text != Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
                {
                    TNotify.Toastr.Warning("Wrong transaction password", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                    return;
                }

                ////insert into withdraw
                WITHDRAW objWD = new WITHDRAW();
                objWD.CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                objWD.Date_Create = DateTime.Now;
                objWD.Amount = withdrawAmount;
                objWD.Status = 0;
                objWD.TransactionId = string.Empty;
                objWD.Wallet = Singleton<BITCurrentSession>.Inst.SessionMember.Wallet;

                //insert
                Singleton<WITHDRAW_BC>.Inst.InsertItem(objWD);
                TNotify.Toastr.Success("Withdraw Completed ", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                Response.Redirect("../Admin/Withdraw.aspx");
            }
            catch { }
        }
    }
}