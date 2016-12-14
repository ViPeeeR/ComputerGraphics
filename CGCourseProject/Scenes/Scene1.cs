using System;

using CGCourseProject.Abstracts;
using CGCourseProject.Logic;
using CGCourseProject.Structs;
using CGCourseProject.Sphere;
using CGCourseProject.Utilits;
using CGCourseProject.Triangle;
using CGCourseProject.Settings;

namespace CGCourseProject.Scenes
{
    public class Scene1 : IScene
    {
        private ObjLoader loader;
        private Scene scene = new Scene(new Color(255, 255, 255));

        public Scene CreateScene()
        {
            SceneFaceHandlerParams loadParams = new SceneFaceHandlerParams(scene,
                // scale:
                45f,
                // move dx, dy, dz:
                200, -500, 0,
                // rotate around axises x, y, z:
                0, 0, -1f,
                // color
                new Color(255, 0, 255),
                // surface params
                new Material(1, 1, 2, 0, 0, 10)
            );

            loader.LoadObj("./123.obj", loader.SceneFaceHandler, loadParams);

            return scene;
        }

        public Scene1()
        {
            loader = new ObjLoader();
            scene.AddModel(CreateSurface());
            scene.AddModel(CreateSphere());

            scene.FogDestiny = (dist) =>
            {
                scene.FogParameters = 1e-4f;
                return 1 - (float)Math.Exp(-scene.FogParameters * dist);
            };

            scene.AddLightSource(new LightSource3d(new Point3d(300, -300, 300), new Color(255, 255, 255)));
        }

        public void PrepareScene()
        {
            scene.PrepareScene();
        }

        private SceneObject CreateSurface()
        {
            var model = new SceneObject();
            Color color = new Color(55, 200, 155);

            // Bottom
            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, -100),
                                new Point3d(500, -500, -100),
                                new Point3d(500, 500, -100),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, -100),
                                new Point3d(-500, 500, -100),
                                new Point3d(500, 500, -100),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            // Top
            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, 400),
                                new Point3d(500, -500, 400),
                                new Point3d(500, 500, 400),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, 400),
                                new Point3d(-500, 500, 400),
                                new Point3d(500, 500, 400),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            //Back
            model.AddObject(new Triangle3d(
                                new Point3d(-500, 500, -100),
                                new Point3d(500, 500, -100),
                                new Point3d(-500, 500, 400),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(500, 500, -100),
                                new Point3d(500, 500, 400),
                                new Point3d(-500, 500, 400),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            //Left
            model.AddObject(new Triangle3d(
                                new Point3d(-500, 500, -100),
                                new Point3d(-500, 500, 400),
                                new Point3d(-500, -500, -100),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(-500, 500, 400),
                                new Point3d(-500, -500, 400),
                                new Point3d(-500, -500, -100),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            //Right
            model.AddObject(new Triangle3d(
                                new Point3d(500, 500, -100),
                                new Point3d(500, 500, 400),
                                new Point3d(500, -500, -100),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(500, 500, 400),
                                new Point3d(500, -500, 400),
                                new Point3d(500, -500, -100),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            // ЗА мной
            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, -100),
                                new Point3d(-500, -500, 400),
                                new Point3d(500, -500, -100),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(500, -500, -100),
                                new Point3d(500, -500, 400),
                                new Point3d(-500, -500, 400),
                                color,
                                new Material(1, 6, 0, 0, 0, 0)));
            return model;
        }

        public void CreateSphere(SettingsSphere settings)
        {
            var model = new SceneObject();
            Sphere3d sphere = new Sphere3d(settings.Center, settings.Radius, 
                settings.Color, settings.Material);

            model.AddObject(sphere);
            scene.AddModel(model);
        }

        private SceneObject CreateSphere()
        {
            var model = new SceneObject();
            model.AddObject(new Sphere3d(new Point3d(-220, 0, 0), 100f, new Color(100, 0, 255),
                new Material(1, 10, 3, 10, 0, 10)));

            model.AddObject(new Sphere3d(new Point3d(220, 0, 0), 100f, new Color(255, 97, 97),
                new Material(5, 10, 5, 10, 0, 10)));

            return model;
        }

        public void CreateModel(SceneFaceHandlerParams settings)
        {
            throw new NotImplementedException();
        }
    }
}
