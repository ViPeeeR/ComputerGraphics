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
        public Scene Scene { get; private set; }

        public Scene CreateScene()
        {
            loader = new ObjLoader();
            Scene = new Scene(new Color(255, 255, 255));
            Scene.AddModel(CreateSurface());
            Scene.AddLightSource(new LightSource3d(new Point3d(300, -300, 300), 
                new Color(255, 255, 255)));

            Scene.FogDestiny = (dist) =>
            {
                Scene.FogParameters = 1e-4f;
                return 1 - (float)Math.Exp(-Scene.FogParameters * dist);
            };

            return Scene;
        }

        public void SetDefaultScene()
        {
            Scene.AddModel(CreateSphere());
            SceneFaceHandlerParams loadParams = new SceneFaceHandlerParams(Scene,
                // scale:
                80f,
                // move dx, dy, dz:
                0, 50, 0,
                // rotate around axises x, y, z:
                0, 0, (float)Math.PI / 4f + 0.01f,
                // color
                new Color(255, 255, 255),
                // surface params
                new Material(5, 10, 5, 7, 0, 10)
            );

            CreateModel(loadParams, "./models/figure1.obj");
        }

        public Scene1()
        {
            loader = new ObjLoader();
            //Scene.AddModel(CreateSurface());
            //Scene.AddModel(CreateSphere());

            //Scene.FogDestiny = (dist) =>
            //{
            //    Scene.FogParameters = 1e-4f;
            //    return 1 - (float)Math.Exp(-Scene.FogParameters * dist);
            //};

            //SceneFaceHandlerParams loadParams = new SceneFaceHandlerParams(Scene,
            //    // scale:
            //    80f,
            //    // move dx, dy, dz:
            //    0, 50, 0,
            //    // rotate around axises x, y, z:
            //    0, 0, (float)Math.PI / 4f + 0.01f,
            //    // color
            //    new Color(255, 255, 255),
            //    // surface params
            //    new Material(5, 10, 5, 7, 0, 10)
            //);

            //loader.LoadObj("./models/figure1.obj", loader.SceneFaceHandler, loadParams);

            //Scene.AddLightSource(new LightSource3d(new Point3d(300, -300, 300), new Color(255, 255, 255)));
        }

        public void PrepareScene()
        {
            Scene.PrepareScene();
        }

        public SceneObject CreateSurface()
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

            //// Top
            //model.AddObject(new Triangle3d(
            //                    new Point3d(-500, -500, 400),
            //                    new Point3d(500, -500, 400),
            //                    new Point3d(500, 500, 400),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            //model.AddObject(new Triangle3d(
            //                    new Point3d(-500, -500, 400),
            //                    new Point3d(-500, 500, 400),
            //                    new Point3d(500, 500, 400),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            ////Back
            //model.AddObject(new Triangle3d(
            //                    new Point3d(-500, 500, -100),
            //                    new Point3d(500, 500, -100),
            //                    new Point3d(-500, 500, 400),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            //model.AddObject(new Triangle3d(
            //                    new Point3d(500, 500, -100),
            //                    new Point3d(500, 500, 400),
            //                    new Point3d(-500, 500, 400),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            ////Left
            //model.AddObject(new Triangle3d(
            //                    new Point3d(-500, 500, -100),
            //                    new Point3d(-500, 500, 400),
            //                    new Point3d(-500, -500, -100),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            //model.AddObject(new Triangle3d(
            //                    new Point3d(-500, 500, 400),
            //                    new Point3d(-500, -500, 400),
            //                    new Point3d(-500, -500, -100),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            ////Right
            //model.AddObject(new Triangle3d(
            //                    new Point3d(500, 500, -100),
            //                    new Point3d(500, 500, 400),
            //                    new Point3d(500, -500, -100),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            //model.AddObject(new Triangle3d(
            //                    new Point3d(500, 500, 400),
            //                    new Point3d(500, -500, 400),
            //                    new Point3d(500, -500, -100),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            //// ЗА мной
            //model.AddObject(new Triangle3d(
            //                    new Point3d(-500, -500, -100),
            //                    new Point3d(-500, -500, 400),
            //                    new Point3d(500, -500, -100),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));

            //model.AddObject(new Triangle3d(
            //                    new Point3d(500, -500, -100),
            //                    new Point3d(500, -500, 400),
            //                    new Point3d(-500, -500, 400),
            //                    color,
            //                    new Material(1, 6, 0, 0, 0, 0)));
            return model;
        }

        public void CreateModel(SettingsSphere settings)
        {
            var model = new SceneObject();
            Sphere3d sphere = new Sphere3d(settings.Center, settings.Radius, 
                settings.Color, settings.Material);

            model.AddObject(sphere);
            Scene.AddModel(model);
        }

        private SceneObject CreateSphere()
        {
            var model = new SceneObject();
            model.AddObject(new Sphere3d(new Point3d(-220, 0, 0), 100f, new Color(100, 0, 255),
                new Material(5, 10, 5, 10, 0, 10)));

            model.AddObject(new Sphere3d(new Point3d(0, 50, 130), 50f, new Color(255, 97, 97),
                new Material(5, 10, 5, 10, 0, 10)));

            model.AddObject(new Sphere3d(new Point3d(220, 0, 0), 100f, new Color(230, 85, 135),
                new Material(5, 10, 5, 6, 0, 10)));

            return model;
        }

        public void CreateModel(SceneFaceHandlerParams settings, string filename)
        {
            loader.LoadObj(filename, loader.SceneFaceHandler, settings);
        }

    }
}
