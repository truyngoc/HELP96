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
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Register.newRegist)
            //    {
            //        liAdministrator.Visible = false;
            //    }
            //else if (Singleton<BITCurrentSession>.Inst.SessionMember == null)
            //    Response.Redirect("Login.aspx");
            //else
            //{
            if (!IsPostBack)
            {
                lblLoginName.Text = Singleton<BITCurrentSession>.Inst.SessionMember.Fullname;
                if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId.Equals("0"))
                    liAdministrator.Visible = true;
                else if (Singleton<BITCurrentSession>.Inst.SessionMember.IsLock == 1)
                {
                    liAdministrator.Visible = false;
                    liSignUp.Visible = false;
                    liPin.Visible = false;
                    //liPakage.Visible = false;
                    //liPH.Visible = false;
                    //liGH.Visible = false;
                    liCommission.Visible = false;
                    liWithdraw.Visible = false;
                }
                else
                    liAdministrator.Visible = false;
            }
        }
    }
}