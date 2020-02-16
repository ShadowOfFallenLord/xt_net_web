using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace HW_Task_10.Content
{
    public partial class UserImage : System.Web.UI.Page
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
                using (Bitmap image = new Bitmap(100, 100))
                {
                    using (Graphics graphic = Graphics.FromImage(image))
                    {
                        graphic.Clear(Color.Black);
                        graphic.DrawLine(Pens.Red, 0, 0, 99, 99);

                        // Сохранить изображение в поток
                        Response.ContentType = "image/png";

                        // Создать PNG-изображение, хранящееся в памяти
                        MemoryStream mem = new MemoryStream();
                        image.Save(mem, System.Drawing.Imaging.ImageFormat.Png);

                        // Записать данные MemoryStream в выходной поток
                        mem.WriteTo(Response.OutputStream);
                    }
                }
            }
        }
    }
}