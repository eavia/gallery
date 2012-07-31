using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GalleryAPP
{
    public partial class Uploader :BasePage
    {
        public string STRUSERID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = (Request.Params["action"] ?? "NaN").ToString();
            if (action.Equals("0"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "temp", "$.dialog.close();var win = $.dialog.open.origin;win.location.reload();", true);
            }
            STRUSERID = this.CurrentAccount.Id.ToString();
        }
    }
}