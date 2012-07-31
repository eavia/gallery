using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace GalleryAPP
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, DirectEventArgs e)
        {
            X.Msg.Alert("Server Time", DateTime.Now.ToLongTimeString()).Show();
        }
    }
}