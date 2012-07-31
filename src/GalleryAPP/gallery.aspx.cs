using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GalleryAPP
{
    public partial class gallery : BasePage
    {
        BLL.Gallery bll = new BLL.Gallery();
        BLL.Images ibll = new BLL.Images();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GralleryList_DataBind();
            }
        }

        private void GralleryList_DataBind()
        {
            this.gralleryList.DataSource = bll.GetAllList().Tables[0];
            this.gralleryList.DataBind();
        }

        //protected void imbRemove_Command(object sender, CommandEventArgs e)
        //{
        //    bool b = ibll.RemoveImage(int.Parse(e.CommandArgument.ToString()));
        //    if (b)
        //    {
        //        int gid = -1;
        //        int.TryParse(galleryid.Value, out gid);
        //        PhotoList_BindData(gid);
        //    }
        //}
    }
}