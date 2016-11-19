using CGCourseProject.Logic;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Abstracts
{
    public interface IObject3d
    {
        bool Intersect(Point3d vectorStart, Vector3d vector, ref Point3d intersectionPoint);

        Color GetColor { get; }

        Vector3d GetNormalVector(Point3d intersectionPoint);

        Material GetMaterial { get; }

        Point3d GetMinBoundaryPoint();

        Point3d GetMaxBoundaryPoint();
    }
}
