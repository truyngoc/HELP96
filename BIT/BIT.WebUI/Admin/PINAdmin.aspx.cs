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
    public partial class PINAdmin : System.Web.UI.Page
    {

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
                    if (Singleton<BITCurrentSession>.Inst.isLoginUser)
                    {
                        if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId != "0")
                        {
                            Response.Redirect("../Admin/PIN.aspx");
                        }
                        else
                        {
                            bindDataList();
                        }
                    }
                }
            }
        }

        public void ShowMessageError(Label lblMsgErr, string sMsgErr = "", bool bVisible = false)
        {
            lblMsgErr.Text = sMsgErr;
            lblMsgErr.Visible = bVisible;
        }

        public void bindDataList()
        {
            List<PIN_TRANSACTION> lstPIN = Singleton<PIN_TRANSACTION_BC>.Inst.SelectAllItems(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            grdListPH.DataSource = lstPIN;
            grdListPH.DataBind();
        }

        public string getStatus(object statusPH)
        {
            string restring = string.Empty;
            switch (statusPH.ToString())
            {
                case "0":
                    restring = "Waiting Confirm";
                    break;
                case "1":
                    restring = "Confirmed";
                    break;
            }
            return restring;
        }

        public string datecount(object startDate)
        {
            return (DateTime.Now.DayOfYear - Convert.ToDateTime(startDate).DayOfYear).ToString();
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ID = btn.CommandArgument;

            Singleton<PIN_TRANSACTION_BC>.Inst.UpdateItem(Convert.ToInt32(ID));

            TNotify.Toastr.Warning("Confirmed !", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
        }
    }
}