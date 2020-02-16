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

            if (!int.TryParse(Request["id"], out id) || id < 0 || id >= LogicKeeper.Logic.UserCount)
            {
                //
            }
            else
            {
                ImageConverter converter = new ImageConverter();
                using (var buffer = new MemoryStream(LogicKeeper.Logic.GetAward(id).Image))
                {
                    using (Bitmap image = new Bitmap(buffer))
                    {
                        Response.ContentType = "image/png";

                        MemoryStream mem = new MemoryStream();
                        image.Save(mem, System.Drawing.Imaging.ImageFormat.Png);

                        mem.WriteTo(Response.OutputStream);
                    }
                }
            }
        }
    }
}