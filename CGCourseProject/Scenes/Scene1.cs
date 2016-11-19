using CGCourseProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCourseProject.Logic;
using CGCourseProject.Structs;
using CGCourseProject.Sphere;
using CGCourseProject.Utilits;
using CGCourseProject.Triangle;

namespace CGCourseProject.Scenes
{
    public class Scene1 : IScene
    {
        private ObjLoader loader;

        public Scene CreateScene()
        {
            loader = new ObjLoader();

            Scene scene = new Scene(new Color(255, 255, 255));

            scene.AddModel(CreateSphere());
            scene.AddModel(CreateSurface());

            scene.FogDestiny = (dist) =>
            {
                scene.FogParameters = 0.0005f;
                return 1 - (float)Math.Exp(-scene.FogParameters * dist);
            };

            scene.AddLightSource(new LightSource3d(new Point3d(-300, 300, 300), new Color(255, 255, 255)));

            scene.PrepareScene();
            return scene;
        }

        private SceneObject CreateSurface()
        {
            var model = new SceneObject();

            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, -100),
                                new Point3d(500, -500, -100),
                                new Point3d(500, 500, -100),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, -100),
                                new Point3d(-500, 500, -100),
                                new Point3d(500, 500, -100),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            return model;
        }

        private SceneObject CreateSphere()
        {
            var model = new SceneObject();
            model.AddObject(new Sphere3d(new Point3d(-110, 0, 0), 100f, new Color(255, 255, 255),
                new Material(0.001f, 0, 0, 10, 0, 10)));

            model.AddObject(new Sphere3d(new Point3d(110, 0, 0), 100f, new Color(0, 0, 0),
                new Material(1, 5, 5, 10, 0, 10)));

            return model;
        }
    }
}
