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

            if (Quota < 0)
            {
                TNotify.Alerts.Success("Bạn không đủ F1 mới để rút tiền hoa hồng hệ thống", true);
            }
            else
            {
                switch (Singleton<BITCurrentSession>.Inst.SessionMember.Level)
                {
                    case "0":
                        {
                            TNotify.Alerts.Danger("Bạn phải đạt cấp V1 để rút hoa hồng hệ thống", true);
                            break;
                        }
                    case "1":
                        if (Quota >= 240)
                        {
                            lblQuota.Text = "0";
                            break;
                        }
                        else
                        {
                            lblQuota.Text = (240 - Quota).ToString();
                            break;
                        }
                    case "2":
                        if (Quota >= 480)
                        {
                            lblQuota.Text = "0";
                            break;
                        }
                        else
                        {
                            lblQuota.Text = (480 - Quota).ToString();
                            break;
                        }
                    case "3":
                        if (Quota >= 960)
                        {
                            lblQuota.Text = "0";
                            break;
                        }
                        else
                        {
                            lblQuota.Text = (960 - Quota).ToString();
                            break;
                        }
                    case "4":
                        if (Quota >= 4800)
                        {
                            lblQuota.Text = "0";
                            break;
                        }
                        else
                        {
                            lblQuota.Text = (4800 - Quota).ToString();
                            break;
                        }
                    case "5":
                        if (Quota >= 9600)
                        {
                            lblQuota.Text = "0";
                            break;
                        }
                        else
                        {
                            lblQuota.Text = (9600 - Quota).ToString();
                            break;
                        }
                    default:
                        {
                            lblQuota.Text = "0";
                            break;
                        }
                }

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
            try
            {
                lblCWalletAmt.Text = userWallet.C_Wallet.ToString().Substring(0,userWallet.C_Wallet.ToString().IndexOf("."));
            }
            catch (Exception)
            {
                
                throw;
            }
            
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
                //CHECK PIN
                
                decimal pin = Decimal.Parse(Singleton<WALLET_BC>.Inst.SelectItemByCodeId(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId).PIN_Wallet.ToString());
                switch (Singleton<BITCurrentSession>.Inst.SessionMember.Level)
                {
                    case "1":
                        {
                            if (pin<3)
                            {
                                TNotify.Toastr.Error("Rút tiền mất 1 PIN, bạn cần ít nhất 3 PIN trong tài khoản.");
                                return;
                            }
                            break;
                        }
                    case "2":
                        if (pin<4)
                            {
                                TNotify.Toastr.Error("Rút tiền mất 2 PIN, bạn cần ít nhất 4 PIN.");
                                return;
                            }
                            break;
                    case "3":
                        if (pin<5)
                            {
                                TNotify.Toastr.Error("Rút tiền mất 3 PIN, bạn cần ít nhất 5 PIN.");
                                return;
                            }
                            break;
                    case "4":
                        if (pin<8)
                            {
                                TNotify.Toastr.Error("Rút tiền mất 6 PIN, bạn cần ít nhất 8 PIN.");
                                return;
                            }
                            break;
                    case "5":
                        if (pin<12)
                            {
                                TNotify.Toastr.Error("Rút tiền mất 10 PIN, bạn cần ít nhất 12 PIN.");
                                return;
                            }
                            break;

                    default:
                        break;
                }
                decimal withdrawAmount = 0;
                //check dieu kien
                if (txtAmount.Text != string.Empty)
                {
                    withdrawAmount = decimal.Parse(txtAmount.Text);
                    if (withdrawAmount > decimal.Parse(lblCWalletAmt.Text))
                    {
                        TNotify.Toastr.Error("Bạn không còn đủ " + lblCWalletAmt.Text + " USD để rút.");
                        return;
                    }
                }
                else
                {
                    TNotify.Toastr.Error("Số tiền rút không hợp lệ");
                    return;
                }
                if (txtPin2.Text != Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
                {
                    TNotify.Toastr.Error("Mật khẩu giao dịch không đúng.");
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
                TNotify.Toastr.Success("Đặt lệnh rút tiền thành công");
                Response.Redirect("../Admin/Withdraw.aspx");
            }
            catch 
            {
                TNotify.Toastr.Error("Số tiền rút phải là số nguyên");
            }
        }
    }
}