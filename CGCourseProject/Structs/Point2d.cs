using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Structs
{
    public struct Point2d
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point2d(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
