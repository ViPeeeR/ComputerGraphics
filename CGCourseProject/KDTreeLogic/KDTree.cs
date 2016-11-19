using CGCourseProject.Abstracts;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.KDTreeLogic
{
    public class KDTree
    {
        private const int MAXSPLIT = 5;
        private const int SPLITCOST = 5;

        public KDNode Root { get; }
        public Voxel BoundingBox { get; set; }

        public KDTree(List<IObject3d> objects)
        {
            BoundingBox = new Voxel(objects);
            Root = RecursiveBuild(objects, objects.Count, BoundingBox, 0);
        }

        private KDNode RecursiveBuild(List<IObject3d> objects, int objCount, Voxel voxel, int iter)
        {
            Plane p;
            Coord c;
            FindPlane(objects, objCount, voxel, iter, out p, out c);

            if (p == Plane.NONE)
                return new KDNode(objects, objCount);

            Voxel vl, vr;
            var lrVoxel = voxel.SplitVoxel(p, c);
            vl = lrVoxel.Item1;
            vr = lrVoxel.Item2;

            int lObjectsCount = vl.FilterOverlappedObjects(objects, objCount);
            KDNode l = RecursiveBuild(objects, lObjectsCount, vl, iter + 1);

            int rObjectsCount = vr.FilterOverlappedObjects(objects, objCount);
            KDNode r = RecursiveBuild(objects, rObjectsCount, vr, iter + 1);

            return new KDNode() { Plane = p, Coord = c, LeftNode = l, RightNode = r };
        }

        private void FindPlane(IReadOnlyCollection<IObject3d> objects, int count, Voxel v, int depth, out Plane p, out Coord c)
        {
            p = Plane.NONE;
            c = new Coord();

            if (depth >= 20 || count <= 1)
                return;

            float hx = v.XMax - v.XMin;
            float hy = v.YMax - v.YMin;
            float hz = v.ZMax - v.ZMin;

            float Sxy = hx * hy;
            float Sxz = hx * hz;
            float Syz = hy * hz;

            float Ssum = Sxy + Sxz + Syz;

            Sxy /= Ssum;
            Sxz /= Ssum;
            Syz /= Ssum;

            float bestSAH = count;
            Coord currSplitCoord = new Coord();

            for (var i = 1; i < MAXSPLIT; i++)
            {
                var l = (float)i / MAXSPLIT;
                var r = 1 - l;

                currSplitCoord = new Coord(v.XMin + l * hx, v.YMin + l * hy, v.ZMin + l * hz);

                CalcSAH(objects, count, v, Plane.XY, currSplitCoord, ref p, ref c, ref bestSAH,
                    Sxy + l * (Syz + Sxz), Sxy + r * (Syz + Sxz));

                CalcSAH(objects, count, v, Plane.YZ, currSplitCoord, ref p, ref c, ref bestSAH,
                 Syz + l * (Sxy + Sxz), Syz + r * (Sxy + Sxz));

                CalcSAH(objects, count, v, Plane.XZ, currSplitCoord, ref p, ref c, ref bestSAH,
                 Sxz + l * (Sxy + Syz), Sxz + r * (Sxy + Syz));
            }
        }

        private static void CalcSAH(IReadOnlyCollection<IObject3d> objects, int count,
            Voxel v, Plane axis, Coord currSplitCoord, 
            ref Plane p, ref Coord c, ref float bestSAH, 
            float left, float right)
        {
            var lrVoxel = v.SplitVoxel(axis, currSplitCoord);
            var vl = lrVoxel.Item1;
            var vr = lrVoxel.Item2;

            var currSAH = left * vl.ObjectsInVoxel(objects, count)
                + right * vr.ObjectsInVoxel(objects, count) + SPLITCOST;

            if (currSAH < bestSAH)
            {
                bestSAH = currSAH;
                p = axis;
                c = currSplitCoord;
            }
        }

        public bool FindIntersectionTree(Point3d vectorStart, Vector3d vector,
            ref IObject3d nearestObj, ref Point3d nearestIntersectionPoint,
            ref float nearestIntersectionPointDist)
        {
            return (BoundingBox.VoxelIntersection(vector, vectorStart) &&
                    Root.FindIntersectionNode(BoundingBox, vectorStart, vector, ref nearestObj, 
                        ref nearestIntersectionPoint, ref nearestIntersectionPointDist));
        }
    }
}
