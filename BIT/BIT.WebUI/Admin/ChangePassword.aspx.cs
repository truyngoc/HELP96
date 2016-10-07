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
    public partial class ChangePassword : System.Web.UI.Page
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
        public void ChangePass(string CodeId, string oldPassword, string newPassword)
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            if (ctlMember.CheckOldPassword(CodeId, oldPassword))
            {
                ctlMember.ChangePassword(CodeId, newPassword);

                Reset();

                ShowMessageError(lblMessage, "Change password successful", true);
            }
            else
            {
                ShowMessageError(lblMessage, "Old password is not valid", true);
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
                    string oldPassword = txtOldPassword.Text;
                    string newPassword = txtNewPassword.Text;

                    ChangePass(CodeId, oldPassword, newPassword);
                }
                catch (Exception ex)
                {
                    ShowMessageError(lblMessage, ex.ToString(), true);
                }
            }
        }
    }
}