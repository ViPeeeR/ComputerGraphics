using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Extentions
{
    public static class Extention
    {
        public static System.Drawing.Color ToRGB(this Structs.Color color)
        {
            return System.Drawing.Color.FromArgb(color.R, color.G, color.B);
        }
    }
}
