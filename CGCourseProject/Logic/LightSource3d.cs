using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class LightSource3d
    {
        public Point3d LocationWorld { get; set; }

        public Point3d Location { get; set; }

        public Color Color { get; set; }

        public LightSource3d(Point3d location, Color color)
        {
            LocationWorld = location;
            Location = location;
            Color = color;
        }
    }
}
