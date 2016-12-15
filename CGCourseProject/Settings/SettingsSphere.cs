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

        public static SettingsSphere DefaultSettings()
        {
            var settings = new SettingsSphere();
            settings.Center = new Point3d(0, -100, 0);
            settings.Radius = 100f;
            settings.Color = new Color(0,0,0);
            settings.Material = new Material(1, 10, 3, 10, 0, 10);
            settings.Ka = 1;
            settings.Kd = 10;
            settings.Ks = 3;
            settings.Kr = 10;

            return settings;
        }

    }
}
