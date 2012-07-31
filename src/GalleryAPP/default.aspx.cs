using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GalleryAPP
{
    public partial class Gallery : BasePage
    {
        BLL.Images bll = new BLL.Images();
        public string currentPageNo = String.Empty;
        public int PageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindData();
            }
        }

        void BindData()
        {
            pager.RecordCount = bll.GetRowCount(1);
            this.photoList.DataSource = bll.GetPageData(1,pager.StartRecordIndex, pager.EndRecordIndex);
            this.photoList.DataBind();
        }

        protected void imbRemove_Command(object sender, CommandEventArgs e)
        {
            bool b = bll.RemoveImage(int.Parse(e.CommandArgument.ToString()));
            if (b)
            {
                BindData();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
    }
}
