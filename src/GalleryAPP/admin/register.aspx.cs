using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services;

namespace GalleryAPP.admin
{
    public partial class register : System.Web.UI.Page
    {
        private BLL.Admin.Account acc = new BLL.Admin.Account();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            else
            {
                if (tigger.Value == "sigup")
                {
                    string user = username.Value;
                    string emails = email.Value;
                    string md5 = pwd.Value;
                   
                    if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(emails) && !string.IsNullOrEmpty(md5))
                    {
                        if (RegisterUser(user, emails, md5))
                        {
                            Response.Redirect("login.aspx", true);
                        }
                        else
                        {
                            throw new Exception("注册失败.");
                        }
                    }
                }
            }
        }

 
        protected bool RegisterUser(string username, string email, string md5)
        {
            Model.Admin.Account account = new Model.Admin.Account();
            account.MD5Identify = md5;
            account.AccountName = username;
            account.Email = email;
            account.CreatedDate = DateTime.Now;
            account.Enable = 1;
            if (acc.Add(account) !=0)
            {
                return true;
            }
            return false;
        }

        protected bool UserExists(String username, String email)
        {
            string where=string.Empty;
            if (!String.IsNullOrEmpty(username))
            {
                where+=" and AccountName='"+username+"'";
            }
            else if(!string.IsNullOrEmpty(email))
            {
                where+=" and Email='"+email+"'";
            }
            return acc.GetRecordCount(where) >= 1;
        }

        public String CheckUserExists(String username, String email)
        {
            bool result = UserExists(username, email);
            if (result == true)
            {
                StringBuilder jeson = new StringBuilder("{validation_failed:{email:[{success: false,message: \"This is not vaid email.\"}]}}");
                return jeson.ToString();
            }
            return string.Empty;
        }

    }
}
