using CGCourseProject.Abstracts;
using CGCourseProject.Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Structs
{
    public struct Vector3d : ICoordinateSet, ICoordinateGet
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3d(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3d(Point3d startPoint, Point3d endPoint)
        {
            X = endPoint.X - startPoint.X;
            Y = endPoint.Y - startPoint.Y;
            Z = endPoint.Z - startPoint.Z;
        }

        public static Vector3d RatateVectorX(Vector3d p, float Sin, float Cos)
        {
            float y = p.Y * Cos - p.Z * Sin;
            float z = p.Y * Sin + p.Z * Cos;

            return new Vector3d(p.X, y, z);
        }

        public static Vector3d RatateVectorY(Vector3d p, float Sin, float Cos)
        {
            float x = p.X * Cos - p.Z * Sin;
            float z = p.X * Sin + p.Z * Cos;

            return new Vector3d(x, p.Y, z);
        }

        public static Vector3d RatateVectorZ(Vector3d p, float Sin, float Cos)
        {
            float x = p.X * Cos - p.Y * Sin;
            float y = p.X * Sin + p.Y * Cos;

            return new Vector3d(x, y, p.Z);
        }

        public void NormalizeVector()
        {
            float module = Utils.ModuleVector(this);
            X /= module;
            Y /= module;
            Z /= module;
        }
    }
}
