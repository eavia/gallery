using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using System.IO;
using System.Threading;

namespace GalleryAPP.ImageTools
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class FetchImage : IHttpHandler
    {
        private BLL.Images bll = new Images();

        ParameterizedThreadStart picreader = new ParameterizedThreadStart(ReadPictureById);

        private class ReaderParameter 
        {
            int imageId = -1;

            public int ImageId
            {
                get { return imageId; }
                set { imageId = value; }
            }

            bool isThumbnail = false;

            public bool IsThumbnail
            {
                get { return isThumbnail; }
                set { isThumbnail = value; }
            }
            BLL.Images dataSource = null;

            public BLL.Images DataSource
            {
                get { return dataSource; }
                set { dataSource = value; }
            }
            string isNoImagePath = string.Empty;

            public string IsNoImagePath
            {
                get { return isNoImagePath; }
                set { isNoImagePath = value; }
            }

            System.Drawing.Image cathedImage = null;

            public System.Drawing.Image CathedImage
            {
                get { return cathedImage; }
                set { cathedImage = value; }
            }

            bool success = false;

            public bool Success
            {
                get { return success; }
                set { success = value; }
            }
        }

        private static void ReadPictureById(object o)
        {
            ReaderParameter par = o as ReaderParameter;
            System.Drawing.Image tmpImg= null;
            try
            {
                MemoryStream str = null;
                if (!par.ImageId.Equals(-1))
                {
                    // 根据图片数据的id从数据库中获取流
                    str = new MemoryStream(par.DataSource.GetImageById(par.ImageId).Data);
                    tmpImg = System.Drawing.Image.FromStream(str, true);
                }
                else
                {
                    tmpImg = System.Drawing.Image.FromStream(File.OpenRead(par.IsNoImagePath), true);
                }
                if (par.IsThumbnail)
                {
                    tmpImg = Utility.ImageUtil.GetReducedImage(tmpImg, 200, 200, .09);
                }

                par.CathedImage = tmpImg;
                par.Success = true;
                return;

            }
            catch
            {
                FileStream fstr = null;
                try
                {
                    fstr = File.OpenRead(par.IsNoImagePath); 
                    tmpImg = System.Drawing.Image.FromStream(fstr, true);
                    par.CathedImage = tmpImg;
                    return;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fstr.Close();
                }
            }
        }

        static string noimagePath = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(noimagePath))
            {
                noimagePath = context.Server.MapPath("~\\images\\noimage.png");
            }
            int imageID = -1;
            int.TryParse((context.Request.Params["id"] ?? "-1").ToString(), out imageID);
            bool isThumbnail = bool.Parse((context.Request.Params["thumbnail"] ?? "false").ToString());

            ReaderParameter par = new ReaderParameter();

            par.ImageId = imageID;
            par.IsThumbnail = isThumbnail;
            par.IsNoImagePath = noimagePath;
            par.DataSource = bll;
            par.IsThumbnail = isThumbnail;

            Thread thread = new Thread(picreader);

            thread.Start(par);
            //如果超过500毫秒未读取出来就直接停止
            Thread.Sleep(500);

            if (!par.Success ||(thread.ThreadState != ThreadState.Stopped && thread.ThreadState != ThreadState.StopRequested ))
            {
                thread.Abort();
                FileStream fstr = null;
                try
                {
                    fstr = File.OpenRead(par.IsNoImagePath);
                    par.CathedImage = System.Drawing.Image.FromStream(fstr, true);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fstr.Close();
                }
            }
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Jpeg;
            par.CathedImage.Save(context.Response.OutputStream, format);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
