using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class ChangePasswordTwo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
            }
        }

        #region "Change pass"
        public void ChangePass(string CodeId, string oldPasswordPIN, string newPasswordPIN)
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            if (ctlMember.CheckOldPasswordPIN(CodeId, oldPasswordPIN))
            {
                ctlMember.ChangePasswordPIN(CodeId, newPasswordPIN);
                // Tung: Cap nhat bien session
                Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN = newPasswordPIN;

                Reset();

                ShowMessageError(lblMessage, "Change password PIN successful", true);
            }
            else
            {
                ShowMessageError(lblMessage, "Old password PIN is not valid", true);
            }
        }
        public void ShowMessageError(Label lblMsgErr, string sMsgErr = "", bool bVisible = false)
        {
            lblMsgErr.Text = sMsgErr;
            lblMsgErr.Visible = bVisible;
        }

        public void Reset()
        {
            txtOldPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmNewPassword.Text = string.Empty;
        }

        #endregion

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                    string oldPasswordPIN = txtOldPassword.Text;
                    string newPasswordPIN = txtNewPassword.Text;

                    ChangePass(CodeId, oldPasswordPIN, newPasswordPIN);
                }
                catch (Exception ex)
                {
                    ShowMessageError(lblMessage, ex.ToString(), true);
                }
            }
        }
    }
}