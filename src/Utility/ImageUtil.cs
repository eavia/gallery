using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace Utility
{
    public sealed class ImageUtil
    {
        public static Image GetReducedImage(Image ResourceImage, int Width, int Height)
        {
            try
            {
                int orgHeight = ResourceImage.Height;
                int orgWidth = ResourceImage.Width;
                int tWidth, tHeight, tLeft, tTop;
                double fscal = (double)Width / (double)Height;

                if (((double)orgWidth * fscal) > orgHeight)
                {
                    tWidth = Width;
                    tHeight = (int)((double)orgHeight * ((double)tWidth / orgWidth));
                    tLeft = 0;
                    tTop = (Height - tHeight) / 2;
                }
                else
                {
                    tHeight = Height;
                    tWidth = (int)((double)orgWidth * (double)tHeight / (double)orgHeight);
                    tLeft = (Width - tWidth) / 2;
                    tTop = 0;
                }
                if (tLeft < 0) tLeft = 0;
                if (tTop < 0) tTop = 0;
                Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                //从指定的 Image 对象创建新 Graphics 对象
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 0, bitmap.Width, bitmap.Height));

                //在指定位置并且按指定大小绘制 原图片 对象
                graphics.DrawImage(ResourceImage, new Rectangle(tLeft, tTop, tWidth, tHeight));
                return bitmap;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Image GetReducedImage(Image ResourceImage,int outWidth,int outHeight,double percent)
        {
            try
            {
                int orgWidth = ResourceImage.Width;
                int orgHeight = ResourceImage.Height;
                int newHeight, newWidth, Top, Left;
                double fscale =(double)orgWidth /(double)orgHeight;
                if ((double)orgWidth * fscale > orgHeight)
                {
                    //图片比较宽
                    newWidth = outWidth;
                    Left = 0;
                    newHeight = (int)((double)orgHeight * ((double)outWidth/(double)orgWidth));
                    Top = (outHeight / 2) - (newHeight / 2);
                   
                }
                else
                {
                    //图片比较长
                    newHeight = outHeight;
                    Top = 0;
                    newWidth =(int)((double)orgWidth * ( (double)outHeight/(double)orgHeight));
                    Left = (outWidth / 2) - (newWidth / 2);
                }

                Top = Top < 0 ? 0 : Top;
                Left = Left < 0 ? 0 : Left;
                Image ReducedImage;
                ReducedImage = ResourceImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
                Bitmap bitmap = new Bitmap(outWidth, outHeight, PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                graphics.DrawImage(ReducedImage, new Rectangle(Left, Top, newWidth, newHeight));
                return ReducedImage;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool ThumbnailCallback()
        {
            return false;
        }
    }
}
