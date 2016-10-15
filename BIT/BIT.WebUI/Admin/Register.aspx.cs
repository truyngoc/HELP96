using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BIT.WebUI.Admin
{

    public partial class Register : System.Web.UI.Page
    {
        public string strLink
        {
            get
            {
                string text = (string)ViewState["strLink"];
                if (text != null)
                    return text;
                else
                    return string.Empty;
            }
            set
            {
                ViewState["strLink"] = value;
            }
        }
        public static bool newRegist = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                //if (!Singleton<BITCurrentSession>.Inst.isLoginUser)
                //{
                //    //Response.Redirect("../Account/Login.aspx");
                //    string a = Request.Params[0];

                //    string strUserName = GiaiMa(a);
                //    if (String.IsNullOrEmpty("strUserName"))
                //    {
                //        return;
                //    }
                //    MEMBERS obj = Singleton<MEMBERS_BC>.Inst.SelectItemByUserName(strUserName);
                //    if (obj == null)
                //    {
                //        Response.Redirect("Login.aspx");
                //    }
                //    else
                //    {
                //        newRegist = true;
                //        lblUserNameSponsor.Text = obj.CodeId;
                //        Load_Category();
                //    }
                //}
                //else
                //{
                //    dynamic h1 = Request.Url.Host;
                //    dynamic h2 = Request.Url.Authority;
                //    lblLink.Text = h2 + "/Admin/Register.aspx?ref=" + MaHoa(Singleton<BITCurrentSession>.Inst.SessionMember.Username);
                //    newRegist = false;
                //    Load_Category();
                //}
            }
        }

        #region "Load danh muc"

        public void Load_Category()
        {
            if (newRegist)
            {
                Load_SNUOC();
            }
            else
            {

                Load_SNUOC();
                Load_UpLine(Singleton<BITCurrentSession>.Inst.SessionMember.CodeId);
            }
        }

        public void Load_SNUOC()
        {
            SNUOC_BC ctlNuoc = new SNUOC_BC();

            var lst = ctlNuoc.SelectAllItems();

            ddlCountry.DataSource = lst;
            ddlCountry.DataTextField = "NAME";
            ddlCountry.DataValueField = "CODE";
            ddlCountry.DataBind();

            SetDefaultValueDropDownList(ddlCountry);
        }

        public void Load_UpLine(string CodeId)
        {
            MEMBERS_BC ctlMember = new MEMBERS_BC();

            var lst = ctlMember.SelectUplineOfUserCreate(CodeId);

            //ddlUpLine.DataSource = lst;
            //ddlUpLine.DataTextField = "Username";
            //ddlUpLine.DataValueField = "CodeId";
            //ddlUpLine.DataBind();

            //SetDefaultValueDropDownList(ddlUpLine);
        }

        public void SetDefaultValueDropDownList(DropDownList ddl, string text = "", string value = "")
        {
            ddl.Items.Insert(0, new ListItem { Text = text, Value = value });
        }
        #endregion

        private string MaHoa(string UserName)
        {
            byte[] keyArray = null;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(UserName);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constants.KeyEncriptRef.ToString()));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public string GiaiMa(string toDecrypt)
        {
            string str = "";
            try
            {
                byte[] keyArray = null;
                toDecrypt = toDecrypt.Replace(" ", "+");
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constants.KeyEncriptRef));

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                str = UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                str = "";

            }
            finally
            {
            }
            return str;
        }

        #region "Get data on form"

        public MEMBERS GetDataOnForm()
        {
            MEMBERS obj = new MEMBERS();

            obj.Username = txtUserName.Text.Trim();
            obj.Password = txtPassword.Text;

            if (newRegist)
            {
                obj.CodeId_Sponsor = lblUserNameSponsor.Text;
                obj.Upline = Singleton<MEMBERS_BC>.Inst.SelectItem(obj.CodeId_Sponsor).Username;
            }
            else
            {
                obj.CodeId_Sponsor = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                obj.Upline = Singleton<BITCurrentSession>.Inst.SessionMember.Username;
            }


            obj.Password_PIN = txtPassword_PIN.Text;
            obj.Fullname = txtFullName.Text.Trim();

            obj.Phone = txtPhone.Text;
            obj.Email = txtEmail.Text.Trim();
            obj.Wallet = txtWallet.Text;
            obj.CreateDate = DateTime.Today;
            obj.Level = "0";
            obj.ExistsChild = false;
            obj.Status = (int)Constants.MEMBER_STATUS.WaitActive;
            obj.Country = ddlCountry.SelectedValue.ToString();
            //obj.ActiveDate = DBNull.Value; //@ActiveDate datetime
            //obj.ExpiredDate = DateTime.Now.AddMonths(1); //@ExpiredDate datetime
            obj.IsLock = 0;

            return obj;
        }

        #endregion

        #region "Register"
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (chk.Checked)
                    {
                        MEMBERS_BC ctlMember = new MEMBERS_BC();
                        MEMBERS obj = GetDataOnForm();

                        try
                        {
                            // check sponsor acc have execute PH success
                            DateTime dtExpired;
                            bool bSponsorPH = false;
                            if (newRegist)
                            {
                                dtExpired = Singleton<MEMBERS_BC>.Inst.SelectItem(obj.CodeId_Sponsor).ExpiredDate;
                            }
                            else
                            {
                                dtExpired = Singleton<BITCurrentSession>.Inst.SessionMember.ExpiredDate;
                            }

                            if (dtExpired == null)
                                bSponsorPH = false;
                            else if (dtExpired < DateTime.Now)
                                bSponsorPH = false;
                            else
                                bSponsorPH = true;

                            bool bExistAcc = ctlMember.IsExistsItem(obj.Username, obj.Wallet, obj.Email);

                            if (bSponsorPH)
                            {
                                if (!bExistAcc)
                                {
                                    ctlMember.InsertItem(obj);
                                    SendMailToRegisterUser(obj.Username, obj.Fullname, obj.Password, obj.Password_PIN, obj.Email);
                                    TNotify.Alerts.Information("Register member " + txtUserName.Text + " success.");
                                    //lblMessage.Text = "Register member " + txtUserName.Text + " success.";
                                    //Response.Write("<script>alert('" + lblMessage.Text + "');</script>");
                                    lblMessage.Visible = true;
                                    //Response.Redirect("../Admin/Dashboard.aspx");
                                }
                                else
                                {
                                    lblMessage.Text = "Username is already taken";
                                    lblMessage.Visible = true;
                                }
                            }
                            else
                            {
                                lblMessage.Text = "You can't create account member, please execute Active Package Invest transaction!";
                                lblMessage.Visible = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.ToString());
                            //throw new Exception(ex.ToString);
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "You must to agrre our term";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        #endregion

        #region "Mail"

        public void SendMailToRegisterUser(string username, string fullname, string password, string passwordPIN, string mailto)
        {
            string sSubject = "BITQUICK24 Information Account";

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head></head>");
            strBuilder.Append("<body>");
            strBuilder.Append("<table>");
            strBuilder.AppendLine("<tr><td><b>Hello  " + fullname + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Welcome to BITQUICK24 family </b><br/></td></tr></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your username is: " + username + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your password: " + password + " </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your transaction password: " + passwordPIN + " </b><br/></td></tr>");
            strBuilder.AppendLine("<b><a href='http://bitquick24.org'>http://bitquick24.org </a></b><br/>");
            strBuilder.AppendLine("<tr><td><b>Please contact to your upline or  BITQUICK24's support to support you everything. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/>BITQUICK24</b><br/></td></tr>");
            strBuilder.Append("</table>");
            strBuilder.Append("</body>");
            strBuilder.Append("</html>");

            Mail.Send(mailto, sSubject, strBuilder.ToString());
        }

        #endregion

        //protected void btnCopy_Click(object sender, EventArgs e)
        //{
        //    Clipboard.SetText(lblLink.ToString());
        //}
    }
}