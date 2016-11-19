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
        /// Диффузный свет
        /// </summary>
        public float Kd { get; set; }
        /// <summary>
        /// Зеркальный свет
        /// </summary>
        public float Ks { get; set; }
        /// <summary>
        /// Отражательная способность
        /// </summary>
        public float Kr { get; set; }
        /// <summary>
        /// Пропущенный свет
        /// </summary>
        public float Kt { get; set; }
        
        public float P { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ka">Рассеянный свет</param>
        /// <param name="kd">Диффузный свет</param>
        /// <param name="ks">Зеркальный свет</param>
        /// <param name="kr">Отражательная способность</param>
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
