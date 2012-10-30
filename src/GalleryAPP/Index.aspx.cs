using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BLL.Admin;
using System.Data;

namespace GalleryAPP
{
    public partial class Index : Page
    {
        Account bll = new Account();
        BLL.Gallery gbll = new BLL.Gallery();
        BLL.Images ibll = new BLL.Images();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NodeLoad(object sender, NodeLoadEventArgs e)
        {
            string prefix = e.ExtraParams["prefix"] ?? "";

            if (!string.IsNullOrEmpty(e.NodeID))
            {

                if (e.NodeID.Equals("0"))
                {
                    DataTable table= gbll.GetAllList().Tables[0];

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow dr = table.Rows[i];
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = dr["Name"].ToString();
                        asyncNode.NodeID = dr["ID"].ToString();
                        e.Nodes.Add(asyncNode);
                    }
                }
                else
                {
                    string tmp=" Gallery={0}";
                    DataTable table = ibll.GetList(string.Format(tmp, e.NodeID));
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow dr = table.Rows[i];
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = dr["Title"].ToString();
                        asyncNode.NodeID = dr["ID"].ToString();
                        asyncNode.Leaf = true;
                        e.Nodes.Add(asyncNode);
                    }
                }
            }
        }


        protected void btnLogin_Click(object sender, DirectEventArgs e)
        {

            Model.Admin.Account acct = bll.GetSingleModel(txtUsername.Text, this.txtPassword.Text);
            if (acct != null)
            {
                System.Web.HttpCookie newcookie = new HttpCookie(GalleryAPP.Global.ApplicationName);
                newcookie["AccountName"] = txtUsername.Text;
                newcookie["Password"] = this.txtPassword.Text;
                newcookie.Expires = DateTime.MaxValue;
                this.Response.AppendCookie(newcookie);
                Session.Add("Account", acct);
                this.LoginWin.Hide();
                this.btnLoginStart.Hide();
                this.sbnMainMenu.Show();
                string template = " {0}! ";
                string username = this.txtUsername.Text;
                string password = this.txtPassword.Text;
                this.lblUserName.Html = string.Format(template, username, password);

            }
            else
            {
                X.Msg.Alert("Message", "用户名或密码错误！").Show();
            }
        }

    }
}