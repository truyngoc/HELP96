using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;

using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class Commission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    getCommission();
                }
            }
        }
        private void getCommission()
        {
            List<COMMISSION> lst = Singleton<COMMISSION_BC>.Inst.SelectItemByCodeID_C(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            dtlGH.DataSource = lst;
            dtlGH.DataBind();
        }
    }
}