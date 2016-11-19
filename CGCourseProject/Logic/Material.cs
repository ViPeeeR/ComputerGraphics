using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class Material
    {
        /// <summary>
        /// Рассеянный свет
        /// </summary>
        public float Ka { get; set; }

        /// <summary>
        /// Диффузное отражение
        /// </summary>
        public float Kd { get; set; }

        /// <summary>
        /// Зеркальное отражение
        /// </summary>
        public float Ks { get; set; }

        /// <summary>
        /// Отраженный свет
        /// </summary>
        public float Kr { get; set; }

        /// <summary>
        /// Пропущенный свет
        /// </summary>
        public float Kt { get; set; }

        public float P;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ka">Рассеянный свет</param>
        /// <param name="kd">Диффузное отражение</param>
        /// <param name="ks">Зеркальное отражение</param>
        /// <param name="kr">Отраженный свет</param>
        /// <param name="kt">Пропущенный свет</param>
        /// <param name="p"></param>
        public Material(float ka, float kd, float ks, float kr, float kt, float p)
        {
            float sum = ka + kd + ks + kr + kt;
            Ka = ka / sum;
            Kd = kd / sum;
            Ks = ks / sum;
            Kr = kr / sum;
            Kt = kt / sum;
            P = p;
        }
    }
}
