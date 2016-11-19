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
            //CreateAtenea(scene);

            scene.AddModel(CreateSurface());

            //scene.AddObject(new Triangle3d(
            //                    new Point3d(-700, -700, -130),
            //                    new Point3d(700, -700, -130),
            //                    new Point3d(0, 400, -130),
            //                    new Color(100, 255, 30),
            //                    new Material(1, 6, 0, 2, 0, 0)));

            //SceneFaceHandlerParams load_params = new SceneFaceHandlerParams(scene,
            //                      // scale:
            //                      0.5f,
            //                      // move dx, dy, dz:
            //                      -200, -100, 0,
            //                      // rotate around axises x, y, z:
            //                      0f, 0f, (float)Math.PI/2f,
            //                      // color
            //                      new Color(150, 150, 150),
            //                      // surface params
            //                      new Material(2, 3, 0, 0, 0, 0)
            //                      );

            //loader.LoadObj("./models/elephal.obj",
            //         // default handler which adding polygons of 3D model to scene:
            //         loader.SceneFaceHandler,
            //         load_params);

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
                                new Point3d(-500, -500, -120),
                                new Point3d(500, -500, -120),
                                new Point3d(500, 500, -120),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            model.AddObject(new Triangle3d(
                                new Point3d(-500, -500, -120),
                                new Point3d(-500, 500, -120),
                                new Point3d(500, 500, -120),
                                new Color(55, 200, 155),
                                new Material(1, 6, 0, 0, 0, 0)));

            return model;
        }

        private SceneObject CreateSphere()
        {
            var model = new SceneObject();
            model.AddObject(new Sphere3d(new Point3d(0, 0, 0), 100f, new Color(250, 30, 30),
                new Material(1, 5, 5, 10, 0, 10)));

            return model;
        }

        private void CreateAtenea(Scene scene)
        {
            SceneFaceHandlerParams load_params = new SceneFaceHandlerParams(scene,
                                  150f, -200, -200,
                                  0, 0, 0, 0,
                                  new Color(250, 200, 50),
                                  //reflective surface
                                  new Material(2, 3, 7, 3, 0, 10));
            //material(4, 3, 7, 0, 0, 10));
            loader.LoadObj("./models/tetrahedron.obj",
                     loader.SceneFaceHandler,
                     load_params);
        }
    }
}
