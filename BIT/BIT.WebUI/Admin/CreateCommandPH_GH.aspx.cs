using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Transactions;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class CreateCommandPH_GH : System.Web.UI.Page
    {
        #region "property"
        public List<PH_Info> ListPH
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH"] as List<PH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH"] = value; }
        }

        public List<PH_Info> ListPH_First
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH_First"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH_First"] as List<PH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH_First"] = value; }
        }

        public List<PH_Info> ListPH_First_Selected
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH_FIRST_SELECTED"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH_FIRST_SELECTED"] as List<PH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_PH_FIRST_SELECTED"] = value; }
        }

        public List<GH_Info> ListGH
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_GH"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_GH"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_GH"] = value; }
        }

        public List<GH_Info> ListAdminGH
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH"] = value; }
        }

        public List<GH_Info> ListAdminGH_Selected
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_SELECTED"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_SELECTED"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_SELECTED"] = value; }
        }

        public List<GH_Info> ListAdminGH_FINAL
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_FINAL"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_FINAL"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_ADMIN_GH_FINAL"] = value; }
        }

        public COMMAND COMMAND
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_COMMAND"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_COMMAND"] as COMMAND;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_COMMAND"] = value; }
        }

        public List<COMMAND_DETAIL> LIST_COMMAND_DETAIL
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_LIST_COMMAND_DETAIL"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_LIST_COMMAND_DETAIL"] as List<COMMAND_DETAIL>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_LIST_COMMAND_DETAIL"] = value; }
        }

        public List<MEMBERS> LIST_MEMBERS
        {
            get
            {
                if (HttpContext.Current.Session["CreateCommandPH_GH_LIST_MEMBERS"] != null)
                {
                    return HttpContext.Current.Session["CreateCommandPH_GH_LIST_MEMBERS"] as List<MEMBERS>;
                }
                return null;
            }
            set { HttpContext.Current.Session["CreateCommandPH_GH_LIST_MEMBERS"] = value; }
        }
        #endregion

        private PH_BC ctlPH = new PH_BC();
        private GH_BC ctlGH = new GH_BC();
        public COMMAND command;
        public List<COMMAND_DETAIL> _ListCommand;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
                else
                {
                    ResetAllSessionList();

                    LoadListPH();
                    LoadListPH_First();
                    LoadListGH();
                    LoadListAdminGH();
                    LoadListMember();
                }
            }
        }

        #region "Load list"
        public List<PH_Info> GetListPH()
        {
            var numberPH = txtNumberPH.Text == string.Empty ? 0 : Convert.ToInt32(txtNumberPH.Text);
            var lstPH = ctlPH.SelectItemsByNumber(numberPH);

            return lstPH;
        }

        private string ReplaceUserName()
        {
            string str = txtUserPH.Text;
            return str;
        }

        private string ReplaceUserName_PH_First()
        {
            string str = txtUserNamePH_First.Text;
            return str;
        }

        private string ReplaceUserName_GH()
        {
            string str = txtUserName.Text;
            return str;
        }

        public void LoadListPH()
        {
            if (ListPH == null)
            {
                string strUserName = ReplaceUserName();
                if (String.IsNullOrEmpty(strUserName.Trim()))
                {
                    if (this.ListPH == null)
                    {
                        int? numberPH = (txtNumberPH.Text == string.Empty ? null : (int?)Convert.ToInt32(txtNumberPH.Text));
                        this.ListPH = ctlPH.SelectItemsByNumber(numberPH);
                    }
                }
                else
                {
                    this.ListPH = ctlPH.SelectItemsByUserNameList(strUserName);
                }
            }

            lblTotalAmountPH.Text = ListPH.Sum(m => m.Amount).Value.ToString("0.#####");

            grdPH.DataSource = ListPH;
            grdPH.DataBind();

        }

        public void LoadListPH_First()
        {
            if (ListPH_First == null)
            {
                string strUserName = ReplaceUserName_PH_First();
                if (String.IsNullOrEmpty(strUserName.Trim()))
                {
                    if (this.ListPH_First == null)
                    {
                        //var numberPH = txtNumberPH_First.Text == string.Empty ? 0 : Convert.ToInt32(txtNumberPH_First.Text);
                        int? numberPH = (txtNumberPH_First.Text == string.Empty ? null : (int?)Convert.ToInt32(txtNumberPH_First.Text));
                        this.ListPH_First = ctlPH.SelectItemsByNumber_PH_First(numberPH);
                    }
                }
                else
                {
                    this.ListPH_First = ctlPH.SelectItemsByUserNameList_PH_First(strUserName);
                }
            }

            lblTotalAmountPH_First.Text = ListPH_First.Sum(m => m.Amount).Value.ToString("0.#####");

            grdPH_First.DataSource = ListPH_First;
            grdPH_First.DataBind();

        }

        public void LoadListGH()
        {

            if (this.ListGH == null)
            {
                string strUserName = ReplaceUserName_GH();
                if (string.IsNullOrEmpty(strUserName))
                {
                    //var numberGH = txtNumberGH.Text == string.Empty ? 0 : Convert.ToInt32(txtNumberGH.Text);
                    int? numberGH = (txtNumberGH.Text == string.Empty ? null : (int?)Convert.ToInt32(txtNumberGH.Text));

                    this.ListGH = ctlGH.SelectItemsByNumber(numberGH);
                }
                else
                {
                    this.ListGH = ctlGH.SelectItemsByNameList(strUserName);
                }
            }
            lblTotalAmountGH.Text = ListGH.Sum(m => m.Amount).Value.ToString("0.#####");

            grdGH.DataSource = ListGH;
            grdGH.DataBind();
        }

        public void LoadListAdminGH()
        {
            if (this.ListAdminGH == null)
            {
                this.ListAdminGH = ctlGH.SelectAdminMemberGH();
            }

            grdAdminList.DataSource = ListAdminGH;
            grdAdminList.DataBind();
        }

        public void LoadListMember()
        {
            if (this.LIST_MEMBERS == null)
            {
                this.LIST_MEMBERS = Singleton<MEMBERS_BC>.Inst.SelectAllItems();
            }
        }


        public List<GH_Info> GetListAdminSelectedForGH()
        {
            var lst = new List<GH_Info>();

            foreach (GridViewRow row in grdAdminList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (row.Cells[4].FindControl("chkIsSelected") as CheckBox);

                    if (chk.Checked)
                    {
                        var oGHInfo = new GH_Info();
                        Label username = row.Cells[1].FindControl("lblUserName") as Label;
                        Label createdate = row.Cells[2].FindControl("lblCreateDate") as Label;
                        TextBox amount = row.Cells[3].FindControl("txtAmount") as TextBox;
                        HiddenField codeid = row.Cells[4].FindControl("hidCodeId") as HiddenField;

                        //oGHInfo.CreateDate = DateTime.ParseExact(row.Cells[2].Text, "dd/MM/yyyy HH:mm:ss", null);                        

                        oGHInfo.CodeId = codeid.Value;
                        oGHInfo.CreateDate = Convert.ToDateTime("1 jan 2016");
                        oGHInfo.Username = username.Text;
                        oGHInfo.Amount = (amount.Text == string.Empty ? 0 : Convert.ToDecimal(amount.Text));
                        oGHInfo.CurrentAmount = 0;
                        oGHInfo.Status = 0;

                        lst.Add(oGHInfo);
                    }
                }
            }

            return lst;
        }

        public void TranferAdminToGH()
        {
            if (this.ListAdminGH_Selected == null)
            {
                ListAdminGH_Selected = GetListAdminSelectedForGH();
            }

            // dua len GH
            foreach (var o in ListAdminGH_Selected)
            {
                ListGH.Add(o);
                ListGH = ListGH.OrderBy(m => m.CreateDate).ToList();
                // xoa duoi list admin gh
                var oFind = ListAdminGH.Where(m => m.CodeId == o.CodeId).FirstOrDefault();
                if (oFind != null)
                {
                    ListAdminGH.Remove(oFind);
                }
            }

            // bind lai 2 list
            LoadListGH();

            LoadListAdminGH();

            // reset selected list
            ListAdminGH_Selected = null;
        }

        public List<PH_Info> GetList_PH_First_SelectedForPH()
        {
            var lst = new List<PH_Info>();

            foreach (GridViewRow row in grdPH_First.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (row.Cells[4].FindControl("chkIsSelected") as CheckBox);

                    if (chk.Checked)
                    {
                        var oPHInfo = new PH_Info();
                        Label username = row.Cells[1].FindControl("lblUserName") as Label;
                        Label createdate = row.Cells[2].FindControl("lblCreateDate") as Label;
                        Label amount = row.Cells[3].FindControl("lblAmount") as Label;
                        HiddenField codeid = row.Cells[4].FindControl("hidCodeId") as HiddenField;
                        HiddenField create_date = row.Cells[4].FindControl("hidCreateDate") as HiddenField;
                        HiddenField phId = row.Cells[4].FindControl("hidID") as HiddenField;

                        oPHInfo.ID = Convert.ToInt32(phId.Value);
                        oPHInfo.CodeId = codeid.Value;
                        oPHInfo.CreateDate = Convert.ToDateTime(create_date.Value);
                        oPHInfo.Username = username.Text;
                        oPHInfo.Amount = Convert.ToDecimal(amount.Text);
                        oPHInfo.CurrentAmount = Convert.ToDecimal(amount.Text);
                        oPHInfo.Status = 0;
                        lst.Add(oPHInfo);
                    }
                }
            }

            return lst;
        }

        public void Tranfer_PH_First_ToPH()
        {
            if (this.ListPH_First_Selected == null)
            {
                ListPH_First_Selected = GetList_PH_First_SelectedForPH();
            }

            // dua len PH
            foreach (var o in ListPH_First_Selected)
            {
                ListPH.Add(o);
                ListPH = ListPH.OrderBy(m => m.CreateDate).ToList();
                // xoa duoi list admin ph
                var oFind = ListPH_First.Where(m => m.CodeId == o.CodeId).FirstOrDefault();
                if (oFind != null)
                {
                    ListPH_First.Remove(oFind);
                }
            }

            // bind lai 2 list
            LoadListPH();

            LoadListPH_First();

            // reset selected list
            ListPH_First_Selected = null;
        }

        public void ResetAllSessionList()
        {
            this.ListPH = null;
            this.ListPH_First = null;
            this.ListPH_First_Selected = null;
            this.ListGH = null;
            this.ListAdminGH = null;
            this.ListAdminGH_Selected = null;
            this.ListAdminGH_FINAL = null;
            this.COMMAND = null;
            this.LIST_COMMAND_DETAIL = null;
            this.LIST_MEMBERS = null;

            LoadListPH();
            LoadListPH_First();
            LoadListGH();
            LoadListAdminGH();
            LoadListMember();
            ResetCommandList();
        }

        public void ResetCommandList()
        {
            grdCommandDetails.DataSource = null;
            grdCommandDetails.DataBind();
        }

        public void BindCommand(List<COMMAND_DETAIL> lstDetail)
        {
            grdCommandDetails.DataSource = lstDetail;
            grdCommandDetails.DataBind();
        }
        #endregion


        #region "Paging gridview"
        protected void grdPH_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPH.PageIndex = e.NewPageIndex;
            LoadListPH();
        }

        protected void grdPH_First_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPH_First.PageIndex = e.NewPageIndex;
            LoadListPH_First();
        }

        protected void grdGH_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGH.PageIndex = e.NewPageIndex;
            LoadListGH();
        }

        protected void grdAdminList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAdminList.PageIndex = e.NewPageIndex;
            LoadListAdminGH();
        }

        protected void grdCommandDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (this.LIST_COMMAND_DETAIL != null)
            {
                grdCommandDetails.PageIndex = e.NewPageIndex;
                BindCommand(this.LIST_COMMAND_DETAIL);
            }
        }
        #endregion

        #region "Utils"
        public T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

        public string StatusToString(int status)
        {
            switch (status)
            {
                case (int)Constants.COMMAND_STATUS.Pending:
                    return Constants.COMMAND_STATUS.Pending.ToString();
                case (int)Constants.COMMAND_STATUS.PH_Success:
                    return Constants.COMMAND_STATUS.PH_Success.ToString();
                case (int)Constants.COMMAND_STATUS.Success:
                    return Constants.COMMAND_STATUS.Success.ToString();
                default:
                    return string.Empty;
            }
        }

        public string CssStatus(int status)
        {
            switch (status)
            {
                case (int)Constants.COMMAND_STATUS.Pending:
                    return "label label-primary";
                case (int)Constants.COMMAND_STATUS.PH_Success:
                    return "label label-info";
                case (int)Constants.COMMAND_STATUS.Success:
                    return "label label-danger";
                default:
                    return "label label-primary";
            }
        }

        public string AccountBriefInfoByCodeId(string CodeId)
        {
            var user = LIST_MEMBERS.Where(m => m.CodeId == CodeId).SingleOrDefault();
            string briefInfo = user.Username + "/" + user.Phone;

            return briefInfo;
        }
        #endregion

        #region "button click"
        protected void btnLoadPHbyNumber_Click(object sender, EventArgs e)
        {
            // reset list PH
            ListPH = null;

            // load lai theo so luong PH nhap
            LoadListPH();
        }

        protected void btnLoadGHbyNumber_Click(object sender, EventArgs e)
        {
            // reset list PH
            ListGH = null;

            // load lai theo so luong PH nhap
            LoadListGH();
        }

        protected void btnLoadPH_First_byNumber_Click(object sender, EventArgs e)
        {
            // reset list PH
            ListPH_First = null;

            // load lai theo so luong PH nhap
            LoadListPH_First();
        }


        protected void btnTranferToGHList_Click(object sender, EventArgs e)
        {
            TranferAdminToGH();
        }

        protected void btnTranferToPHList_Click(object sender, EventArgs e)
        {
            Tranfer_PH_First_ToPH();
        }

        protected void btnResetAllList_Click(object sender, EventArgs e)
        {
            ResetAllSessionList();
        }

        protected void btnResetAllPHList_Click(object sender, EventArgs e)
        {
            ResetAllSessionList();
        }

        protected void btnCreateCommand_Click(object sender, EventArgs e)
        {
            // lay danh sach admin GH
            var _listGH_Admin = ListGH.Where(m => System.Text.RegularExpressions.Regex.IsMatch(m.CodeId, "008.*")).ToList();
            this.ListAdminGH_FINAL = _listGH_Admin;

            // danh sach PH - GH
            var _listPH = DeepCopy<List<PH_Info>>(ListPH);
            var _listGH = DeepCopy<List<GH_Info>>(ListGH);

            this.command = new COMMAND();
            this._ListCommand = new List<COMMAND_DETAIL>();

            // kiem tra danh sach PH, GH 
            if (_listPH.Sum(m => m.Amount).Value == _listGH.Sum(m => m.Amount).Value)
            {
                if (_listPH.Count > 0 && _listGH.Count > 0)
                {
                    XepLenh(ref _listPH, ref _listGH, ref command, ref _ListCommand);

                    // gan session
                    this.COMMAND = command;
                    this.LIST_COMMAND_DETAIL = _ListCommand;

                    // bind danh sach lenh
                    BindCommand(LIST_COMMAND_DETAIL);

                }
                else
                {
                    // ko co thi dua ra thong bao
                    TNotify.Alerts.Danger("List GH or PH is empty", true);
                }
            }
            else
            {
                TNotify.Alerts.Danger("Total amount PH is not equal total amount GH", true);
            }
        }
        protected void btnSaveCommand_Click(object sender, EventArgs e)
        {
            try
            {

                var ctlCommand = new COMMAND_BC();

                if (this.COMMAND != null && this.LIST_COMMAND_DETAIL.Count > 0)
                {
                    ctlCommand.InsertWithTransaction(COMMAND, LIST_COMMAND_DETAIL, ListAdminGH_FINAL);

                    // Gui mail sau khi tao lenh PH - GH thanh cong
                    SendMailAfterCreateCommand(LIST_COMMAND_DETAIL);

                    ResetAllSessionList();

                    TNotify.Toastr.Success("Create command PH - GH successfull", "Create command PH - GH", TNotify.NotifyPositions.toast_top_full_width, true);
                }
                else
                {
                    throw new Exception("Not have command detail");
                }

            }
            catch (Exception ex)
            {
                TNotify.Alerts.Danger(ex.Message, true);
            }

            Response.Redirect("CreateCommandPH_GH.aspx");

        }
        #endregion

        public void XepLenh(ref List<PH_Info> _ListPH, ref List<GH_Info> _ListGH, ref COMMAND command, ref List<COMMAND_DETAIL> _ListCommand)
        {
            var username = Singleton<BITCurrentSession>.Inst.SessionMember.Username;
            DateTime _datecreate = DateTime.Now;

            // tao lenh master
            command = new COMMAND { DateCreate = _datecreate, UserCreate = username, CommandCode = DateTime.Today.ToShortDateString().Replace(@"/", "_") };

            // tao lenh child
            COMMAND_DETAIL cmd_detail;

            foreach (var p in _ListPH)
            {
                // kiem tra con GH de cho nua ko -> neu ko con thi dung lai
                int iGH_remaining = _ListGH.Where(g => g.Amount != g.CurrentAmount).Count();
                // lap den khi PH cho di het (currentAmount = 0)
                while (p.CurrentAmount != 0 && iGH_remaining > 0)
                {
                    foreach (var g in _ListGH.Where(g => g.Amount != g.CurrentAmount && g.CodeId != p.CodeId).ToList())
                    {
                        //if (p.CodeId == g.CodeId) continue;

                        // chi duyet tren nhung thang GH chua nhan du                       
                        if (g.Amount != g.CurrentAmount)
                        {                            
                            if (g.CurrentAmount == 0)
                            {
                                // duyet lan dau
                                if (p.CurrentAmount - g.Amount < 0)
                                {
                                    // TH: PH thieu cho GH                                                                      
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = p.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                        ,
                                        ConfirmGH = false
                                        ,
                                        ConfirmPH = false
                                    };
                                    // ----------------- //                                    
                                    _ListCommand.Add(cmd_detail);



                                    g.CurrentAmount = g.Amount - p.CurrentAmount;   // neu PH voi 1 GH moi


                                    p.CurrentAmount = 0;

                                    break;

                                }
                                else if (p.CurrentAmount - g.Amount == 0)   // PH du cho GH 1 lan
                                {
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = p.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                        ,
                                        ConfirmGH = false
                                        ,
                                        ConfirmPH = false
                                    };
                                    // ----------------- //                                    
                                    _ListCommand.Add(cmd_detail);

                                    g.CurrentAmount = g.Amount;
                                    p.CurrentAmount = 0;
                                    break;
                                }
                                else
                                {
                                    // TH: PH thua cho GH
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = g.Amount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                        ,
                                        ConfirmGH = false
                                        ,
                                        ConfirmPH = false
                                    };
                                    // ----------------- //                                    
                                    _ListCommand.Add(cmd_detail);


                                    g.CurrentAmount = g.Amount;

                                    if (p.CurrentAmount != p.Amount)
                                        p.CurrentAmount = p.CurrentAmount - g.Amount;   // neu da PH roi thi lay current - g.amount
                                    else
                                        p.CurrentAmount = p.Amount - g.Amount;  // neu chua PH

                                    break;
                                }
                            }
                            else
                            {
                                // duyet tiep neu chua gh du?
                                if (p.CurrentAmount - g.CurrentAmount < 0)
                                {
                                    // van chua du
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = p.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                        ,
                                        ConfirmGH = false
                                        ,
                                        ConfirmPH = false
                                    };
                                    // ----------------- //
                                    _ListCommand.Add(cmd_detail);
                                    
                                    g.CurrentAmount = g.CurrentAmount - p.CurrentAmount;
                                    p.CurrentAmount = 0;

                                    break;
                                }
                                else if (p.CurrentAmount - g.CurrentAmount == 0)
                                {
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = p.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                        ,
                                        ConfirmGH = false
                                        ,
                                        ConfirmPH = false
                                    };
                                    // ----------------- //
                                    _ListCommand.Add(cmd_detail);

                                    p.CurrentAmount = 0;
                                    g.CurrentAmount = g.Amount;

                                    break;
                                }
                                else
                                {
                                    // du roi
                                    // ----------------- //
                                    cmd_detail = new COMMAND_DETAIL
                                    {
                                        CodeId_From = p.CodeId
                                        ,
                                        CodeId_To = g.CodeId
                                        ,
                                        DateCreate = _datecreate
                                        ,
                                        Amount = g.CurrentAmount
                                        ,
                                        Status = (int)Constants.COMMAND_STATUS.Pending
                                        ,
                                        PH_ID = p.ID
                                        ,
                                        GH_ID = g.ID
                                        ,
                                        ConfirmGH = false
                                        ,
                                        ConfirmPH = false
                                    };
                                    // ----------------- //
                                    _ListCommand.Add(cmd_detail);

                                    p.CurrentAmount = p.CurrentAmount - g.CurrentAmount;
                                    g.CurrentAmount = g.Amount;

                                    break;
                                }
                            }
                        }
                    }
                    iGH_remaining = _ListGH.Where(g => g.Amount != g.CurrentAmount).Count();
                }

            }
        }


        #region "Mail"
        public void SendMailAfterCreateCommand(List<COMMAND_DETAIL> lstCmdDetails)
        {
            foreach (var d in lstCmdDetails)
            {
                SendMailTo_PH_GH_User(d);
            }
        }

        public void SendMailTo_PH_GH_User(COMMAND_DETAIL command)
        {
            var ctlMem = new MEMBERS_BC();
            var userFrom = ctlMem.SelectItem(command.CodeId_From);
            var userTo = ctlMem.SelectItem(command.CodeId_To);

            string sSubject = "HELP96.GLOBAL PH-GH";

            // PH
            StringBuilder strBuilder = new StringBuilder();

            //strBuilder.Append("<html>");
            //strBuilder.Append("<head></head>");
            //strBuilder.Append("<body>");
            //strBuilder.Append("<table>");
            //strBuilder.AppendLine("<tr><td><b>Hello  " + userFrom.Username + "</b><br/></td></tr>");
            //strBuilder.AppendLine("<tr><td><b>You have PH with: " + userTo.Username + "/" + userTo.Phone + "</b><br/></td></tr>");
            //strBuilder.AppendLine("<tr><td><b>Amount: " + command.Amount.ToString() + " USD </b><br/></td></tr>");
            //strBuilder.AppendLine("<b><a href='http://help96.org'>http://help96.org </a></b><br/>");
            //strBuilder.AppendLine("<tr><td><b>Please contact to your upline or  HELP96's support to support you everything. </b><br/></td></tr>");
            //strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            //strBuilder.AppendLine("<tr><td><b><br/>HELP96.GLOBAL</b><br/></td></tr>");
            //strBuilder.Append("</table>");
            //strBuilder.Append("</body>");
            //strBuilder.Append("</html>");

            strBuilder.Append("<html>");
            strBuilder.Append("<head></head>");
            strBuilder.Append("<body>");
            strBuilder.Append("<table>");
            strBuilder.AppendLine("<tr><td><b>Xin chào  " + userFrom.Username + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Bạn có lệnh PH tới tài khoản: " + userTo.Username + "/" + userTo.Phone + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Tổng số tiền: " + command.Amount.ToString() + " USD </b><br/></td></tr>");
            strBuilder.AppendLine("<b><a href='http://help96.org'>http://help96.org </a></b><br/>");
            strBuilder.AppendLine("<tr><td><b>Liên hệ với tài khoản cấp trên hoặc bộ phận hỗ trợ của HELP96 để được giải đáp mọi thắc mắc. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/>HELP96.GLOBAL</b><br/></td></tr>");
            strBuilder.Append("</table>");
            strBuilder.Append("</body>");
            strBuilder.Append("</html>");


            Mail.Send(userFrom.Email, sSubject, strBuilder.ToString());

            // GH
            StringBuilder strGH = new StringBuilder();

            //strGH.Append("<html>");
            //strGH.Append("<head></head>");
            //strGH.Append("<body>");
            //strGH.Append("<table>");
            //strGH.AppendLine("<tr><td><b>Hello  " + userTo.Username + "</b><br/></td></tr>");
            //strGH.AppendLine("<tr><td><b>you will get GH from account: " + userFrom.Username + "/" + userFrom.Phone + "</b><br/></td></tr>");
            //strGH.AppendLine("<tr><td><b>Amount: " + command.Amount.ToString() + " USD </b><br/></td></tr>");
            //strGH.AppendLine("<b><a href='http://help96.org'>http://help96.org </a></b><br/>");
            //strGH.AppendLine("<tr><td><b>Please contact to your upline or  HELP96's support to support you everything. </b><br/></td></tr>");
            //strGH.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            //strGH.AppendLine("<tr><td><b><br/>HELP96.GLOBAL</b><br/></td></tr>");
            //strGH.Append("</table>");
            //strGH.Append("</body>");
            //strGH.Append("</html>");

            strGH.Append("<html>");
            strGH.Append("<head></head>");
            strGH.Append("<body>");
            strGH.Append("<table>");
            strGH.AppendLine("<tr><td><b>Xin chào  " + userTo.Username + "</b><br/></td></tr>");
            strGH.AppendLine("<tr><td><b>Bạn sẽ nhận GH từ tài khoản: " + userFrom.Username + "/" + userFrom.Phone + "</b><br/></td></tr>");
            strGH.AppendLine("<tr><td><b>Tổng số tiền: " + command.Amount.ToString() + " USD </b><br/></td></tr>");
            strGH.AppendLine("<b><a href='http://help96.org'>http://help96.org </a></b><br/>");
            strGH.AppendLine("<tr><td><b>Liên hệ với tài khoản cấp trên hoặc bộ phận hỗ trợ của HELP96 để được giải đáp mọi thắc mắc. </b><br/></td></tr>");
            strGH.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            strGH.AppendLine("<tr><td><b><br/>HELP96.GLOBAL</b><br/></td></tr>");
            strGH.Append("</table>");
            strGH.Append("</body>");
            strGH.Append("</html>");

            Mail.Send(userTo.Email, sSubject, strGH.ToString());
        }

        #endregion

        public string formatAmount(decimal amount)
        {
            return amount.ToString("0.#####");
        }
    }
}