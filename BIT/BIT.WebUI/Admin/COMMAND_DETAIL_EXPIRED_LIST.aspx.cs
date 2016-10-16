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
    public partial class COMMAND_DETAIL_EXPIRED_LIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0") || (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "010"))
                {
                    LIST_MEMBERS = null;

                    LoadListMember();
                    LoadCommandDetails();
                }
                else
                    Response.Redirect("~/Admin/Login.aspx");
            }
        }

        #region "Utils"

        public List<MEMBERS> LIST_MEMBERS
        {
            get
            {
                if (HttpContext.Current.Session["COMMAND_DETAIL_EXPIRED_LIST"] != null)
                {
                    return HttpContext.Current.Session["COMMAND_DETAIL_EXPIRED_LIST"] as List<MEMBERS>;
                }
                return null;
            }
            set { HttpContext.Current.Session["COMMAND_DETAIL_EXPIRED_LIST"] = value; }
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
            var ctlCmdDetail = new COMMAND_DETAIL_BC();
            var lstDetail = ctlCmdDetail.SelectItemsExpired();

            if (lstDetail != null && lstDetail.Count > 0)
            {
                grdCommandDetails.DataSource = lstDetail;
                grdCommandDetails.DataBind();
            }
            else
            {
                grdCommandDetails.DataSource = null;
                grdCommandDetails.DataBind();
            }
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
                case (int)Constants.COMMAND_STATUS.ProcessPhExpired:
                    return Constants.COMMAND_STATUS.ProcessPhExpired.ToString();
                case (int)Constants.COMMAND_STATUS.ProcessGhExpired:
                    return Constants.COMMAND_STATUS.ProcessGhExpired.ToString();
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

        public string AccountBriefInfoByCodeId(string CodeId)
        {
            var user = LIST_MEMBERS.Where(m => m.CodeId == CodeId).SingleOrDefault();
            string briefInfo = user.Username + "/" + user.Phone;

            return briefInfo;
        }

        public bool visibleButton(object status)
        {
            if (status != null)
            {
                int _status = Convert.ToInt32(status);

                switch (_status)
                {
                    case (int)Constants.COMMAND_STATUS.ProcessPhExpired:
                        return false;
                    case (int)Constants.COMMAND_STATUS.ProcessGhExpired:
                        return false;
                    default:
                        return true;
                }
            }
            return true;
        }
        #endregion

        protected void grdCommandDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grdCommandDetails.PageIndex = e.NewPageIndex;
            LoadCommandDetails();

        }

        protected void grdCommandDetails_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdProcessPH")    // PH right
            {
                int COMMAND_ID = Convert.ToInt32(e.CommandArgument);

                try
                {
                    var ctlCommandDetail = new COMMAND_DETAIL_BC();
                    var oCommandDetail = ctlCommandDetail.SelectItem(COMMAND_ID);

                    // confirm GH for command detail
                    oCommandDetail.ConfirmGH = true;
                    oCommandDetail.DateConfirmGH = DateTime.Now;
                    oCommandDetail.Status = (int)Constants.COMMAND_STATUS.Success;

                    ctlCommandDetail.GH_CONFIRM(oCommandDetail);

                    // update status command detail
                    ctlCommandDetail.UpdateStatus((int)oCommandDetail.ID, (int)Constants.COMMAND_STATUS.ProcessPhExpired);

                    // lock GH
                    var ctlMem = new MEMBERS_BC();
                    ctlMem.LockAccount(oCommandDetail.CodeId_To);

                    TNotify.Toastr.Success("Process command expired successfull", "Process command expired", TNotify.NotifyPositions.toast_top_full_width, true);

                    Response.Redirect("COMMAND_DETAIL_EXPIRED_LIST.aspx");
                }
                catch (System.Threading.ThreadAbortException lException)
                {
                    // C2: catch exception nay khi redirect
                }
                catch (Exception ex)
                {
                    TNotify.Alerts.Danger(ex.ToString(), true);
                }

            }
            else if (e.CommandName == "cmdProcessGH")   // GH right
            {
                int COMMAND_ID = Convert.ToInt32(e.CommandArgument);

                try
                {
                    var ctlCommandDetail = new COMMAND_DETAIL_BC();
                    var oCommandDetail = ctlCommandDetail.SelectItem(COMMAND_ID);

                    // tranfer GH to waiting create command
                    var ctlGH = new GH_BC();

                    ctlGH.UpdateStatus((int)oCommandDetail.GH_ID, (int)Constants.GH_STATUS.Waiting);

                    // update status command detail
                    ctlCommandDetail.UpdateStatus((int)oCommandDetail.ID, (int)Constants.COMMAND_STATUS.ProcessGhExpired);

                    // lock PH
                    var ctlMem = new MEMBERS_BC();
                    ctlMem.LockAccount(oCommandDetail.CodeId_From);

                    TNotify.Toastr.Success("Process command expired successfull", "Process command expired", TNotify.NotifyPositions.toast_top_full_width, true);

                    Response.Redirect("COMMAND_DETAIL_EXPIRED_LIST.aspx");
                }
                catch (System.Threading.ThreadAbortException lException)
                {
                    // C2: catch exception nay khi redirect
                }
                catch (Exception ex)
                {
                    TNotify.Alerts.Danger(ex.ToString(), true);
                }
            }
        }
    }
}