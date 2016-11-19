using CGCourseProject.Abstracts;
using CGCourseProject.Structs;
using CGCourseProject.Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.KDTreeLogic
{
    public class KDNode
    {
        public Plane Plane { get; set; }

        public Coord Coord { get; set; }

        public readonly List<IObject3d> Objects = new List<IObject3d>();
        public KDNode LeftNode;
        public KDNode RightNode;

        public KDNode(IReadOnlyCollection<IObject3d> objects, int count)
        {
            Plane = Plane.NONE;
            LeftNode = null;
            RightNode = null;

            Objects.AddRange(objects.Take(count));
        }

        public KDNode()
        {
            Plane = Plane.NONE;
            LeftNode = null;
            RightNode = null;
        }

        public bool FindIntersectionNode(Voxel v, Point3d vectorStart, Vector3d vector, 
            ref IObject3d nearestObj, ref Point3d nearestIntersectionPoint,
            ref float nearestInersectionPointDist)
        {
            if (Plane == Plane.NONE)
            {
                if (Objects.Count > 0)
                {
                    Point3d intersectionPoint = new Point3d();

                    float sqrNearestDist = float.MaxValue;
                    IObject3d tmpNearestObj = null;
                    Point3d tmpNearestIntersectionPoint = new Point3d();

                    bool intersected = false;

                    for (var i = 0; i < Objects.Count; i++)
                    {
                        var obj = Objects[i];
                        if(obj.Intersect(vectorStart, vector, ref intersectionPoint) &&
                            v.PointInVoxel(intersectionPoint))
                        {
                            var sqrCurrDist = Utils.SqrModuleVector(new Vector3d(vectorStart, intersectionPoint));

                            if (sqrCurrDist < sqrNearestDist || !intersected)
                            {
                                tmpNearestObj = obj;
                                tmpNearestIntersectionPoint = intersectionPoint;
                                sqrNearestDist = sqrCurrDist;
                                intersected = true;
                            }
                        }
                    }

                    if (intersected)
                    {
                        float nearestDist = (float)Math.Sqrt(sqrNearestDist);

                        if (nearestDist < nearestInersectionPointDist)
                        {
                            nearestInersectionPointDist = nearestDist;
                            nearestObj = tmpNearestObj;
                            nearestIntersectionPoint = tmpNearestIntersectionPoint;
                        }
                    }
                    return intersected;
                }
                return false;
            }

            Voxel frontVoxel = new Voxel();
            Voxel backVoxel = new Voxel();

            KDNode frontNode = null;
            KDNode backNode = null;

            switch (Plane)
            {
                case Plane.XY:
                    if ((Coord.Z > v.ZMin && Coord.Z > vectorStart.Z)
                            || (Coord.Z < v.ZMin && Coord.Z < vectorStart.Z))
                        InPlane(v, ref frontNode, ref backNode, ref frontVoxel, ref backVoxel);
                    else
                        OutPlane(v, ref frontNode, ref backNode, ref frontVoxel, ref backVoxel);
                    break;

                case Plane.XZ:
                    if ((Coord.Y > v.YMin && Coord.Y > vectorStart.Y)
                            || (Coord.Y < v.YMin && Coord.Y < vectorStart.Y))
                        InPlane(v, ref frontNode, ref backNode, ref frontVoxel, ref backVoxel);
                    else
                        OutPlane(v, ref frontNode, ref backNode, ref frontVoxel, ref backVoxel);
                    break;

                case Plane.YZ:
                    if ((Coord.X > v.XMin && Coord.X > vectorStart.X)
                            || (Coord.X < v.XMin && Coord.X < vectorStart.X))
                        InPlane(v, ref frontNode, ref backNode, ref frontVoxel, ref backVoxel);
                    else
                        OutPlane(v, ref frontNode, ref backNode, ref frontVoxel, ref backVoxel);
                    break;

                case Plane.NONE:
                    throw new Exception("[vector_plane_intersection] Plane is NONE. Error");
            }

            if (frontVoxel.VoxelIntersection(vector, vectorStart)
                && frontNode.FindIntersectionNode(frontVoxel, vectorStart, vector,
                    ref nearestObj, ref nearestIntersectionPoint, ref nearestInersectionPointDist))
                return true;

            return (backVoxel.VoxelIntersection(vector, vectorStart)
                && backNode.FindIntersectionNode(backVoxel, vectorStart, vector,
                    ref nearestObj, ref nearestIntersectionPoint, ref nearestInersectionPointDist));
        }

        private void OutPlane(Voxel v, ref KDNode frontNode, ref KDNode backNode, ref Voxel frontVoxel, ref Voxel backVoxel)
        {
            frontNode = RightNode;
            backNode = LeftNode;
            var lrVoxel = v.SplitVoxel(Plane, Coord);
            backVoxel = lrVoxel.Item1;
            frontVoxel = lrVoxel.Item2;
        }

        private void InPlane(Voxel v, ref KDNode frontNode, ref KDNode backNode, ref Voxel frontVoxel, ref Voxel backVoxel)
        {
            frontNode = LeftNode;
            backNode = RightNode;
            var lrVoxel = v.SplitVoxel(Plane, Coord);
            frontVoxel = lrVoxel.Item1;
            backVoxel = lrVoxel.Item2;
        }
    }
}
