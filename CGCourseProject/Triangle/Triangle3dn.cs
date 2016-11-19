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
    public class Triangle3dn : Triangle3d
    {
        protected Vector3d n1;
        protected Vector3d n2;
        protected Vector3d n3;   

        public Triangle3dn(Point3d p1, Point3d p2, Point3d p3,
                Vector3d n1, Vector3d n2, Vector3d n3, Color color, Material material) :
            base(p1, p2, p3, color, material)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
        }

        public override Vector3d GetNormalVector(Point3d intersectionPoint)
        {
            float w1, w2, w3;

            GetWeightsOfVertexes(intersectionPoint, out w1, out w2, out w3);

            return new Vector3d(w1 * n1.X + w2 * n2.X + w3 * n3.X, w1 * n1.Y + w2 * n2.Y + w3 * n3.Y,
                w1 * n1.Z + w2 * n2.Z + w3 * n3.Z);
        }

        private void GetWeightsOfVertexes(Point3d intersectionPoint, out float w1, out float w2, out float w3)
        {
            Vector3d v_p1_p = new Vector3d(p1, intersectionPoint);
            Vector3d v_p2_p = new Vector3d(p2, intersectionPoint);
            Vector3d v_p3_p = new Vector3d(p3, intersectionPoint);

            float s1 = Utils.ModuleVector(Utils.CrossProduct(v_p2_p, this.v_p2_p3));
            float s2 = Utils.ModuleVector(Utils.CrossProduct(v_p3_p, this.v_p3_p1));
            float s3 = Utils.ModuleVector(Utils.CrossProduct(v_p1_p, this.v_p1_p2));

            float s_sum = s1 + s2 + s3;

            w1 = s1 / s_sum;
            w2 = s2 / s_sum;
            w3 = s3 / s_sum;
        }
    }
}
