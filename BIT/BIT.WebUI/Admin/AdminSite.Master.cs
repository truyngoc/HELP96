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
                lblFullName.Text = Singleton<BITCurrentSession>.Inst.SessionMember.Fullname;
                lblUserName.Text = Singleton<BITCurrentSession>.Inst.SessionMember.Username;
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
                else if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId.Equals("009"))
                {
                    //QUAN LY NGUOI DUNG
                    liCommission.Visible = false;
                    liWithdraw.Visible = false;
                    liSignUp.Visible = false;
                    liPin.Visible = false;
                    liAdministrator.Visible = true;
                    liMember.Visible =true;
                    liWithDrawMgr.Visible = false;
                    liCreatePHGH.Visible = false;
                    liCommandList.Visible = false;
                    liManagerPHGH.Visible = false;
                    liReport.Visible = false;
                }
                else if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId.Equals("010"))
                {
                    //QUAN LY PH GH
                    liCommission.Visible = false;
                    liWithdraw.Visible = false;
                    liSignUp.Visible = false;
                    liPin.Visible = false;
                    liAdministrator.Visible = true;
                    liMember.Visible = false;
                    liWithDrawMgr.Visible = false;
                    liCreatePHGH.Visible = false;
                    liCommandList.Visible = true;
                    liManagerPHGH.Visible = true;
                    liReport.Visible = true;
                }
                else
                    liAdministrator.Visible = false;
            }
        }
    }
}