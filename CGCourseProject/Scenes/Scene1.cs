using System;

using CGCourseProject.Abstracts;
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

            SceneFaceHandlerParams loadParams = new SceneFaceHandlerParams(scene,
                // scale:
                5f,
                // move dx, dy, dz:
                50, -200, 0,
                // rotate around axises x, y, z:
                0, 0, 0,
                // color
                new Color(255, 255, 255),
                // surface params
                new Material(1, 1, 2, 0, 0, 10)
            );

            //loader.LoadObj("./box.obj", loader.SceneFaceHandler, loadParams);

            //loader.LoadObj("./box.obj",
            //    // default handler which adding polygons of 3D model to scene:
            //    loader.SceneFaceHandler,
            //    loadParams);

            scene.FogDestiny = (dist) =>
            {
                scene.FogParameters = 1e-4f;
                return 1 - (float)Math.Exp(-scene.FogParameters * dist);
            };

            scene.AddLightSource(new LightSource3d(new Point3d(300, -300, 300), new Color(255, 255, 255)));

            scene.AddLightSource(new LightSource3d(new Point3d(-300, -300, 300), new Color(255, 255, 255)));

            scene.PrepareScene();
            return scene;
        }

        private SceneObject CreateSurface()
        {
            var model = new SceneObject();


            // Bottom
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

            // Top
            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, 400),
                                new Point3d(500, -500, 400),
                                new Point3d(500, 500, 400),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, 400),
                                new Point3d(-500, 500, 400),
                                new Point3d(500, 500, 400),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            //Back
            model.AddObject(new Triangle3d(
                                new Point3d(-500, 500, -100),
                                new Point3d(500, 500, -100),
                                new Point3d(-500, 500, 400),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(500, 500, -100),
                                new Point3d(500, 500, 400),
                                new Point3d(-500, 500, 400),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            //Left
            model.AddObject(new Triangle3d(
                                new Point3d(-500, 500, -100),
                                new Point3d(-500, 500, 400),
                                new Point3d(-500, -500, -100),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(-500, 500, 400),
                                new Point3d(-500, -500, 400),
                                new Point3d(-500, -500, -100),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            //Right
            model.AddObject(new Triangle3d(
                                new Point3d(500, 500, -100),
                                new Point3d(500, 500, 400),
                                new Point3d(500, -500, -100),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(500, 500, 400),
                                new Point3d(500, -500, 400),
                                new Point3d(500, -500, -100),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            // ЗА мной
            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, -100),
                                new Point3d(-500, -500, 400),
                                new Point3d(500, -500, -100),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(500, -500, -100),
                                new Point3d(500, -500, 400),
                                new Point3d(-500, -500, 400),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));
            return model;
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
    }
}
