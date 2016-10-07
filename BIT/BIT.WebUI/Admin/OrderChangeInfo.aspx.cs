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
    public partial class OrderChangeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                {
                    LoadAllAcc();
                }
                else
                {
                    LoadMember();
                    sessionSearch.Visible = false;
                }

            }
        }

        public void LoadAllAcc()
        {
            var user_name = txtUsername.Text.Trim();
            var ctlMem = new MEMBERS_BC();
            var lstMem = ctlMem.SearchItemByUserName_ADMIN(user_name);

            grdMembers.DataSource = lstMem;
            grdMembers.DataBind();
        }

        public void LoadMember()
        {
            var ctlMem = new MEMBERS_BC();
            var lstMem = ctlMem.SearchItemByUserName_EDIT(Singleton<BITCurrentSession>.Inst.SessionMember.Username);

            grdMembers.DataSource = lstMem;
            grdMembers.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string UserName = btn.CommandArgument;

                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                {
                    //UPDATE STATUS MEMBER_EDIT AND UPDATE MEMBER INFORMATION
                    Singleton<MEMBERS_BC>.Inst.UpdateMember_Edit(UserName);
                    TNotify.Alerts.Success("Edit information succsess");
                }
                else
                {
                    //UPDATE STATUS MEMBER_EDIT
                    Singleton<MEMBERS_BC>.Inst.UpdateStatusMember_Edit(UserName);
                    TNotify.Alerts.Success("Confirm order edit information succsess");
                }

                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                TNotify.Alerts.Danger(ex.ToString(),true);
                throw;
            }
        }

        public bool ShowConfirm(string upline,string STA)
        {
            if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
            {
                if (STA == "2")
                {
                    return false;
                }
                else
                    return true;
            }
            else if (Singleton<BITCurrentSession>.Inst.SessionMember.Username == upline)
                if (STA == "0")
                    return true;
                else
                    return false;
            else
            {
                return false;
            }
        }
        public string getStatus(string STA)
        {
            string restring = string.Empty;
            switch (STA)
            {
                case "0":
                    restring = "Waiting Upline Confirm";
                    break;
                case "1":
                    restring = "Waiting BitQuick Confirm";
                    break;
                case "2":
                    restring = "Success";
                    break;
            }
            return restring;
        }

        protected void lnkTransaction_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            string url = string.Format("https://blockchain.info/address/{0}", yourValue);
            string s = "window.open('" + url + "', 'popup_window');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllAcc();
        }

    }
}