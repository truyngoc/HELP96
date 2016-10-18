using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using BIT.Controller;
using BIT.Objects;
using BIT.Common;

namespace BIT.WebUI.Admin
{
    public partial class Tree : System.Web.UI.Page
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
                    var ParentCodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId;
                    List<MEMBERS> lstMember = new List<MEMBERS>();

                    if (Singleton<BITCurrentSession>.Inst.SessionMember.Username.ToUpper().IndexOf("ADMINISTRATOR") > 0)
                    {
                        lstMember = Singleton<MEMBERS_BC>.Inst.Tree_GetData(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    }
                    else
                    {
                        lstMember = Singleton<MEMBERS_BC>.Inst.Tree_GetItem_By_CodeId(ParentCodeId);
                    }

                    List<MemberTree> lstTreemember = new List<MemberTree>();
                    foreach (var _item in lstMember)
                    {
                        MemberTree itemTree = new MemberTree(_item);
                        lstTreemember.Add(itemTree);
                    }
                    if (lstMember != null && lstMember.Count > 0)
                    {
                        MemberTree root = new MemberTree();
                        root.CodeId_Sponsor = null;
                        root.CodeId = Singleton<BITCurrentSession>.Inst.SessionMember.CodeId_Sponsor;
                        root.Fullname = "Đây là root node";
                        root.IsLock = 1;
                        lstTreemember.Add(root);


                        var tree = lstTreemember.ToTree();
                        ltrTree.Text = this.ShowTree(tree.Childens);
                    }
                }
            }
        }

        #region "Show Tree"
        private string ShowTree(List<MemberTree> lstTreeMember)
        {
            string str = "";
            foreach (var item in lstTreeMember)
            {
                if (item.IsLock != null && item.IsLock == 1)
                {
                    str = str + @"<li><img src=""/Content/Tree/Styles/jquery-treeview/images/icon_lock.gif"" class=""img-tree"" width=""13px"" height=""20px"" /> &nbsp;"
                        + item.Username + " / "
                        + item.Fullname + " / "
                        + item.Phone + " </a>";
                }
                else
                {
                    str = str + @"<li><img src=""/Content/Tree/Styles/jquery-treeview/images/file.gif"" class=""img-tree""  width=""13px"" height=""20px""  /> &nbsp;"
                        + item.Username + " / "
                        + item.Fullname + " / "
                        + item.Phone + "</a>";
                }

                if (item.Childens.Any())
                {
                    str = str + "<ul>";
                    str = str + this.ShowTree(item.Childens);
                    str = str + "</ul>";
                }

                str = str + "</li>";
            }

            return str;
        }

        private void PopulateTreeView(List<MEMBERS> lstMember, string ParentCodeId, TreeNode treeNode)
        {
            foreach (var item in lstMember)
            {
                TreeNode child = new TreeNode
                {
                    Text = item.Username,
                    Value = item.CodeId
                };


                if (item.ExistsChild)
                {
                    dynamic lstChild = lstMember.FindAll(o => o.CodeId_Sponsor == child.Value);
                    PopulateTreeView(lstChild, child.Value, child);
                }
                else
                {
                    treeNode.ChildNodes.Add(child);
                }

            }
        }
        #endregion

       
    }

    public static class ExtensionMember
    {
        #region "Extension method"
        public static MemberTree ToTree(this List<MemberTree> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            var root = list.FirstOrDefault(x => x.CodeId_Sponsor == null);
            if (root == null)
            {
                throw new InvalidOperationException("root == null");
            }

            PopulateChildren2(root, list);
            return root;
        }

        private static void PopulateChildren2(MemberTree node, List<MemberTree> all)
        {
            var childs = all.Where(x => x.CodeId_Sponsor == node.CodeId).ToList();
            foreach (var item in childs)
            {
                node.ExistsChild = true;

                node.Childens.Add(item);
            }

            foreach (var item in childs)
            {
                all.Remove(item);
            }

            foreach (var item in childs)
            {
                PopulateChildren2(item, all);
            }
        }
        #endregion
    }
}