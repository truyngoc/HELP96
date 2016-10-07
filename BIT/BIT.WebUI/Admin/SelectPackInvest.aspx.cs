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
    public partial class SelectPackInvest : System.Web.UI.Page
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

                    if (hidPack.Value != string.Empty)
                    {
                        drPackSelectTion.SelectedIndex = Convert.ToInt32(hidPack.Value);
                    }
                    if (hidMonth.Value != string.Empty)
                    {
                        drTimeInvest.SelectedIndex = Convert.ToInt32(hidMonth.Value);
                    }
                    //}
                    if (Singleton<BITCurrentSession>.Inst.isLoginUser)
                    {
                        if (Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                        {
                            Response.Redirect("../Admin/AdminSelectPackInvest.aspx");
                        }
                        else
                        {
                            getSpackage();
                            bindDataList();
                            getAdminWallet();
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

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            //Check if invest package not expire - cannot buy new package
            if (txtPasswordPIN.Text != Singleton<BITCurrentSession>.Inst.SessionMember.Password_PIN)
            {
                TNotify.Toastr.Warning("Wrong transaction password, please try again", "Error", TNotify.NotifyPositions.toast_top_full_width, true);
                return;
            }
            if (!Singleton<PACKAGE_TRANSACTION_BC>.Inst.isAllPackageExpire(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId))
            {
                try
                {
                    //get temp object to insert, start date ,end date, expired date will be update after admin confirm transaction
                    PACKAGE_TRANSACTION obj = new PACKAGE_TRANSACTION();
                    obj.CODEID = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                    obj.PACKAGEID = Convert.ToInt32(drPackSelectTion.SelectedValue);
                    obj.START_DATE = DateTime.Now;
                    switch(drTimeInvest.SelectedValue)
                    {
                        case "1":
                            obj.END_DATE = DateTime.Now.AddMonths(1);
                            break;
                        case "2":
                            obj.END_DATE = DateTime.Now.AddMonths(2);
                            break;
                        case "3":
                            obj.END_DATE = DateTime.Now.AddMonths(3);
                            break;
                    }
                    obj.EXPIRED = 0;
                    obj.GH1 = DateTime.Now.AddDays(45);
                    obj.GH2 = DateTime.Now.AddDays(90);
                    obj.STATUS_GH = 0;
                    obj.CREATE_DATE = DateTime.Now;
                    obj.TRANSACTION_PACKAGE = txtTransaction.Text;
                    obj.AMOUNT = Convert.ToDecimal(txtTotalAmount.Text);
                    obj.STATUS_PH = 0;

                    Singleton<PACKAGE_TRANSACTION_BC>.Inst.InsertItem(obj,Convert.ToInt32(drTimeInvest.SelectedValue));

                    TNotify.Alerts.Danger(string.Format("Buy Invest Package {0} Completed", drPackSelectTion.SelectedValue), true);
                    Response.Redirect("../Admin/SelectPackInvest.aspx");
                    
                }
                catch (Exception ex)
                {
                    TNotify.Toastr.Warning("Error occur ! Please try again", "Error", TNotify.NotifyPositions.toast_top_full_width, true);
                }
            }
            else
            {
                TNotify.Alerts.Danger(string.Format("You have Invest Package not complete, please check your Invest Package !", drPackSelectTion.SelectedValue), true);
            }
        }

        public void getSpackage()
        {
            List<SPACKAGE> lstPackage = Singleton<SPACKAGE_BC>.Inst.SelectAllItems();

            drPackSelectTion.DataSource = lstPackage;
            drPackSelectTion.DataValueField = "PackageID";
            drPackSelectTion.DataTextField = "PackageID";
            drPackSelectTion.DataBind();
        }

        public void bindDataList()
        {
            List<PACKAGE_TRANSACTION> lstPackage = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectAllItemsByCodeID(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            grdListPH.DataSource = lstPackage;
            grdListPH.DataBind();
        }

        protected void drPackSelectTion_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidPack.Value = drPackSelectTion.SelectedIndex.ToString();
            //HttpContext.Current.Session["PackSelect"] = drPackSelectTion.SelectedIndex;
            switch (drPackSelectTion.SelectedValue)
            {
                case "1":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.2).ToString();
                    break;
                case "2":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.25).ToString();
                    //extendValue = (decimal)0.25;
                    break;
                case "3":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "4":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "5":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
            }

        }

        protected void drTimeInvest_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidMonth.Value = drTimeInvest.SelectedIndex.ToString();
            //HttpContext.Current.Session["MonthSelect"] = drTimeInvest.SelectedIndex;
            switch (drPackSelectTion.SelectedValue)
            {
                case "1":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.2).ToString();
                    break;
                case "2":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.25).ToString();
                    //extendValue = (decimal)0.25;
                    break;
                case "3":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "4":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
                case "5":
                    txtTotalAmount.Text = (Convert.ToInt32(drPackSelectTion.SelectedValue) + Convert.ToInt32(drTimeInvest.SelectedValue) * 0.3).ToString();
                    //extendValue = (decimal)0.3;
                    break;
            }
        }


        public string getStatus(object statusPH, object statusGH)
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
            switch (statusGH.ToString())
            {
                case "1":
                    restring = "Done GH1";
                    break;
                case "2":
                    restring = "Done GH2 - Invest Pack Expired";
                    break;
            }
            return restring;
        }

        public string datecount(object startDate, object endate, object ID)
        {
            //return date count
            //check if enddate = datetime.now => update status_ph to 0
            if(Convert.ToDateTime(endate).Date == DateTime.Now.Date)
            {
                PACKAGE_TRANSACTION pck = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectItem(Convert.ToInt32(ID));
                pck.STATUS_PH = 0;
                Singleton<PACKAGE_TRANSACTION_BC>.Inst.updateItem(pck);
            }
            return (DateTime.Now.DayOfYear - Convert.ToDateTime(startDate).DayOfYear).ToString();
        }

        public bool getGH1Enable(object startDate,object statusGH)
        {
            bool gh1 = false;
            if ((DateTime.Now.DayOfYear - Convert.ToDateTime(startDate).DayOfYear) >= 45)
            {
                if (statusGH.ToString() != "1" && statusGH.ToString() != "2")
                {
                    gh1 = true;
                }
            }
            return gh1;
        }
        public bool getGH2Enable(object startDate,object statusGH)
        {
            bool gh2 = false;
            if ((DateTime.Now.DayOfYear - Convert.ToDateTime(startDate).DayOfYear) >= 90)
            {
                if(statusGH.ToString() !="2")
                {
                    gh2 = true;
                }
            }
            return gh2;
        }

        protected void btnGH1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string ID = btn.CommandArgument;

                PACKAGE_TRANSACTION pck = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectItem(Convert.ToInt32(ID));
                //update wallet + commission
                pck.STATUS_GH = 1;
                //update package transaction
                Singleton<PACKAGE_TRANSACTION_BC>.Inst.updateGH1(pck);
                TNotify.Alerts.Danger(string.Format("GH Fist time completed", drPackSelectTion.SelectedValue), true);
                //TNotify.Toastr.Warning("GH Fist time completed", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                Response.Redirect("../Admin/SelectPackInvest.aspx");
            }
            catch(Exception ex)
            {
                TNotify.Toastr.Warning("Error occur ! Please try again", "Error", TNotify.NotifyPositions.toast_top_full_width, true);
            }
        }

        protected void btnGH2_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string ID = btn.CommandArgument;
                PACKAGE_TRANSACTION pck = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectItem(Convert.ToInt32(ID));
                //update wallet + commission
                pck.STATUS_GH = 2;
                pck.EXPIRED = 1;
                //update package_transaction

                Singleton<PACKAGE_TRANSACTION_BC>.Inst.updateGH2(pck);
                Response.Redirect("../Admin/Withdraw.aspx");
                TNotify.Toastr.Warning("GH Second time completed", "Completed", TNotify.NotifyPositions.toast_top_full_width, true);
                
            }
            catch (Exception ex)
            {
                TNotify.Toastr.Warning("Error occur ! Please try again", "Error", TNotify.NotifyPositions.toast_top_full_width, true);
            }
        }

        public void getAdminWallet()
        {
            string admWallet = Singleton<MEMBERS_BC>.Inst.SelectRandomAdmin().Wallet;
            imgAdminWallet.ImageUrl = string.Format("http://chart.googleapis.com/chart?chs=200x200&cht=qr&chl={0}",admWallet.Trim()).Trim();
            lblAdminWallet.Text = admWallet;
        }

        protected void lnkExtend_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pin.aspx");
        }

        public bool getExtendVisible(object enddate, object statusGH)
        {
            bool b = false;
            if(Convert.ToDateTime(enddate) > DateTime.Now && statusGH.ToString() != "2")
            {
                b = true;
            }
            return b;
        }

    }
}
