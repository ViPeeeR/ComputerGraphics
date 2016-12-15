using CGCourseProject.Logic;
using CGCourseProject.Settings;
using CGCourseProject.Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Abstracts
{
    public interface IScene
    {
        Scene Scene { get; }
        Scene CreateScene();
        SceneObject CreateSurface();
        void CreateModel(SettingsSphere settings);
        void CreateModel(SceneFaceHandlerParams settings, string filename);
        void SetDefaultScene();
    }
}
