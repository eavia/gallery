using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GalleryAPP
{
    public partial class _default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SiteMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value.Equals("logout"))
            {
                string url = ("admin/login.aspx?rul=#url#".Replace("#url#", this.Request.Url.AbsoluteUri)+"&act=clr");
                Response.Redirect(url, true);
            }
            else
            {
                Server.Transfer(e.Item.Value);
            }
        }
    }
}
