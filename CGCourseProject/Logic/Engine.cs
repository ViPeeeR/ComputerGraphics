using CGCourseProject.Abstracts;
using CGCourseProject.Extentions;
using CGCourseProject.Scenes;
using CGCourseProject.Settings;
using CGCourseProject.Structs;
using CGCourseProject.Utilits;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class Engine
    {
        private IScene _builder;

        private Canvas _canvas;
        private Render _render;
        private Dictionary<Tuple<Point3d, Coord>, Bitmap> _history = 
            new Dictionary<Tuple<Point3d, Coord>, Bitmap>();

        private int _width;
        private int _height;

        public Engine(int width, int height)
        {
            _width = width;
            _height = height;
            _builder = new Scene1();
        }

        public void Initialize()
        {
            _render = new Render();
            _render.SetScene(_builder.CreateScene());
            _builder.SetDefaultScene();
            _render.SetDefaultCamera();

            _render.Scene.PrepareScene();

            _canvas = new Canvas(_width, _height);
        }

        public async Task<Bitmap> RenderScene(Action<int> progress)
        {
            var key = Tuple.Create(_render.Camera.CameraPosition, _render.Camera.GetPosition);
            var result = await Task.Run(() =>
            {
                if (_history.ContainsKey(key))
                    return _history[key];

                _render.MakeRendering(_canvas, progress);
                var img = new Bitmap(_width, _height);

                for (int i = 0; i < _width; i++)
                    for (int j = 0; j < _height; j++)
                        img.SetPixel(i, j, _canvas.GetPixel(i, j).ToRGB());

                return img;
            });

            if (!_history.ContainsKey(key))
                _history.Add(key, result);
            return result;
        }

        public void MoveCamera(Vector3d vector)
        {
            _render.Camera.MoveCamera(vector);
        }

        public void MoveCamera(CameraState state)
        {
            switch (state)
            {
                case CameraState.TopState:
                    _render.SetTopCamera();
                    break;
                case CameraState.DefaultState:
                    _render.SetDefaultCamera();
                    break;
            }
        }

        public void RotateCamera(Coord p)
        {
            _render.Camera.RatateCamera(p.X, p.Y, p.Z);
        }

        public void AddObject(SettingsSphere settings)
        {
            _builder.CreateModel(settings);
            _render.SetScene(_builder.Scene);
            _render.Scene.PrepareScene();

            _history.Clear();
        }

        public void Avion()
        {
            SceneFaceHandlerParams loadParams = new SceneFaceHandlerParams(_builder.Scene,
                // scale:
                15f,
                // move dx, dy, dz:
                0, 50, 0,
                // rotate around axises x, y, z:
                0, 0, (float)Math.PI / 4f + 0.01f,
                // color
                new Structs.Color(100, 100, 100),
                // surface params
                new Material(5, 10, 5, 0, 0, 10)
            );

            _builder.CreateModel(loadParams, "./models/cessna.obj");
            _render.Scene.PrepareScene();
            _history.Clear();
        }

        public void ClearScene()
        {
            _render.SetScene(_builder.CreateScene());
            _render.Scene.PrepareScene();
            _history.Clear();
        }

        public void AddLight()
        {
            _render.Scene.AddLightSource(new LightSource3d(new Point3d(-300, -300, 300),
                   new Structs.Color(255, 255, 255)));
            _render.Scene.PrepareScene();
            _history.Clear();
        }
    }
}
