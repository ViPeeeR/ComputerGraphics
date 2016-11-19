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



        public Render()
        {
            tracing = new Tracer();
        }

        public async Task MakeRendering(Scene scene, Camera camera, Canvas canvas)
        {
            await Task.Run(() =>
            {
                int w = canvas.Width;
                int h = canvas.Height;

                float dx = w / 2f;
                float dy = h / 2f;
                float focus = camera.ProjPlaneDist;

                Parallel.For(0, w, i =>
                {
                    Parallel.For(0, h, j =>
                    {
                        float x = i - dx;
                        float y = j - dy;
                        var ray = new Vector3d(x, y, focus);
                        var color = tracing.Trace(scene, camera, ray);
                        canvas.SetPixel(i, j, color);
                    });
                });

                var grayCanvas = canvas.DetectEdgesCanvas();


                Parallel.For(1, w - 1, i =>
                {
                    Parallel.For(1, h - 1, j =>
                      {
                          var gray = grayCanvas.GetPixel(i, j).R;
                          if (gray > 10)
                          {
                              float x = i - dx;
                              float y = j - dy;

                              var c = canvas.GetPixel(i, j);
                              float weight = 1f / 4f;
                              c = Color.MulColor(c, weight);
                              c = Color.AddColors(c, Color.MulColor(tracing.Trace(scene, camera, new Vector3d(x + 0.5f, y, focus)), weight));
                              c = Color.AddColors(c, Color.MulColor(tracing.Trace(scene, camera, new Vector3d(x, y + 0.5f, focus)), weight));
                              c = Color.AddColors(c, Color.MulColor(tracing.Trace(scene, camera, new Vector3d(x + 0.5f, y + 0.5f, focus)), weight));

                              canvas.SetPixel(i, j, c);
                          }
                      });
                });
            });
        }
    }
}
