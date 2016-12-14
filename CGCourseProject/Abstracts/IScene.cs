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
        Scene CreateScene();
        void CreateSphere(SettingsSphere settings);

        void CreateModel(SceneFaceHandlerParams settings);
    }
}
