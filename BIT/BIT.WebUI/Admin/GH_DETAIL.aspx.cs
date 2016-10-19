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
    public partial class GH_DETAIL : System.Web.UI.Page
    {
        #region "Load data"
        public List<MEMBERS> LIST_MEMBERS
        {
            get
            {
                if (HttpContext.Current.Session["GH_DETAIL_LIST_MEMBERS"] != null)
                {
                    return HttpContext.Current.Session["GH_DETAIL_LIST_MEMBERS"] as List<MEMBERS>;
                }
                return null;
            }
            set { HttpContext.Current.Session["GH_DETAIL_LIST_MEMBERS"] = value; }
        }

        public void LoadListMember()
        {
            if (this.LIST_MEMBERS == null)
            {
                this.LIST_MEMBERS = Singleton<MEMBERS_BC>.Inst.SelectAllItems();
            }
        }

        public void LoadCommandDetails()
        {
            if (Session["GHCommunity_GH_ID"] != null)
            {
                var ctlCmdDetail = new COMMAND_DETAIL_BC();
                int GH_ID = Convert.ToInt32(Session["GHCommunity_GH_ID"]);
                var lstDetail = ctlCmdDetail.SelectItemsByGhId(GH_ID).ToList();

                grdCommandDetails.DataSource = lstDetail;
                grdCommandDetails.DataBind();
            }
            else
            {
                grdCommandDetails.DataSource = null;
                grdCommandDetails.DataBind();
            }
        }
        #endregion


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
                    LoadListMember();
                    LoadCommandDetails();
                }
            }
        }

        #region "Xu ly thong tin grid"
        public string AccountBriefInfoByCodeId(string CodeId)
        {
            var user = LIST_MEMBERS.Where(m => m.CodeId == CodeId).SingleOrDefault();
            string briefInfo = user.Username + "/" + user.Phone;

            return briefInfo;
        }

        public string StatusToString(int status)
        {
            switch (status)
            {
                case (int)Constants.COMMAND_STATUS.Pending:
                    return Constants.COMMAND_STATUS.Pending.ToString();
                case (int)Constants.COMMAND_STATUS.PH_Success:
                    return Constants.COMMAND_STATUS.PH_Success.ToString();
                case (int)Constants.COMMAND_STATUS.Success:
                    return Constants.COMMAND_STATUS.Success.ToString();
                case (int)Constants.COMMAND_STATUS.Expired:
                    return Constants.COMMAND_STATUS.Expired.ToString();
                default:
                    return string.Empty;
            }
        }

        public string CssStatus(int status)
        {
            switch (status)
            {
                case (int)Constants.COMMAND_STATUS.Pending:
                    return "label label-primary";
                case (int)Constants.COMMAND_STATUS.PH_Success:
                    return "label label-info";
                case (int)Constants.COMMAND_STATUS.Success:
                    return "label label-danger";
                case (int)Constants.COMMAND_STATUS.Expired:
                    return "label label-warning";
                default:
                    return "label label-primary";
            }
        }

        public string TransactionLink(object transactionId)
        {
            string transLink = string.Empty;
            if (transactionId != null && !string.IsNullOrEmpty(transactionId.ToString()))
            {
                //transLink = "https://blockchain.info/tx/" + transactionId;
                transLink = transactionId.ToString();
            }

            return transLink;
        }

        public bool visibleTransactionLink(object transactionId)
        {
            if (transactionId != null && !string.IsNullOrEmpty(transactionId.ToString()))
            {
                return true;
            }
            else return false;
        }

        public bool visibleConfirmButton(object confirmGH, object confirmPH, object status)
        {
            if ((confirmGH != null && confirmPH != null && (!Convert.ToBoolean(confirmPH) || Convert.ToBoolean(confirmGH))) 
                || (Convert.ToInt32(status) == (int)Constants.COMMAND_STATUS.Expired))
            {
                return false;
            }
            return true;
        }

        public string showTimeRemaining(DateTime timeremain, int status)
        {
                if (status == (int)Constants.COMMAND_STATUS.PH_Success)
                {
                    var currentDate = DateTime.Now;
                    var expiredDate = timeremain.AddHours(48);

                    if (currentDate > expiredDate)
                        return "Expired";
                    else
                    {
                        var remainDate = expiredDate - currentDate;
                        var hours = (remainDate.Days * 24) + remainDate.Hours;
                        string ret = hours.ToString("00") + ":" + remainDate.Minutes.ToString("00") + ":" + remainDate.Seconds.ToString("00");
                        return ret;
                    }
                }
                return string.Empty;
        }

        public string showTimeRemaining_TUNG(String StrTimeremain, int status)
        {
            try
            {
                if (status == (int)Constants.COMMAND_STATUS.PH_Success)
                {
                    DateTime timeremain = DateTime.Parse(StrTimeremain);
                    var currentDate = DateTime.Now;
                    var expiredDate = timeremain.AddHours(12);

                    if (currentDate > expiredDate)
                        return "Expired";
                    else
                    {
                        var remainDate = expiredDate - currentDate;
                        string ret = remainDate.Hours.ToString("00") + ":" + remainDate.Minutes.ToString("00") + ":" + remainDate.Seconds.ToString("00");
                        return ret;
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {

                return string.Empty;
            }
           
        }

        public string formatAmount(decimal amount)
        {
            return amount.ToString("0.#####");
        }
        #endregion

        #region "grid view event"
        protected void grdCommandDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadCommandDetails();
        }

        protected void grdCommandDetails_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdConfirm")
            {
                int COMMAND_DETAIL_ID = Convert.ToInt32(e.CommandArgument);

                Session["GH_DETAIL_COMMAND_DETAIL_ID"] = COMMAND_DETAIL_ID;

                Response.Redirect("ConfirmGH.aspx");
            }
        }
        #endregion

        //protected void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    LinkButton btn = (LinkButton)(sender);
        //    int COMMAND_DETAIL_ID = Convert.ToInt32(btn.CommandArgument);

        //    Session["GH_DETAIL_COMMAND_DETAIL_ID"] = COMMAND_DETAIL_ID;

        //    Response.Redirect("ConfirmGH.aspx");
        //}

    }
}