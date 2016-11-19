using CGCourseProject.Abstracts;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class Camera : ICoordinateSet, ICoordinateGet
    {
        private const float EPSILON = (float)(1e-5);

        public Point3d CameraPosition { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        
        public float ProjPlaneDist { get; set; }

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
            var rVector = Vector3d.RatateVectorX(vector, (float)Math.Sin(X), (float)Math.Cos(X));
            rVector = Vector3d.RatateVectorZ(rVector, (float)Math.Sin(Z), (float)Math.Cos(Z));
            rVector = Vector3d.RatateVectorY(rVector, (float)Math.Sin(Y), (float)Math.Cos(Y));

            Point3d currPos = CameraPosition;
            CameraPosition = new Point3d(currPos.X + rVector.X, currPos.Y + rVector.Y, currPos.Z + rVector.Z);
        }
    }
}
