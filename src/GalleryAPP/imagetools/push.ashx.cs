using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Model.Admin;

namespace GalleryAPP.imagetools
{
    /// <summary>
    /// push 的摘要说明
    /// </summary>
    public class push : IHttpHandler
    {
        BLL.Images bll = new BLL.Images();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            HttpPostedFile hotFile = context.Request.Files[""];
            if (hotFile != null)
            {
                int id = int.Parse(context.Request.Params["uid"]);
                Stream stream = hotFile.InputStream;
                if (stream.CanRead)
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
                    image.UserID = id;
                    if (bll.AddImage(image))
                    {
                        context.Response.Write("1");
                        return;
                    }
                }
            }
            context.Response.Write("0");
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