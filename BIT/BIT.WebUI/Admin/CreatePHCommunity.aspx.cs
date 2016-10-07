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
    public partial class CreatePHCommunity : System.Web.UI.Page
    {
        private PACKAGE_TRANSACTION_BC ctlPack = new PACKAGE_TRANSACTION_BC();
        private PH_BC ctlPH = new PH_BC();
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
                    string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;

                    // load list PH
                    this.LoadListPH();

                    // load so BIT toi da cua thang nay theo goi dang ky (lay goi dk gan nhat)
                    // neu chua dang ky goi thi thong bao
                    if (ctlPack.IsPackageExpire(codeId))
                    {
                        var package = ctlPack.SelectItemByCodeId(codeId);

                        lblRemainAmount.Text = package.PACKAGEID.ToString();
                    }
                    else
                    {
                        btnCreatePH.Enabled = false;
                        // thong bao het han hoac chua dang ky goi
                        TNotify.Alerts.Warning("Package is not register or account is expired", true);
                    }
                }                
            }            
        }

        protected void btnCreatePH_Click(object sender, EventArgs e)
        {            
            if (Page.IsValid)
            {
                var ctlMember = new MEMBERS_BC();

                string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;

                // check xem goi dang ky da het han chua
                if (ctlPack.IsPackageExpire(codeId))
                {
                    // check quota
                    if (ctlPH.GetNumberPH(codeId) < 1)
                    {
                        // tao lenh PH
                        // check transaction pass co dung ko
                        string passPIN = txtTransPass.Text;
                        if (ctlMember.CheckPasswordPIN(codeId, passPIN))
                        {
                            var oPH = GetPH();
                            // Insert PH
                            try
                            {
                                ctlPH.InsertItem(oPH);

                                TNotify.Toastr.Success("Create PH successfull", "Create PH", TNotify.NotifyPositions.toast_top_full_width, true);

                                // reload list PH
                                this.LoadListPH();                                
                            }
                            catch (Exception ex)
                            {
                                TNotify.Alerts.Danger(ex.ToString(), true);
                            }
                            Response.Redirect("CreatePHCommunity.aspx");
                        }
                        else
                        {
                            // thong bao password pin ko dung
                            TNotify.Alerts.Warning("Password PIN is not valid", true);
                        }
                    }
                    else
                    {
                        // thong bao het quota PH trong ngay
                        TNotify.Alerts.Warning("Only have PH once perday", true);
                    }
                }
                else
                {
                    // thong bao het han hoac chua dang ky goi
                    TNotify.Alerts.Warning("Package is not register or account is expired", true);
                }
            }
            
        }

        private PH GetPH()
        {
            var oPH = new PH();

            oPH.CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;;
            oPH.Amount = Convert.ToDecimal(lblRemainAmount.Text);
            oPH.CreateDate = DateTime.Now;
            oPH.Status = (int)Constants.PH_STATUS.Waiting;

            return oPH;
        }

        private void LoadListPH()
        {
            var ctlPH = new PH_BC();
            string codeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;

            var lstPH = ctlPH.SelectItemsByCodeId(codeId);

            grdCMD.DataSource = lstPH;
            grdCMD.DataBind();
        }

        public string StatusToString(int status)
        {
            switch (status)
            {
                case (int) Constants.PH_STATUS.Waiting:
                    return Constants.PH_STATUS.Waiting.ToString();
                case (int)Constants.PH_STATUS.Pending:
                    return Constants.PH_STATUS.Pending.ToString();
                case (int)Constants.PH_STATUS.Success:
                    return Constants.PH_STATUS.Success.ToString();
                default:
                    return string.Empty;
            }
        }

        public bool VisibleDetailButton(int ID)
        {
            return ctlPH.Check_Visible_DetailButton(ID);
        }

        public string CssStatus(int status)
        {
            switch (status)
            {
                case (int)Constants.PH_STATUS.Waiting:
                    return "label label-primary";
                case (int)Constants.PH_STATUS.Pending:
                    return "label label-info";
                case (int)Constants.PH_STATUS.Success:
                    return "label label-danger";
                default:
                    return "label label-primary";
            }
        }

        //protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdPH.PageIndex = e.NewPageIndex;
        //    LoadListPH();
        //}

        //protected void grdPH_OnRowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "CmdDetail")
        //    {
        //        int PH_ID = Convert.ToInt32(e.CommandArgument);

        //        Session["CreatePHCommunity_PH_ID"] = PH_ID;

        //        Response.Redirect("PH_DETAIL.aspx");
        //    }
        //}

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            int PH_ID = Convert.ToInt32(btn.CommandArgument);

            Session["CreatePHCommunity_PH_ID"] = PH_ID;

            Response.Redirect("PH_DETAIL.aspx");
        }

    }
}