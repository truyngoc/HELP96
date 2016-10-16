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
    public partial class EditAccount : System.Web.UI.Page
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
                    //if (Singleton<BITCurrentSession>.Inst.SessionMember.IsLock==1)
                    //{
                    //    btnUpdate.Text = "Order Unlock account (0.01BTC)";
                    //}
                    //else
                    //{
                    //    btnUpdate.Text = "Order Update Information (0.01BTC)";
                    //}
                    LoadUserInfor();
                }
            }
        }

        //public void getAdminWallet()
        //{
        //    string admWallet = Singleton<MEMBERS_BC>.Inst.SelectRandomAdmin().Wallet;
        //    imgAdminWallet.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}", admWallet.Trim()).Trim();
        //    lblAdminWallet.Text = admWallet;
        //}
        public void LoadUserInfor()
        {
            int Id;
            if ((Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")||(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "009"))
            {
                if (Convert.ToInt32(HttpContext.Current.Session["BIT_MemberID_Edit"]) == 0)
                {
                    Id = Singleton<BITCurrentSession>.Inst.SessionMember.ID;
                }
                else
                {
                    Id = Convert.ToInt32(HttpContext.Current.Session["BIT_MemberID_Edit"]);
                }

                //btnUpdateAdmin.Visible = true;
                //btnUpdate.Visible = false;
                //divBlockChain.Visible = false;
                //txtFullName.Attributes.Remove("readonly");
                //txtEmail.Attributes.Remove("readonly");
                //txtPhone.Attributes.Remove("readonly");
                //txtWallet.Attributes.Remove("readonly");
            }
            else
            {
                Id = Singleton<BITCurrentSession>.Inst.SessionMember.ID;
                //getAdminWallet();
                //txtFullName.Attributes.Add("readonly", "readonly");
                //txtEmail.Attributes.Add("readonly", "readonly");
                //txtPhone.Attributes.Add("readonly", "readonly");
                //txtWallet.Attributes.Add("readonly", "readonly");
            }


            MEMBERS obj = Singleton<MEMBERS_BC>.Inst.SelectItemByID(Id);

            txtUserName.Text = obj.Username;
            txtEmail.Text = obj.Email;
            txtFullName.Text = obj.Fullname;
            txtPhone.Text = obj.Phone;
            txtWallet.Text = obj.Wallet;
            //txtSysWallet.Text = obj.Sys_Wallet;

            hidCodeId.Value = obj.CodeId;
        }

        public MEMBERS GetDataOnForm()
        {
            MEMBERS obj = new MEMBERS();
            //obj = Singleton<BITCurrentSession>.Inst.SessionMember;
            obj.Username = txtUserName.Text;
            obj.Fullname = txtFullName.Text.Trim();
            obj.Phone = txtPhone.Text.Trim();
            obj.Email = txtEmail.Text.Trim();
            obj.Wallet = txtWallet.Text.Trim();
            obj.CodeId = hidCodeId.Value;
            return obj;
        }

        public MEMBERS_EDIT GetDataOnFormEdit()
        {
            MEMBERS_EDIT obj = new MEMBERS_EDIT();

            obj.CodeId = hidCodeId.Value;
            obj.Username = txtUserName.Text;
            obj.Fullname = txtFullName.Text.Trim();
            obj.Phone = txtPhone.Text.Trim();
            obj.Email = txtEmail.Text.Trim();
            obj.Wallet = txtWallet.Text.Trim();
            //obj.Transaction = txtTransaction.Text;
            //obj.WALLET_ADMIN = lblAdminWallet.Text;
            obj.Upline = Singleton<BITCurrentSession>.Inst.SessionMember.Upline;
            return obj;
        }
        //public void UpdateProfile()
        //{
        //    MEMBERS_BC ctlMember = new MEMBERS_BC();

        //    MEMBERS obj = GetDataOnForm();

        //    //Tung: Them doan check Password 2
        //    if (obj.Password_PIN == Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
        //    {
        //        ctlMember.UpdateItem(obj);
        //        ShowMessageError(lblMessage, "Update profile member successful", true);
        //    }
        //    else
        //    {
        //        ShowMessageError(lblMessage, "Password PIN is invalid! ", true);
        //    }



        //}

        public void ReloadSeasion()
        {
            var login_info = Singleton<MEMBERS_BC>.Inst.SelectItemByUserName(txtUserName.Text);

            if (login_info != null)
            {
                Singleton<BITCurrentSession>.Inst.SessionMember = login_info;
            }
        }

        public void ShowMessageError(Label lblMsgErr, string sMsgErr = "", bool bVisible = false)
        {
            lblMsgErr.Text = sMsgErr;
            lblMsgErr.Visible = bVisible;
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    MEMBERS obj = GetDataOnForm();
                    Singleton<MEMBERS_BC>.Inst.UpdateItem(obj);
                    Singleton<BITCurrentSession>.Inst.SessionMember = Singleton<MEMBERS_BC>.Inst.SelectItem(obj.CodeId);
                    //Singleton<MEMBERS_BC>.Inst.InsertEditItem(obj);
                    TNotify.Alerts.Success("Edit account information success.", true);
                    //Response.Redirect("OrderChangeInfo.aspx");
                }
                catch (Exception ex)
                {
                    //ShowMessageError(lblMessage, ex.ToString(), true);
                    TNotify.Alerts.Warning("Edit account information error." + ex.ToString(), true);
                }
            }
        }

        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    MEMBERS obj = GetDataOnForm();
                    MEMBERS_BC ctlMember = new MEMBERS_BC();
                    ctlMember.UpdateItem(obj);
                    TNotify.Alerts.Success("Edit account information success.", true);
                }
                catch (Exception ex)
                {
                    TNotify.Alerts.Warning("Edit account information error." + ex.ToString(), true);
                }
            }
        }
    }
}