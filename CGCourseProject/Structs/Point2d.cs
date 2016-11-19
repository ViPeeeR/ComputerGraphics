using CGCourseProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Structs
{
    public struct Point2d : ICoordinate2d
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Point2d(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
