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
    public partial class ManagerPHGH : System.Web.UI.Page
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
        public int COMMAND_ID
        {
            get
            {
                if (ViewState["COMMAND_DETAIL_LIST_COMMAND_ID"] != null)
                {
                    return (int)ViewState["COMMAND_DETAIL_LIST_COMMAND_ID"];
                }
                return 0;
            }
            set { ViewState["COMMAND_DETAIL_LIST_COMMAND_ID"] = value; }
        }


        public List<MEMBERS> LIST_MEMBERS
        {
            get
            {
                if (HttpContext.Current.Session["COMMAND_DETAIL_LIST_LIST_MEMBERS"] != null)
                {
                    return HttpContext.Current.Session["COMMAND_DETAIL_LIST_LIST_MEMBERS"] as List<MEMBERS>;
                }
                return null;
            }
            set { HttpContext.Current.Session["COMMAND_DETAIL_LIST_LIST_MEMBERS"] = value; }
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
            LoadCommandDetailByStatus();
        }

        public void LoadCommandDetailByStatus()
        {
            if (Session["COMMAN_LIST_COMMAND_ID"] != null)
            {
                var ctlCmdDetail = new COMMAND_DETAIL_BC();
                COMMAND_ID = Convert.ToInt32(Session["COMMAN_LIST_COMMAND_ID"]);

                string sStatus = string.Empty;

                if (string.IsNullOrEmpty(cblStatus.SelectedValue))
                {
                    sStatus = null;
                }
                else
                {
                    foreach (ListItem item in cblStatus.Items)
                    {
                        if (item.Selected)
                        {
                            if (string.IsNullOrEmpty(sStatus))
                                sStatus = item.Value;
                            else
                                sStatus = sStatus + "," + item.Value;
                        }
                    }
                }

                var lstDetail = ctlCmdDetail.SelectCommandDetailAdminByStatus(txtUsername.Text.Trim(), sStatus);

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
        #endregion

        protected void grdCommandDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grdCommandDetails.PageIndex = e.NewPageIndex;
            LoadCommandDetails();

        }

        protected void cblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCommandDetailByStatus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCommandDetailByStatus();
        }
    }
}