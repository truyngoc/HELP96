using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Common;
using BIT.Controller;
using BIT.Objects;

namespace BIT.WebUI.Admin
{
    public partial class MemberManagement : System.Web.UI.Page
    {
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
                    try
                    {
                        if ((Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0") || (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "009"))
                        {
                            LoadAllAcc();
                        }
                        else
                        {
                            Response.Redirect("~/Admin/Login.aspx");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("~/Admin/Login.aspx");
                        throw;
                    }

                }
            }
        }

        public void LoadAllAcc()
        {
            var user_name = txtUserName.Text.Trim();
            var ctlMem = new MEMBERS_BC();
            var lstMem = ctlMem.SearchItemByUserName(user_name);

            grdMEMBERS.DataSource = lstMem;
            grdMEMBERS.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllAcc();
        }

        protected void grdMEMBERS_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            var ctlMem = new MEMBERS_BC();
            switch (e.CommandName)
            {
                case "lnkWallet":
                    //LinkButton btn = (LinkButton)(sender);
                    //string yourValue = btn.CommandArgument;

                    string url = string.Format("{0}", e.CommandArgument);
                    string s = "window.open('" + url + "', 'popup_window');";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    break;
                case "cmdEdit":
                    HttpContext.Current.Session["BIT_MemberID_Edit"] = e.CommandArgument;

                    Response.Redirect("~/Admin/EditAccount.aspx");
                    break;
                case "cmdDelete":
                    ctlMem.DeleteItem(Convert.ToInt32(e.CommandArgument));
                    LoadAllAcc();

                    break;
                case "cmdLock":
                    ctlMem.LockAccount(Convert.ToInt32(e.CommandArgument));
                    LoadAllAcc();
                    break;
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMEMBERS.PageIndex = e.NewPageIndex;
            LoadAllAcc();
        }

        public string StatusToString(int status)
        {
            switch (status)
            {
                case 0:
                    return "Wait active";
                case 1:
                    return "Actived";
                case 2:
                    return "Running";
                case 3:
                    return "Blocked";
                default:
                    return "";
            }
        }
        protected void lnkBlockchain_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            string url = string.Format("{0}", yourValue);
            string s = "window.open('" + url + "', 'popup_window');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}