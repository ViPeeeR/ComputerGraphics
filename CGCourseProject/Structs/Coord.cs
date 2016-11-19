using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Structs
{
    public struct Coord
    {
        private float v1;
        private float v2;
        private float v3;

        public Coord(float v1, float v2, float v3) : this()
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
