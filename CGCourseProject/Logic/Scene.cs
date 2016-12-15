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
        public List<SceneObject> Models { get; } = new List<SceneObject>();
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

        public void AddModel(SceneObject model)
        {
            Models.Add(model);
        }

        public void AddLightSource(LightSource3d lightSource)
        {
            LightSources.Add(lightSource);
        }

        public void PrepareScene()
        {
            KDTree = null;
            RebuildKDTree();
        }

        private void RebuildKDTree()
        {
            var objects = new List<IObject3d>();
            foreach (var model in Models)
                objects.AddRange(model.Objects);

            this.KDTree = new KDTree(objects);
        }
    }
}
