using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Common;
using BIT.Objects;
using BIT.Controller;

namespace BIT.WebUI.Admin
{
    public partial class AccountManager : System.Web.UI.Page
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
                { }
                //if (Singleton<BITCurrentSession>.Inst.SessionMember.IsAdmin==1)
                //{
                //    LoadAllAcc(); 
                //}
                //else
                //{
                //    Response.Redirect("~/Admin/Login.aspx");
                //}
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMEMBERS.PageIndex = e.NewPageIndex;
            LoadAllAcc();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllAcc();
        }

        public void LoadAllAcc()
        {
            var user_name = txtUserName.Text.Trim();
            var ctlMem = new MEMBERS_BC();
            var lstMem = ctlMem.SearchItemByUserName(user_name);

            grdMEMBERS.DataSource = lstMem;
            grdMEMBERS.DataBind();
        }

        public string StatusToString(int status)
        {
            switch (status)
            {
                case 0 : 
                     return "Wait active";
                case 1 :
                     return "Actived";
                case 2:
                     return "Running";
                case 3:
                     return "Blocked";
                default:
                     return "";
            }
        }

        protected void grdMEMBERS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var ctlMem = new MEMBERS_BC();
            var iD = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case "cmdEdit":
                    HttpContext.Current.Session["BIT_MemberID_Edit"] = e.CommandArgument;

                    Response.Redirect("~/Admin/EditAccount.aspx");
                    break;
                case "cmdDelete":                    
                    ctlMem.DeleteItem(iD);
                    LoadAllAcc();

                    break;
                case "cmdLock":
                    ctlMem.LockAccount(iD);
                    LoadAllAcc();
                    break;
            }
        }
    }
}