using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW_Task_11
{
    public partial class UserImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = -1;

            if (!int.TryParse(Request["id"], out id) || id < 1)
            {
                //
            }
            else
            {
                ImageConverter converter = new ImageConverter();
                using (var buffer = new MemoryStream(LogicKeeper.Logic.GetUserInfo(id).Image))
                {
                    using (Bitmap image = new Bitmap(buffer))
                    {
                        Response.ContentType = "image/png";

                        double mult = 1;
                        if (image.Width > image.Height)
                        {
                            mult = LogicKeeper.ImageWidth * 1.0 / image.Width;
                        }
                        else
                        {
                            mult = LogicKeeper.ImageHeight * 1.0 / image.Height;
                        }

                        float w = (float)(image.Width * mult);
                        float h = (float)(image.Height * mult);

                        using (Bitmap res = new Bitmap((int)(w + 1), (int)(h + 1)))
                        {
                            using (Graphics g = Graphics.FromImage(res))
                            {
                                g.DrawImage(image, 0, 0, w, h);
                            }

                            MemoryStream mem = new MemoryStream();
                            res.Save(mem, System.Drawing.Imaging.ImageFormat.Png);

                            mem.WriteTo(Response.OutputStream);
                        }
                    }
                }
            }
        }
    }
}