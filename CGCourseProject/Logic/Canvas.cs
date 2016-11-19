using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color[] Colors { get; }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            Colors = new Color[width * height + 1];
        }

        public void SetPixel(int x, int y, Color c)
        {
            int offs = y * Width + x;
            Colors[offs] = c;
        }

        public Color GetPixel(int x, int y)
        {
            int offs = y * Width + x;
            return Colors[offs];
        }

        int[,] mattrix_x = new int[3, 3]
        {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };

        int[,] mattrix_y = new int[3, 3]
        {
            { -1, -2, -1 },
            {  0,  0,  0 },
            {  1,  2,  1 }
        };

        public Canvas DetectEdgesCanvas()
        {
            var grayScaleCanvas = GrayScaleCanvas();
            var result = new Canvas(Width, Height);

            Parallel.For(1, Width - 1, x =>
            {
                Parallel.For(1, Height - 1, y =>
                {
                    int gx = 0, gy = 0;
                    for (int i = -1; i < 2; i++)
                        for (int j = -1; j < 2; j++)
                        {
                            var r = grayScaleCanvas.GetPixel(x + i, y + j).R;
                            gx += mattrix_x[i + 1, j + 1] * r;
                            gy += mattrix_y[i + 1, j + 1] * r;
                        }

                    byte grad = (byte)Math.Sqrt(gx * gx + gy * gy);
                    result.SetPixel(x, y, new Color(grad, grad, grad));
                });
            });

            return result;
        }

        private Canvas GrayScaleCanvas()
        {
            var result = new Canvas(Width, Height);

            Parallel.For(0, Width, i =>
            {
                Parallel.For(0, Height, j =>
                {
                    var c = GetPixel(i, j);
                    var gray = Color.GrayScale(c);
                    result.SetPixel(i, j, gray);
                });
            });

            return result;
        }
    }
}
