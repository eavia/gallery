using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Admin;

namespace GalleryAPP
{
    public partial class BasePage : System.Web.UI.Page
    {
        
        protected void OnBaseLoad()
        {
           object o= this.CurrentAccount.AccountName;
        }

        public Account CurrentAccount {
            get
            {
                string url=("admin/login.aspx?rul=#url#".Replace("#url#",this.Request.Url.AbsoluteUri));
                Account account = Session["Account"] as Account;
                if (account == null)
                {
                    Response.Redirect(url);
                }
                return account;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            OnBaseLoad();
            base.OnLoad(e);
        }

    }
}