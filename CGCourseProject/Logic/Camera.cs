using CGCourseProject.Abstracts;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class Camera : ICamera
    {
        private const float EPSILON = (float)(1e-5);

        private float xsin;
        private float ysin;
        private float zsin;

        private float xcos;
        private float ycos;
        private float zcos;

        private float x;
        private float y;
        private float z;

        public Point3d CameraPosition { get; private set; }

        public float X
        {
            get { return x; }
            private set
            {
                x = value;
                xsin = (float)Math.Sin(value);
                xcos = (float)Math.Cos(value);
            }
        }

        public float Y
        {
            get { return y; }
            private set
            {
                y = value;
                ysin = (float)Math.Sin(value);
                ycos = (float)Math.Cos(value);
            }
        }

        public float Z
        {
            get { return z; }
            private set
            {
                z = value;
                zsin = (float)Math.Sin(value);
                zcos = (float)Math.Cos(value);
            }
        }

        public float ProjPlaneDist { get; }

        public Camera(Point3d cameraPosition, float x, float y, float z, float projPlaneDist)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            CameraPosition = cameraPosition;
            ProjPlaneDist = projPlaneDist;
        }

        public void RatateCamera(float x, float y, float z)
        {
            if (Math.Abs(x) > EPSILON)
                X += x;

            if (Math.Abs(y) > EPSILON)
                Y += y;

            if (Math.Abs(z) > EPSILON)
                Z += z;            
        }

        public void MoveCamera(Vector3d vector)
        {
            var rVector = Vector3d.RatateVectorX(vector, xsin, xcos);
            rVector = Vector3d.RatateVectorZ(rVector, zsin, zcos);
            rVector = Vector3d.RatateVectorY(rVector, ysin, ycos);

            Point3d currPos = CameraPosition;
            CameraPosition = new Point3d(currPos.X + rVector.X, currPos.Y + rVector.Y, currPos.Z + rVector.Z);
        }
    }
}
