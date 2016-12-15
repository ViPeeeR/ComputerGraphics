using CGCourseProject.Abstracts;
using CGCourseProject.Structs;
using CGCourseProject.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class Render
    {
        private readonly ITracer tracing;
        public ICamera Camera { get; private set; }
        public Scene Scene { get; private set; }

        public Render()
        {
            tracing = new Tracer();
        }

        public void SetScene(Scene scene)
        {
            Scene = scene;
        }

        public void SetDefaultCamera()
        {
            float focus = 400;
            float xAngle = -(float)Math.PI / 2;
            float yAngle = 0;
            float zAngle = 0;

            Camera = new Camera(new Point3d(0, -500, 0), xAngle, yAngle, zAngle, focus);
        }

        public void SetTopCamera()
        {
            float focus = 400;
            float xAngle = (float)Math.PI;
            float yAngle = 0;
            float zAngle = 0;

            Camera = new Camera(new Point3d(0, 0, 500), xAngle, yAngle, zAngle, focus);
        }

        public void InitCamera(Point3d position, float xAngel, float yAngel, float zAngel, float focus)
        {
            Camera = new Camera(position, xAngel, yAngel, zAngel, focus);
        }

        public void MakeRendering(Canvas canvas, Action<int> progress)
        {
            int w = canvas.Width;
            int h = canvas.Height;

            float dx = w / 2f;
            float dy = h / 2f;
            float focus = Camera.ProjPlaneDist;

            int count = 0;

            var result = Parallel.For(0, w, i =>
            {
                progress.Invoke(count++);
                Parallel.For(0, h, j =>
                {
                    float x = i - dx;
                    float y = j - dy;
                    var ray = new Vector3d(x, y, focus);
                    var color = tracing.Trace(Scene, Camera, ray);
                    canvas.SetPixel(i, j, color);
                });
            });

            var grayCanvas = canvas.DetectEdgesCanvas();


            Parallel.For(1, w, i =>
            {
                Parallel.For(1, h, j =>
                  {
                      var gray = grayCanvas.GetPixel(i, j).B;
                      if (gray > 10)
                      {
                          float x = i - dx;
                          float y = j - dy;

                          var c = canvas.GetPixel(i, j);
                          float weight = 1f / 4;
                          c = Color.MulColor(c, weight);
                          c = Color.AddColors(c, Color.MulColor(tracing.Trace(Scene, Camera, new Vector3d(x + 0.5f, y, focus)), weight));
                          c = Color.AddColors(c, Color.MulColor(tracing.Trace(Scene, Camera, new Vector3d(x, y + 0.5f, focus)), weight));
                          c = Color.AddColors(c, Color.MulColor(tracing.Trace(Scene, Camera, new Vector3d(x + 0.5f, y + 0.5f, focus)), weight));
                          //c = Color.AddColors(c, Color.MulColor(tracing.Trace(Scene, Camera, new Vector3d(x - 0.5f, y, focus)), weight));
                          //c = Color.AddColors(c, Color.MulColor(tracing.Trace(Scene, Camera, new Vector3d(x, y - 0.5f, focus)), weight));
                          //c = Color.AddColors(c, Color.MulColor(tracing.Trace(Scene, Camera, new Vector3d(x - 0.5f, y - 0.5f, focus)), weight));

                          canvas.SetPixel(i, j, c);
                      }
                  });
            });
        }
    }
}
