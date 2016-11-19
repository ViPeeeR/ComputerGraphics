using CGCourseProject.Abstracts;
using CGCourseProject.KDTreeLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Structs
{
    public struct Voxel
    {
        public float XMin;
        public float YMin;
        public float ZMin;

        public float XMax;
        public float YMax;
        public float ZMax;

        public Voxel(IReadOnlyCollection<IObject3d> objects)
        {
            if (objects.Count == 0)
            {
                XMin = -1; YMin = -1; ZMin = -1;
                XMax = 1; YMax = 1; ZMax = 1;
                return;
            }

            var minPoint = objects.ElementAt(0).GetMinBoundaryPoint();
            var maxPoint = objects.ElementAt(0).GetMaxBoundaryPoint();

            var xmin = minPoint.X;
            var ymin = minPoint.Y;
            var zmin = minPoint.Z;
            var xmax = maxPoint.X;
            var ymax = maxPoint.Y;
            var zmax = maxPoint.Z;

            foreach (var obj in objects)
            {
                minPoint = obj.GetMinBoundaryPoint();
                maxPoint = obj.GetMaxBoundaryPoint();

                xmin = xmin < minPoint.X ? xmin : minPoint.X;
                ymin = ymin < minPoint.Y ? ymin : minPoint.Y;
                zmin = zmin < minPoint.Z ? zmin : minPoint.Z;

                xmax = xmax > maxPoint.X ? xmax : maxPoint.X;
                ymax = ymax > maxPoint.Y ? ymax : maxPoint.Y;
                zmax = zmax > maxPoint.Z ? zmax : maxPoint.Z;
            }


            XMin = xmin - 1;
            XMax = xmax + 1;
            YMin = ymin - 1;
            YMax = ymax + 1;
            ZMin = zmin - 1;
            ZMax = zmax + 1;
        }

        public int FilterOverlappedObjects(List<IObject3d> objects, int objCount)
        {
            var i = 0;
            var j = objCount - 1;

            while(i <= j)
            {
                while (i < j && ObjectInVoxel(objects[i]))
                    i++;

                while (j > i && !ObjectInVoxel(objects[j]))
                    j--;

                var temp = objects[i];
                objects[i] = objects[j];
                objects[j] = temp;

                i++;
                j--;
            }

            return i;   
        }

        public bool PointInVoxel(Point3d p)
        {
            return ((p.X > XMin) && (p.X < XMax) && (p.Y > YMin) && (p.Y < YMax) &&
                (p.Z > ZMin) && (p.Z < ZMax));
        }

        public bool VoxelIntersection(Vector3d vector, Point3d vectorStart)
        {
            if (PointInVoxel(vectorStart))
                return true;

            Point3d p = new Point3d();
            Coord c = new Coord();

            c.Z = ZMin;
            if (VectorPlaneIntersection(vector, vectorStart, Plane.XY, c, ref p)
                    && (p.X > XMin) && (p.X < XMax) && (p.Y > YMin) && (p.Y < YMax))
                return true;

            c.Z = ZMax;
            if (VectorPlaneIntersection(vector, vectorStart, Plane.XY, c, ref p)
                    && (p.X > XMin) && (p.X < XMax) && (p.Y > YMin) && (p.Y < YMax))
                return true;

            c.Y = YMin;
            if (VectorPlaneIntersection(vector, vectorStart, Plane.XZ, c, ref p)
                    && (p.X > XMin) && (p.X < XMax) && (p.Z > ZMin) && (p.Z < ZMax))
                return true;

            c.Y = YMax;
            if (VectorPlaneIntersection(vector, vectorStart, Plane.XZ, c, ref p)
                    && (p.X > XMin) && (p.X < XMax) && (p.Z > ZMin) && (p.Z < ZMax))
                return true;

            c.X = XMin;
            if (VectorPlaneIntersection(vector, vectorStart, Plane.YZ, c, ref p)
                    && (p.Y > YMin) && (p.Y < YMax) && (p.Z > ZMin) && (p.Z < ZMax))
                return true;

            c.X = XMax;
            if (VectorPlaneIntersection(vector, vectorStart, Plane.YZ, c, ref p)
                    && (p.Y > YMin) && (p.Y < YMax) && (p.Z > ZMin) && (p.Z < ZMax))
                return true;

            return false;
        }

        private bool VectorPlaneIntersection(Vector3d vector, Point3d vectorStart, Plane plane,
            Coord coord, ref Point3d result)
        {
            float k;
            switch (plane)
            {
                case Plane.XY:
                    if ((coord.Z < vectorStart.Z && vector.Z > 0)
                        || (coord.Z > vectorStart.Z && vector.Z < 0))
                        return false;

                    k = (coord.Z - vectorStart.Z) / vector.Z;
                    result = new Point3d(vectorStart.X + vector.X * k,
                        vectorStart.Y + vector.Y * k,
                        coord.Z);
                    break;

                case Plane.XZ:
                    if ((coord.Y < vectorStart.Y && vector.Y > 0)
                        || (coord.Y > vectorStart.Y && vector.Y < 0))
                        return false;

                    k = (coord.Y - vectorStart.Y) / vector.Y;
                    result = new Point3d(vectorStart.X + vector.X * k,
                        coord.Y,
                        vectorStart.Z + vector.Z * k);
                    break;

                case Plane.YZ:
                    if ((coord.X < vectorStart.X && vector.X > 0)
                        || (coord.X > vectorStart.X && vector.X < 0))
                        return false;

                    k = (coord.X - vectorStart.X) / vector.X;
                    result = new Point3d(coord.X,
                        vectorStart.Y + vector.Y * k,
                        vectorStart.Z + vector.Z * k);
                    break;

                case Plane.NONE:
                    throw new Exception("[vector_plane_intersection] Plane is NONE. Error");
            }

            return true;
        }

        public int ObjectsInVoxel(IReadOnlyCollection<IObject3d> objects, int lenght)
        {
            int count = 0;
            for (var i = 0; i < lenght; i++)
                if (ObjectInVoxel(objects.ElementAt(i)))
                    count++;

            return count;
        }

        private bool ObjectInVoxel(IObject3d obj)
        {
            Point3d min_p = obj.GetMinBoundaryPoint();
            Point3d max_p = obj.GetMaxBoundaryPoint();

            return
                !(max_p.X < XMin || max_p.Y < YMin || max_p.Z < ZMin
                    || min_p.X > XMax || min_p.Y > YMax || min_p.Z > ZMax);
        }

        public Tuple<Voxel, Voxel> SplitVoxel(Plane p, Coord c)
        {
            var vl = this;
            var vr = this;

            switch (p)
            {
                case Plane.XY:
                    vl.ZMax = c.Z;
                    vr.ZMin = c.Z;
                    break;

                case Plane.XZ:
                    vl.YMax = c.Y;
                    vr.YMin = c.Y;
                    break;

                case Plane.YZ:
                    vl.XMax = c.X;
                    vr.XMin = c.X;
                    break;

                case Plane.NONE:
                    throw new Exception("[vector_plane_intersection] Plane is NONE. Error");
            }

            return new Tuple<Voxel, Voxel>(vl, vr);
        }
    }
}
