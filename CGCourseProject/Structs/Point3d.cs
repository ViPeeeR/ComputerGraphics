using CGCourseProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Structs
{
    public struct Point3d : ICoordinate3d
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Point3d(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point3d RatatePointX(Point3d p, float Sin, float Cos)
        {
            float y = p.Y * Cos - p.Z * Sin;
            float z = p.Y * Sin + p.Z * Cos;

            return new Point3d(p.X, y, z);
        }

        public static Point3d RatatePointY(Point3d p, float Sin, float Cos)
        {
            float x = p.X * Cos - p.Z * Sin;
            float z = p.X * Sin + p.Z * Cos;

            return new Point3d(x, p.Y, z);
        }

        public static Point3d RatatePointZ(Point3d p, float Sin, float Cos)
        {
            float x = p.X * Cos - p.Y * Sin;
            float y = p.X * Sin + p.Y * Cos;

            return new Point3d(x, y, p.Z);
        }
    }
}
