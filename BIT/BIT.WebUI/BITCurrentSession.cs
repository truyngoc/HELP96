using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BIT.Objects;

namespace BIT.WebUI
{
    public class BITCurrentSession
    {
        public MEMBERS SessionMember
        {
            get
            {
                if (HttpContext.Current.Session["BIT_MemberInfoLogon"] != null)
                {
                    return HttpContext.Current.Session["BIT_MemberInfoLogon"] as MEMBERS;
                }
                return null;
            }
            set { HttpContext.Current.Session["BIT_MemberInfoLogon"] = value; }
        }

        public bool isLoginUser
        {
            get { return HttpContext.Current.Session["BIT_MemberInfoLogon"] != null; }
        }

        public void SignOut()
        {
            if (HttpContext.Current.Session["BIT_MemberInfoLogon"] != null)
            {
                HttpContext.Current.Session["BIT_MemberInfoLogon"] = null;
                HttpContext.Current.Session.Abandon();
            }
        }

    }
}