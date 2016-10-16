using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.Objects;
using BIT.Controller;
using BIT.Common;
using Newtonsoft.Json;
using System.Text;

namespace BIT.WebUI.Admin
{
    public class ReCaptchaClass
    {
        public static string Validate(string EncodedResponse)
        {
            var client = new System.Net.WebClient();

            //string PrivateKey = "6LcH-v8SerfgAPlLLffghrITSL9xM7XLrz8aeory";
            string PrivateKey = "6LfcgSgTAAAAAOFiMLkyf3_cdVs6bOpBZ83rGk00";

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));

            var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);

            return captchaResponse.Success;
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }

    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //string EncodedResponse = Request.Form["g-Recaptcha-Response"];

                //bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "True" ? true : false);

                ////IsCaptchaValid = true;

                //if (IsCaptchaValid)
                //{
                //Valid Request
                var login_info = Singleton<MEMBERS_BC>.Inst.SelectItemByUserPass(txtUserName.Text, txtPassword.Text);

                if (login_info != null)
                {
                    //if (login_info.Status == 3)
                    //{
                    //    lblMessage.Text = "Account is locked.";
                    //    lblMessage.Visible = true;
                    //}
                    //else
                    //{
                    Singleton<BITCurrentSession>.Inst.SessionMember = login_info;
                    lblMessage.Visible = false;
                    Response.Redirect("~/Admin/Dashboard.aspx");
                    //}
                }
                else
                {
                    lblMessage.Text = "*Username or password incorrect";
                    lblMessage.Visible = true;
                }
            }


            //}
        }


        protected void lnkLostPass_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                lblMessage.Text = "*Username can not blank";
                lblMessage.Visible = true;
            }
            else
            {
                var login_info = Singleton<MEMBERS_BC>.Inst.SelectItemByUserName(txtUserName.Text);
                if (login_info != null)
                {
                    if (login_info.IsLock == 1)
                    {
                        lblMessage.Text = "Account is locked.";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        SendMailToFogotPass(login_info.Username, login_info.Fullname, login_info.Password, login_info.Email);
                        string strPHComplete = "alert('Please check your email " + login_info.Email + " to receive your password !');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", strPHComplete, true);
                    }
                }
                else
                {
                    lblMessage.Text = "*Username is not exist!";
                    lblMessage.Visible = true;
                }

            }
        }

        public void SendMailToFogotPass(string username, string fullname, string password, string mailto)
        {
            string sSubject = "THÔNG BÁO TỪ HELP96.GLOBAL";

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head></head>");
            strBuilder.Append("<body>");
            strBuilder.Append("<table>");
            strBuilder.AppendLine("<tr><td><b>Xin chào bạn  " + fullname + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Chào mừng bạn đến với cộng đồng HELP96.GLOBAL </b><br/></td></tr></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Tên đăng nhập của bạn: " + username + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Mật khẩu đăng nhập: " + password + " </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Để bảo vệ tài khoản, bạn hãy thay đổi mật khẩu ngay khi đăng nhập được vào hệ thống. </b><br/></td></tr><br/>");
            strBuilder.AppendLine("<tr><td><b>Trong quá trình sử dụng nếu có vướng mắc, bạn hãy liên hệ với người bảo trợ hoặc ban truyền thông để được hỗ trợ. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Xin cảm ơn và chúc thành công.</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/>HELP96.GLOBAL</b><br/></td></tr>");
            strBuilder.Append("</table>");
            strBuilder.Append("</body>");
            strBuilder.Append("</html>");

            Mail.Send(mailto, sSubject, strBuilder.ToString());
        }
    }
}