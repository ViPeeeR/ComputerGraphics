using CGCourseProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCourseProject.Logic;
using CGCourseProject.Structs;

namespace CGCourseProject.Sphere
{
    public class Sphere3d : IObject3d
    {
        private const float EPSILON = (float)(1e-5);

        protected Point3d center;
        protected float radius;
        protected Color color;
        protected Material material;

        public Color GetColor { get { return color; } }
        public Material GetMaterial { get { return material; } }

        public Sphere3d(Point3d center, float radius, Color color, Material material)
        {
            this.center = center;
            this.radius = radius;
            this.color = color;
            this.material = material;
        }

        public Point3d GetMaxBoundaryPoint()
        {
            return new Point3d(center.X + radius + 1, center.Y + radius + 1, center.Z + radius + 1);
        }

        public Point3d GetMinBoundaryPoint()
        {
            return new Point3d(center.X - radius - 1, center.Y - radius - 1, center.Z - radius - 1);
        }

        public Vector3d GetNormalVector(Point3d intersectionPoint)
        {
            var n = new Vector3d(center, intersectionPoint);
            n.NormalizeVector();
            return n;
        }

        public bool Intersect(Point3d vectorStart, Vector3d vector, ref Point3d intersectionPoint)
        {
            float a = vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z;

            float b = 2 * (vector.X * (vectorStart.X - center.X) + vector.Y * (vectorStart.Y - center.Y)
                + vector.Z * (vectorStart.Z - center.Z));

            float c = center.X * center.X + center.Y * center.Y + center.Z * center.Z
                + vectorStart.X * vectorStart.X + vectorStart.Y * vectorStart.Y + vectorStart.Z * vectorStart.Z
                - 2 * (vectorStart.X * center.X + vectorStart.Y * center.Y + vectorStart.Z * center.Z)
                - radius * radius;

            float D = b * b - 4 * a * c;

            if (D < 0)
                return false;

            float sqrtD = (float)Math.Sqrt(D);
            float a_2 = 2 * a;

            float t1 = (-b + sqrtD) / a_2;
            float t2 = (-b - sqrtD) / a_2;

            float min_t = (t1 < t2) ? t1 : t2;
            float max_t = (t1 > t2) ? t1 : t2;

            float t = (min_t > EPSILON) ? min_t : max_t;

            if (t < EPSILON)
                return false;

            intersectionPoint = new Point3d(vectorStart.X + t * vector.X, vectorStart.Y + t * vector.Y,
                vectorStart.Z + t * vector.Z);

            return true;
        }
    }
}
