using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HW_Task_10.Content
{
    public partial class AwardImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = -1;

            if (!int.TryParse(Request["id"], out id) || id < 0 || id >= LogicKeeper.Logic.AwardCount)
            {
                //
            }
            else
            {
                ImageConverter converter = new ImageConverter();
                using (var buffer = new MemoryStream(LogicKeeper.Logic.GetAward(id).Image.Content))
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