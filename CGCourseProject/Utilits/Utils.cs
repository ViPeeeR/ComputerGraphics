using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Utilits
{
    public static class Utils
    {
        public static Vector3d CrossProduct(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.Z * b.Y - a.Y * b.Z,
                a.X * b.Z - a.Z * b.X,
                a.Y * b.X - a.X * b.Y);
        }

        public static float DotProduct(Vector3d v1, Vector3d v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static float SqrModuleVector(Vector3d v)
        {
            return DotProduct(v, v);
        }

        public static float ModuleVector(Vector3d v)
        {
            return (float)Math.Sqrt(SqrModuleVector(v));
        }

        public static float CosVectors(Vector3d v1, Vector3d v2)
        {
            return DotProduct(v1, v2) / (float)Math.Sqrt(SqrModuleVector(v1) * SqrModuleVector(v2));
        }

    }
}
