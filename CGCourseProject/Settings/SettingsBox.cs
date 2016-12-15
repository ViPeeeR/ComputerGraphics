using CGCourseProject.Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCourseProject.Logic;
using CGCourseProject.Structs;

namespace CGCourseProject.Settings
{
    public class SettingsBox : SceneFaceHandlerParams
    {
        public SettingsBox(Scene scene, float scale, float dx, float dy, float dz, float x,
            float y, float z, Color defaultColor, Material defaultMaterial) 
            : base(scene, scale, dx, dy, dz, x, y, z, defaultColor, defaultMaterial)
        {
        }

        public static SceneFaceHandlerParams DefaultSettings(Scene scene)
        {
            return new SceneFaceHandlerParams(scene,
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
        }
    }
}
