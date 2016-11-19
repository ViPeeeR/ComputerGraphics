using CGCourseProject.Abstracts;
using CGCourseProject.Logic;
using CGCourseProject.Structs;
using CGCourseProject.Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Triangle
{
    public class Triangle3d : IObject3d
    {
        private const float EPSILON = (float)(1e-5);

        protected Point3d p1;
        protected Point3d p2;
        protected Point3d p3;

        protected Vector3d norm;

        protected float d;

        protected Vector3d v_p1_p2;
        protected Vector3d v_p2_p3;
        protected Vector3d v_p3_p1;

        protected Color color;
        protected Material material;

        public Color GetColor { get { return color; } }
        public Material GetMaterial { get { return material; } }

        public Triangle3d(Point3d p1, Point3d p2, Point3d p3, Color color, Material material)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            this.norm = Utils.CrossProduct(new Vector3d(p1, p3), new Vector3d(p3, p2));

            this.d = -(p1.X * this.norm.X + p1.Y * this.norm.Y + p1.Z * this.norm.Z);

            this.color = color;
            this.material = material;

            this.v_p1_p2 = new Vector3d(p1, p2);
            this.v_p2_p3 = new Vector3d(p2, p3);
            this.v_p3_p1 = new Vector3d(p3, p1);
        }

        public virtual Vector3d GetNormalVector(Point3d intersectionPoint)
        {
            return norm;
        }

        public Point3d GetMinBoundaryPoint()
        {
            float xMin = p1.X;
            float yMin = p1.Y;
            float zMin = p1.Z;

            xMin = (xMin < p2.X) ? xMin : p2.X;
            yMin = (yMin < p2.Y) ? yMin : p2.Y;
            zMin = (zMin < p2.Z) ? zMin : p2.Z;

            xMin = (xMin < p3.X) ? xMin : p3.X;
            yMin = (yMin < p3.Y) ? yMin : p3.Y;
            zMin = (zMin < p3.Z) ? zMin : p3.Z;

            return new Point3d(xMin - EPSILON, yMin - EPSILON, zMin - EPSILON);
        }

        public Point3d GetMaxBoundaryPoint()
        {
            float xMax = p1.X;
            float yMax = p1.Y;
            float zMax = p1.Z;

            xMax = (xMax > p2.X) ? xMax : p2.X;
            yMax = (yMax > p2.Y) ? yMax : p2.Y;
            zMax = (zMax > p2.Z) ? zMax : p2.Z;

            xMax = (xMax > p3.X) ? xMax : p3.X;
            yMax = (yMax > p3.Y) ? yMax : p3.Y;
            zMax = (zMax > p3.Z) ? zMax : p3.Z;

            return new Point3d(xMax + EPSILON, yMax + EPSILON, zMax + EPSILON);
        }

        public bool Intersect(Point3d vectorStart, Vector3d vector, ref Point3d intersectionPoint)
        {
            float scalarProduct = Utils.DotProduct(norm, vector);

            if (Math.Abs(scalarProduct) < EPSILON)
                return false;

            float k = -(norm.X * vectorStart.X + norm.Y * vectorStart.Y + norm.Z * vectorStart.Z + d)
                / scalarProduct;

            if (k < EPSILON)
                return false;

            // Intersection point
            float x = vectorStart.X + vector.X * k;
            float y = vectorStart.Y + vector.Y * k;
            float z = vectorStart.Z + vector.Z * k;
            Point3d ipt = new Point3d(x, y, z);

            if (checkSameClockDir(v_p1_p2, new Vector3d(p1, ipt), norm)
                    && checkSameClockDir(v_p2_p3, new Vector3d(p2, ipt), norm)
                    && checkSameClockDir(v_p3_p1, new Vector3d(p3, ipt), norm))
            {
                intersectionPoint = ipt;
                return true;
            }

            // No intersection
            return false;
        }

        private bool checkSameClockDir(Vector3d v1, Vector3d v2, Vector3d norm)
        {
            Vector3d norm_v1_v2 = Utils.CrossProduct(v2, v1);

            if (Utils.DotProduct(norm_v1_v2, norm) < 0)
                return false;
            else
                return true;
        }
    }
}
