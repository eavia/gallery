using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Admin;

namespace GalleryAPP.admin
{
    public partial class login : System.Web.UI.Page
    {
        Account bll = new Account();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = (this.Request["rul"] ?? "").ToString();
                if (!string.IsNullOrEmpty(url))
                {
                    this.redirect.Value = url;
                }
            }

            System.Web.HttpCookie oldcookie = this.Request.Cookies[GalleryAPP.Global.ApplicationName];
            string act = (this.Request["act"] ?? "").ToString();
            if (act.Equals("clr"))
            {
                Session.Remove("Account");
                Session.Clear();
                if (oldcookie != null)
                {
                    oldcookie.Expires = DateTime.Now.AddHours(-48);
                    HttpContext.Current.Response.Cookies.Add(oldcookie);
                }
                Response.Redirect("login.aspx");
            }
            else if (oldcookie != null)
            {
                username.Value = oldcookie["AccountName"];
                password.Value = oldcookie["Password"];
                Model.Admin.Account acct = bll.GetSingleModel(username.Value, password.Value);
                if (acct != null)
                {
                    System.Web.HttpCookie newcookie = new HttpCookie(GalleryAPP.Global.ApplicationName);
                    newcookie["AccountName"] = username.Value;
                    newcookie["Password"] = password.Value;
                    newcookie.Expires = DateTime.MaxValue;
                    this.Response.AppendCookie(newcookie);
                    Session.Add("Account", acct);
                }
                else
                {
                    lblMessage.Text = "登录失败了。";
                }
                if (!string.IsNullOrEmpty(this.redirect.Value))
                {
                    Response.Redirect(this.redirect.Value, true);
                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
            else if (tigger.Value == "login")
            {
                Model.Admin.Account acct = bll.GetSingleModel(username.Value, password.Value);
                if (acct != null)
                {
                    System.Web.HttpCookie newcookie = new HttpCookie(GalleryAPP.Global.ApplicationName);
                    newcookie["AccountName"] = username.Value;
                    newcookie["Password"] = password.Value;
                    newcookie.Expires = DateTime.MaxValue;
                    this.Response.AppendCookie(newcookie);
                    Session.Add("Account", acct);

                }
                else
                {
                    lblMessage.Text = "登录失败了。";
                }
                if (!string.IsNullOrEmpty(this.redirect.Value))
                {
                    Response.Redirect(this.redirect.Value, true);
                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
        }
    }
}
