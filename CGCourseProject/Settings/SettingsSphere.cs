using CGCourseProject.Logic;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Settings
{
    public class SettingsSphere
    {
        public Point3d Center { get; set; }
        public float Radius { get; set; }
        public Color Color { get; set; }
        public Material Material { get; set; }

        public float Ka;
        public float Kd;
        public float Ks;
        public float Kr;

    }
}
