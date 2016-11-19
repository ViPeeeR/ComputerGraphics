using CGCourseProject.Logic;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Utilits
{
    public class SceneFaceHandlerParams
    {
        public float Scale { get; set; }
        public float dx;
        public float dy;
        public float dz;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Scene Scene { get; set; }

        public Color DefaultColor { get; set; }
        public Material DefaultMaterial { get; set; }

        /// <summary>
        /// Create parameter for model
        /// </summary>
        /// <param name="scene">This scene</param>
        /// <param name="scale">Scale model</param>
        /// <param name="dx">Move model for Ox axis</param>
        /// <param name="dy">Move model for Oy axis</param>
        /// <param name="dz">Move model for Oz axis</param>
        /// <param name="x">Rotate model around Ox axis</param>
        /// <param name="y">Rotate model around Oy axis</param>
        /// <param name="z">Rotate model around Ox axis</param>
        /// <param name="defaultColor">Set color default</param>
        /// <param name="defaultMaterial">Set material default</param>
        public SceneFaceHandlerParams(Scene scene, float scale, float dx, float dy, float dz, 
            float x, float y, float z, Color defaultColor, Material defaultMaterial)
        {
            this.Scene = scene;
            this.Scale = scale;
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.DefaultColor = defaultColor;
            this.DefaultMaterial = defaultMaterial;
        }
    }
}
