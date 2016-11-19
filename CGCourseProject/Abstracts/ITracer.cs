using CGCourseProject.Logic;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Abstracts
{
    public interface ITracer
    {
        Color Trace(Scene scene, Camera camera, Vector3d ray);
    }
}
