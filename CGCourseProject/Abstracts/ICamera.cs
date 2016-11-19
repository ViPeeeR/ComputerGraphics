﻿using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Abstracts
{
    public interface ICamera : ICoordinateGet
    {
        Point3d CameraPosition { get; }
        float ProjPlaneDist { get; }

        void MoveCamera(Vector3d vector);
        void RatateCamera(float x, float y, float z);
    }
}
