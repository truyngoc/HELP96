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
    public partial class GHCommunity : System.Web.UI.Page
    {
        private GH_BC ctlGH = new GH_BC();
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
                    string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;

                    // load list GH
                    this.LoadListGH();
                   
                }
            }   
        }

        private void LoadListGH()
        {
            
            string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;

            var lstGH = ctlGH.SelectItemsByCodeId(codeId);

            grdCMD.DataSource = lstGH;
            grdCMD.DataBind();
        }

        public string StatusToString(int status)
        {
            switch (status)
            {
                case (int)Constants.GH_STATUS.Waiting:
                    return Constants.GH_STATUS.Waiting.ToString();
                case (int)Constants.GH_STATUS.Pending:
                    return Constants.GH_STATUS.Pending.ToString();
                case (int)Constants.GH_STATUS.Success:
                    return Constants.GH_STATUS.Success.ToString();
                case (int)Constants.GH_STATUS.Expired:
                    return Constants.GH_STATUS.Expired.ToString();
                default:
                    return string.Empty;
            }
        }

        public bool VisibleDetailButton(int ID)
        {
            return ctlGH.Check_Visible_DetailButton(ID);
        }

        public string CssStatus(int status)
        {
            switch (status)
            {
                case (int)Constants.GH_STATUS.Waiting:
                    return "label label-primary";
                case (int)Constants.GH_STATUS.Pending:
                    return "label label-info";
                case (int)Constants.GH_STATUS.Success:
                    return "label label-danger";
                default:
                    return "label label-primary";
            }
        }

        public string formatAmount(decimal amount)
        {
            return amount.ToString("0.#####");
        }

        //protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdGH.PageIndex = e.NewPageIndex;
        //    LoadListGH();
        //}

        //protected void grdGH_OnRowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "CmdDetail")
        //    {
        //        int GH_ID = Convert.ToInt32(e.CommandArgument);

        //        Session["GHCommunity_GH_ID"] = GH_ID;

        //        Response.Redirect("GH_DETAIL.aspx");
        //    }
        //}

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            int GH_ID = Convert.ToInt32(btn.CommandArgument);
            Session["GHCommunity_GH_ID"] = GH_ID;

            Response.Redirect("GH_DETAIL.aspx");
        }

    }
}