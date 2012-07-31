using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace GalleryAPP.admin
{
    public partial class checkuser : System.Web.UI.Page
    {
        private BLL.Admin.Account acc = new BLL.Admin.Account();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = this.Request.Params["id"].ToString();
                string value = this.Request.Params["value"].ToString();
                bool isexists = false;
                if (id.IndexOf("email") >= 0)
                {
                    isexists = UserExists(null, value);
                }
                else
                {
                    isexists = UserExists(value, null);
                }
                isexists = !isexists;
                StringBuilder sb = new StringBuilder("{success: #boolean#,message: \"已存在。\"}");
                sb.Replace("#boolean#", isexists.ToString().ToLower());
                Response.Write(sb.ToString());
                Response.End();
                return;
            }
        }

        protected bool UserExists(String username, String email)
        {
            string where = string.Empty;
            if (!String.IsNullOrEmpty(username))
            {
                where += " Account='" + username + "'";
            }
            else if (!string.IsNullOrEmpty(email))
            {
                where += " Email='" + email + "'";
            }
            return acc.GetRecordCount(where) >= 1;
        }

    }
}