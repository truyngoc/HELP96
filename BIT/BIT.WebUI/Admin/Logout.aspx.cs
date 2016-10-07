using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Register.newRegist = false;
                Singleton<BITCurrentSession>.Inst.SignOut();
                Response.Redirect("~/Admin/Login.aspx");
            }
        }
    }
}