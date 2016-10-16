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
    public partial class COMMAN_LIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if ((Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0") || (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "010"))
                    LoadCommands();
                else
                    Response.Redirect("~/Admin/Login.aspx");
            }
        }

        public void LoadCommands()
        {
            var ctlCommand = new COMMAND_BC();
            var lstCommand = ctlCommand.SelectAllItems();

            grdCommand.DataSource = lstCommand;
            grdCommand.DataBind();
        }

        #region "grid view event"
        protected void grdCommand_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadCommands();
        }

        protected void grdCommand_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdDetail")
            {
                int COMMAND_ID = Convert.ToInt32(e.CommandArgument);

                Session["COMMAN_LIST_COMMAND_ID"] = COMMAND_ID;

                Response.Redirect("COMMAND_DETAIL_LIST.aspx");
            }
        }
        #endregion

    }
}