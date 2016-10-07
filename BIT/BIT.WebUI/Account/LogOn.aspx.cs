using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Account
{
    public partial class LogOn : System.Web.UI.Page
    {
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {                
                var login_info = Singleton<MEMBERS_BC>.Inst.SelectItemByUserPass(txtUserName.Text, txtPassword.Text);

                if (login_info != null)
                {
                    Singleton<BITCurrentSession>.Inst.SessionMember = login_info;
                    lblMessage.Visible = false;
                    Response.Redirect("~/Admin/Dashboard.aspx");                   
                }
                else
                {
                    lblMessage.Text = "*Username or password incorrect";
                    lblMessage.Visible = true;
                }
            }
        }
    }
}