using CGCourseProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class SceneObject
    {
        public List<IObject3d> Objects { get; } = new List<IObject3d>();

        public void AddObject(IObject3d obj)
        {
            Objects.Add(obj);
        }

        public int Count
        {
            get { return Objects.Count; }
        }
    }
}
