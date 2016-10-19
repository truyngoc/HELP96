using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Common;
using BIT.Controller;
using System.Text;

namespace BIT.WebUI.Admin
{
    public partial class ConfirmPH : System.Web.UI.Page
    {
        public int COMMAND_DETAIL_ID
        {
            get
            {
                return (int)ViewState["COMMAND_DETAIL_ID"];
            }
            set
            {
                ViewState["COMMAND_DETAIL_ID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
                else
                {
                    if (Session["PH_DETAIL_COMMAND_DETAIL_ID"] != null)
                    {
                        LoadDataToForm();
                        Session["PH_DETAIL_COMMAND_DETAIL_ID"] = null;
                    }
                    else
                    {
                        //Response.Redirect("PH_DETAIL");
                        btnConfirmPH.Enabled = false;
                        //TNotify.Toastr.Information("Your session working is expired, back to PH detail for continue", "Notify", TNotify.NotifyPositions.toast_top_full_width, true);
                    }
                }
            }
        }

        public void LoadDataToForm()
        {
            if (Session["PH_DETAIL_COMMAND_DETAIL_ID"] != null)
            {
                var ctlCmdDetail = new COMMAND_DETAIL_BC();
                var ctlMem = new MEMBERS_BC();
                int CMD_DETAIL_ID = Convert.ToInt32(Session["PH_DETAIL_COMMAND_DETAIL_ID"]);

                this.COMMAND_DETAIL_ID = CMD_DETAIL_ID;
                // lay command detail ID
                COMMAND_DETAIL cmdDetail = ctlCmdDetail.SelectItem(CMD_DETAIL_ID);
                MEMBERS member = ctlMem.SelectItem(cmdDetail.CodeId_To);

                

                if (!string.IsNullOrEmpty(member.Wallet))
                {
                    imgGHWallet.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}", member.Wallet.Trim()).Trim();
                    lblGHWallet.Text = "Address: " + member.Wallet;
                }
                else
                {
                    lblGHWallet.Text = string.Empty;
                    btnConfirmPH.Enabled = false;
                    TNotify.Alerts.Warning("GH account have to update wallet address on profile information", true);
                }

                txtTotalAmount.Text = ((decimal)cmdDetail.Amount).ToString("0.#####");
            }
        }

        protected void btnConfirmPH_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var ctlMember = new MEMBERS_BC();

                string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;


                // check so luong PIn it nhat 1 moi dc confirm
                var oWallet = Singleton<WALLET_BC>.Inst.SelectItemByCodeId(codeId);
                if (oWallet.PIN_Wallet > 1)
                {
                    string passPIN = txtPasswordPIN.Text;
                    if (ctlMember.CheckPasswordPIN(codeId, passPIN))
                    {
                        var ctlCommandDetail = new COMMAND_DETAIL_BC();
                        COMMAND_DETAIL obj = ctlCommandDetail.SelectItem(COMMAND_DETAIL_ID);
                        try
                        {
                            COMMAND_DETAIL CMD = new COMMAND_DETAIL { ID = COMMAND_DETAIL_ID, TransactionId = txtTransaction.Text, ConfirmPH = true, DateConfirmPH = DateTime.Now, Status = (int)Constants.COMMAND_STATUS.PH_Success, CodeId_From = obj.CodeId_From, CodeId_To = obj.CodeId_To };
                            ctlCommandDetail.ConfirmPH(CMD);

                            TNotify.Toastr.Success("Confirm PH successfull", "Confirm PH", TNotify.NotifyPositions.toast_top_full_width, true);

                            SendMailToRECEIVER(CMD);
                            Response.Redirect("PH_DETAIL.aspx");
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                            // C2: catch exception nay khi redirect
                        }
                        catch (Exception ex)
                        {
                            TNotify.Alerts.Danger(ex.ToString(), true);
                        }
                    }
                    else
                    {
                        // thong bao password pin ko dung
                        TNotify.Alerts.Warning("Password PIN is not valid", true);
                    }
                }
                else
                {
                    btnConfirmPH.Enabled = false;
                    TNotify.Alerts.Warning("You not enough PIN for confirm PH (at least 2 PIN)", true);
                }
            }

        }

        public void SendMailToRECEIVER(COMMAND_DETAIL command)
        {
            var ctlMem = new MEMBERS_BC();
            var userFrom = ctlMem.SelectItem(command.CodeId_From);
            var userTo = ctlMem.SelectItem(command.CodeId_To);

            string sSubject = "THÔNG BÁO TỪ HELP96.GLOBAL";

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head></head>");
            strBuilder.Append("<body>");
            strBuilder.Append("<table>");
            strBuilder.AppendLine("<tr><td><b>Xin chào bạn  " + userFrom.Username + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Chào mừng bạn đến với cộng đồng HELP96.GLOBAL </b><br/></td></tr></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Lệnh GH của tài khoản: " + userTo.Username + "/" + userTo.Phone + " đã được duyệt. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Số lượng: " + command.Amount.ToString() + " USD </b><br/></td></tr>");
            strBuilder.AppendLine("<b><a href='http://help96.org'>http://help96.org </a></b><br/>");
            strBuilder.AppendLine("<tr><td><b>Trong quá trình sử dụng nếu có vướng mắc, bạn hãy liên hệ với người bảo trợ hoặc ban truyền thông để được hỗ trợ. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Xin cảm ơn và chúc thành công.</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/>HELP96.GLOBAL</b><br/></td></tr>");
            strBuilder.Append("</table>");
            strBuilder.Append("</body>");
            strBuilder.Append("</html>");

            strBuilder.Append("</html>");

            Mail.Send(userTo.Email, sSubject, strBuilder.ToString());
        }
    }
}