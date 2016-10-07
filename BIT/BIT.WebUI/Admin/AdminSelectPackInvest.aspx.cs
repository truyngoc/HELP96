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
    public partial class AdminSelectPackInvest : System.Web.UI.Page
    {
        //admin confirm + pack vao c-wallet
        //insert commission history when gh1 gh2 - cwallet
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                if (Singleton<BITCurrentSession>.Inst.isLoginUser && Singleton<BITCurrentSession>.Inst.SessionMember.CodeId == "0")
                {
                    bindDataList();
                }
                else
                {
                    Response.Redirect("../Admin/SelectPackInvest.aspx");
                }
            }
        }

        public void bindDataList()
        {
            List<PACKAGE_TRANSACTION> lstPackage = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectAllItemsByCodeID(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            grdListPH.DataSource = lstPackage;
            grdListPH.DataBind();
        }

        public string getStatus(object status)
        {
            string restring = string.Empty;
            switch(status.ToString())
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
            return (Convert.ToDateTime(startDate).AddDays(90).Day - DateTime.Now.Day).ToString();
        }

        protected void lnkConfirm_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ID = btn.CommandArgument;
            PACKAGE_TRANSACTION pck = Singleton<PACKAGE_TRANSACTION_BC>.Inst.SelectItem(Convert.ToInt32(ID));
            //update pck ph_status = 1;
            //update members set startdate = pack startdate endate = packendate
            pck.STATUS_PH = 1;
            //create store update package and members
            Singleton<PACKAGE_TRANSACTION_BC>.Inst.updateItem(pck);
            MEMBERS objMem = Singleton<MEMBERS_BC>.Inst.SelectItem(pck.CODEID);
            objMem.ActiveDate = pck.START_DATE;
            objMem.ExpiredDate = pck.END_DATE;
            Singleton<MEMBERS_BC>.Inst.UpdateExpireDate(objMem);

            TNotify.Alerts.Danger(string.Format("Confirmed Invest Package {0} for User {1} Completed",pck.PACKAGEID,objMem.Username ), true);
            Response.Redirect("../admin/adminselectpackInvest.aspx");
        }

    }
}
