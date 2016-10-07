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
    public partial class Memberprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login");
                }
                else
                {
                    //TNotify.Alerts.Danger("what up?", true);

                    //TNotify.Toastr.Information("Whats up", "Notify", TNotify.NotifyPositions.toast_top_full_width, true);
                    //LoadUserInfor();

                    txtUserName.Attributes.Add("readonly", "readonly");
                    txtEmail.Attributes.Add("readonly", "readonly");
                    txtSysWallet.Attributes.Add("readonly", "readonly");
                }
            }
        }

        public void LoadUserInfor()
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            MEMBERS obj = ctlMember.SelectItem(Singleton<BITCurrentSession>.Inst.SessionMember.ID);

            txtUserName.Text = obj.Username;
            txtEmail.Text = obj.Email;
            txtFullName.Text = obj.Fullname;
            txtPhone.Text = obj.Phone;
            txtWallet.Text = obj.Wallet;
            //txtSysWallet.Text = obj.Sys_Wallet;
            lnkSendMail.Text = "Click here to receive Transaction password via email: " + obj.Email;
        }

        public MEMBERS GetDataOnForm()
        {
            MEMBERS obj = new MEMBERS();

            obj.CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
            obj.Fullname = txtFullName.Text.Trim();
            obj.Phone = txtPhone.Text.Trim();
            obj.Wallet = txtWallet.Text.Trim();
            obj.Password_PIN = txtPasswordPIN.Text.Trim();
            return obj;
        }

        public void UpdateProfile()
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            MEMBERS obj = GetDataOnForm();

            //Tung: Them doan check Password 2
            if (obj.Password_PIN == Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
            {
                ctlMember.UpdateItem(obj);
                ShowMessageError(lblMessage, "Update profile member successful", true);
            }
            else
            {
                ShowMessageError(lblMessage, "Password PIN is invalid! ", true);
            }
            

            
        }

        public void ReloadSeasion()
        {            
            var login_info = Singleton<MEMBERS_BC>.Inst.SelectItemByUserName(txtUserName.Text);

            if (login_info != null)
            {
                Singleton<BITCurrentSession>.Inst.SessionMember = login_info;
            }
        }

        public void ShowMessageError(Label lblMsgErr, string sMsgErr = "", bool bVisible = false)
        {
            lblMsgErr.Text = sMsgErr;
            lblMsgErr.Visible = bVisible;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    UpdateProfile();

                    ReloadSeasion();
                }
                catch (Exception ex)
                {
                    ShowMessageError(lblMessage, ex.ToString(), true);
                }
            }
        }
        protected void lnkSendMail_Click(object sender, EventArgs e)
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            MEMBERS obj = ctlMember.SelectItem(Singleton<BITCurrentSession>.Inst.SessionMember.ID);
            SendMailToRegisterUser(obj.Username, obj.Fullname, obj.Password_PIN, obj.Email);
        }

        #region "Mail"

        public void SendMailToRegisterUser(string username, string fullname, string passwordPIN, string mailto)
        {
            string sSubject = "BITQUICK24 INFORMATON ACCOUNT";

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head></head>");
            strBuilder.Append("<body>");
            strBuilder.Append("<table>");
            strBuilder.AppendLine("<tr><td><b>Hello  " + fullname + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Welcome to BITQUICK24 family. </b><br/></td></tr></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your username is: " + username + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your transaction password: " + passwordPIN + " </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Please change the transaction password after first login of you to secure your account. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Please contact to your upline or  BITQUICK24's support to support you everything. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/>BITQUICK24</b><br/></td></tr>");
            strBuilder.Append("</table>");
            strBuilder.Append("</body>");
            strBuilder.Append("</html>");

            Mail.Send(mailto, sSubject, strBuilder.ToString());
        }

        #endregion
    }
}