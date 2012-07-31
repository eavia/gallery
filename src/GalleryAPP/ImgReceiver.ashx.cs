using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Model.Admin;

namespace GalleryAPP
{
    /// <summary>
    /// ImgReceiver 的摘要说明
    /// </summary>
    public class ImgReceiver : IHttpHandler
    {

        BLL.Images bll = new BLL.Images();
        public void ProcessRequest(HttpContext context)
        {
            Stream stream = null;
            HttpPostedFile file = null;
            string qgid = context.Request.Params["gid"];
            string quid = context.Request.Params["uid"];
            int gid = -1;
            int uid = -1;
            int.TryParse(qgid, out gid);
            int.TryParse(quid, out uid);
            if (gid == -1 || uid==-1)
            {
                return;
            }
            for (int f = 0, l = context.Request.Files.Count; f < l; f++)
            {
                file = context.Request.Files[f];
                if (file != null)
                {

                    stream = file.InputStream;
                    if (stream.CanRead && stream.Length != 0)
                    {
                        byte[] reads = new byte[stream.Length];
                        for (int i = 0; i < reads.Length; i++)
                        {
                            reads[i] = (byte)stream.ReadByte();
                        }
                        Model.Image image = new Model.Image();
                        image.Title = Guid.NewGuid().ToString();
                        image.UpdatedDate = DateTime.Now;
                        image.Data = reads;
                        image.UserID = uid;
                        image.Gallery = gid;
                        bll.AddImage(image);
                    }
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Redirect("Uploader.aspx?action=0", true);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}