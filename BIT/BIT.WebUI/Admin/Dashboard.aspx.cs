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
    public partial class Dashboard : System.Web.UI.Page
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
                    BindDashboard();
                }
            }
        }

        public void BindDashboard()
        {
            var ctlMem = new MEMBERS_BC();

            var codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;

            var dashboard = ctlMem.getInfoDashBoard(codeId);

            BindDataToForm(dashboard);

        }

        public void BindDataToForm(DASHBOARD o)
        {
            //lblB_Wallet.Text = o.B_Wallet.ToString();
            lblC_Wallet.Text = o.C_Wallet.ToString();
            //lblR_Wallet.Text = o.R_Wallet.ToString();
            lblPIN_Wallet.Text = Singleton<BITCurrentSession>.Inst.SessionMember.ExpiredDate.ToString("dd/MM/yyyy");
            lblTotalDownline.Text = o.Total_Downline.ToString();
            //lblDownline_Left.Text = o.Total_Downline_Left.ToString();
            //lblDownline_Right.Text = o.Total_Downline_Right.ToString();
            lblTotalGH.Text = o.Total_GH.ToString();
            lblTotalPH.Text = o.Total_PH.ToString();
            lblDirectDownline.Text = o.Direct_Downline.ToString();
            //lblDownline_BTC_Left.Text = o.Total_GH_Downline_Left.ToString();
            //lblDownline_BTC_Right.Text = o.Total_GH_Downline_Right.ToString();
        }
    }
}