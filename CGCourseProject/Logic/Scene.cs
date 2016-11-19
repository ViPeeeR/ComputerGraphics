using CGCourseProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCourseProject.KDTreeLogic;
using CGCourseProject.Structs;

namespace CGCourseProject.Logic
{
    public class Scene
    {
        public readonly List<IObject3d> Objects = new List<IObject3d>();
        public KDTree KDTree { get; set; }

        public readonly List<LightSource3d> LightSources = new List<LightSource3d>();
        public Color BackgroundColor { get; set; }

        public Func<float, float> FogDestiny { get; set; } = null;

        public float FogParameters { get; set; }

        public Scene(Color backgroundColor)
        {
            BackgroundColor = backgroundColor;
            KDTree = null;
        }

        public void AddObject(IObject3d obj)
        {
            Objects.Add(obj);
        }

        public void AddLightSource(LightSource3d lightSource)
        {
            LightSources.Add(lightSource);
        }

        public void PrepareScene()
        {
            RebuildKDTree();
        }

        private void RebuildKDTree()
        {
            this.KDTree = new KDTree(Objects);
        }
    }
}
