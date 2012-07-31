using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GalleryAPP
{
    public partial class GalleryForm : BasePage
    {

        BLL.Gallery galleryBll = new BLL.Gallery();
        BLL.Images imageBll = new BLL.Images();
        public static string ScrollValue = string.Empty;//滚动条位置


        protected void Page_Load(object sender, EventArgs e)
        {
            ScrollValue = divScrollValue.Value;
            if (!IsPostBack)
            {
                string value = "";
                if (!string.IsNullOrEmpty(value = Request["gid"]))
                {
                    this.galleryid.Value = value;
                    int gid = -1;
                    int.TryParse(value, out gid);
                    GalleryInfo_Bind(gid);
                    PhotoList_BindData(gid);
                    return;
                }
            }
        }

        void GalleryInfo_Bind(int gid)
        {
            Model.Gallery gallery = galleryBll.GetModel(gid);
            this.txtName.Text = gallery.Name.Trim() ;
            this.txtDescription.Text = gallery.Description.Trim();
        }

        void PhotoList_BindData(int gid)
        {
            pager.RecordCount = imageBll.GetRowCount(gid);
            this.photoList.DataSource = imageBll.GetPageData(gid, pager.StartRecordIndex, pager.EndRecordIndex);
            this.photoList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(galleryid.Value))
            {
                Model.Gallery gallery = new Model.Gallery();
                gallery.CreateDate = DateTime.Now;
                gallery.Autor = 1;
                gallery.Name = this.txtName.Text;
                gallery.Description = this.txtDescription.Text;
                galleryBll.Add(gallery);
            }
            else
            {
                int gid = -1;
                int.TryParse(this.galleryid.Value, out gid);
                Model.Gallery gallery = galleryBll.GetModel(gid);
                gallery.UpdateDate = DateTime.Now;
                gallery.Name = this.txtName.Text;
                gallery.Description = this.txtDescription.Text;
                galleryBll.Update(gallery);

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtDescription.Text = "";
            this.txtName.Text = "";
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            int gid = -1;
            int.TryParse(galleryid.Value, out gid);
            PhotoList_BindData(gid);
        }

        protected void ibnRemove_Command(object sender, CommandEventArgs e)
        {
            bool b = imageBll.RemoveImage(int.Parse(e.CommandArgument.ToString()));
            if (b)
            {
                int gid = -1;
                int.TryParse(galleryid.Value, out gid);
                PhotoList_BindData(gid);
            }
        }
    }
}