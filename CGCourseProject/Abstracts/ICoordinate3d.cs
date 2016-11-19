using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Abstracts
{
    public interface ICoordinate3d : ICoordinate2d
    {
        float Z { get; }
    }
}
