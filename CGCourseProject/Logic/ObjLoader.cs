using CGCourseProject.Structs;
using CGCourseProject.Triangle;
using CGCourseProject.Utilits;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Logic
{
    public class ObjLoader
    {
        private List<Point3d> vertexes = new List<Point3d>();
        private List<Vector3d> normVectors = new List<Vector3d>();

        public void LoadObj(string filename, Action<Queue<Point3d>, Queue<Vector3d>, SceneFaceHandlerParams> faceHandler,
            SceneFaceHandlerParams args)
        {
            using (var stream = new StreamReader(filename))
            {
                string line;
                while (!stream.EndOfStream)
                {
                    line = stream.ReadLine();                    
                    line = line.Replace('.', ',');

                    if (string.IsNullOrEmpty(line))
                        continue;

                    if ((line[0] != 'v') && (line[0] != 'f'))
                        continue;

                    if ((line[0] == 'v') && (line[1] == ' '))
                        ParseVertex(line.Substring(2));

                    if ((line[0] == 'v') && (line[1] == 'n'))
                        ParseNormVector(line.Substring(3));

                    if ((line[0] == 'f') && (line[1] == ' '))
                        ParseFace(line.Substring(2), faceHandler, args);
                }
            }
        }

        private void ParseFace(string v, Action<Queue<Point3d>, Queue<Vector3d>, SceneFaceHandlerParams> faceHandler,
            SceneFaceHandlerParams args)
        {
            Queue<string> tokens = new Queue<string>();
            v = v.Trim();
            foreach(var item in v.Split(' '))
                tokens.Enqueue(item);

            Queue<Point3d> vertex = new Queue<Point3d>();
            Queue<Vector3d> normVector = new Queue<Vector3d>();

            int vertexIndex = 0;
            int textureIndex = 0;
            int normIndex = 0;
            while(tokens.Count > 0)
            {
                var token = tokens.Dequeue();
                ParseFaceStr(token, out vertexIndex, out textureIndex, out normIndex);

                vertex.Enqueue(vertexes[vertexIndex - 1]);

                if (normIndex > 0)
                    normVector.Enqueue(normVectors[normIndex - 1]);
            }

            faceHandler(vertex, normVector, args);
        }

        private void ParseFaceStr(string str, out int vertexIndex, out int textureIndex, out int normIndex)
        {
            vertexIndex = 0;
            textureIndex = 0;
            normIndex = 0;

            var v = str.Trim().Split('/');

            if (v.Length >= 1)
            {
                if (v[0].Length > 0)
                    vertexIndex = int.Parse(v[0]);

                if (v.Length >= 2)
                {
                    if (v[1].Length > 0)
                        textureIndex = int.Parse(v[1]);

                    if (v.Length >= 3)
                    {
                        if (v[2].Length > 0)
                            normIndex = int.Parse(v[2]);
                    }
                }
            }
        }

        private void ParseNormVector(string v)
        {
            var @params = v.Trim().Split(' ');
            var vector = new Vector3d(Convert.ToSingle(@params[2]), 
                Convert.ToSingle(@params[0]), Convert.ToSingle(@params[1]));
            normVectors.Add(vector);
        }

        private void ParseVertex(string v)
        {
            var @params = v.Trim().Split(' ');
            var point = new Point3d(Convert.ToSingle(@params[2]), 
                Convert.ToSingle(@params[0]), Convert.ToSingle(@params[1]));
            vertexes.Add(point);
        }

        public void SceneFaceHandler(Queue<Point3d> vertexes, Queue<Vector3d> normVectors, SceneFaceHandlerParams arg)
        {
            Scene scene = arg.Scene;
            float scale = arg.Scale;
            float dx = arg.dx;
            float dy = arg.dy;
            float dz = arg.dz;

            float sin_al_x = (float)Math.Sin(arg.X);
            float cos_al_x = (float)Math.Cos(arg.X);

            float sin_al_y = (float)Math.Sin(arg.Y);
            float cos_al_y = (float)Math.Cos(arg.Y);

            float sin_al_z = (float)Math.Sin(arg.Z);
            float cos_al_z = (float)Math.Cos(arg.Z);

            Color default_color = arg.DefaultColor;
            Material default_material = arg.DefaultMaterial;

            Point3d p_p1 = vertexes.Dequeue();
            Point3d p_p2 = vertexes.Dequeue();
            Point3d p_p3;


            Vector3d p_v1 = new Vector3d();
            Vector3d p_v2 = new Vector3d();
            Vector3d p_v3 = new Vector3d();
            bool isQueueFull = false;

            if (normVectors.Count > 0)
            {
                p_v1 = normVectors.Dequeue();
                p_v2 = normVectors.Dequeue();
                isQueueFull = true;
            }

            Point3d p1;
            Point3d p2;
            Point3d p3;

            Vector3d v1;
            Vector3d v2;
            Vector3d v3;

            while (vertexes.Count > 0)
            {
                p_p3 = vertexes.Dequeue();
                if (normVectors.Count > 0 || isQueueFull)
                    p_v3 = normVectors.Dequeue();

                p1 = Point3d.RatatePointX(p_p1, sin_al_x, cos_al_x);
                p1 = Point3d.RatatePointY(p1, sin_al_y, cos_al_y);
                p1 = Point3d.RatatePointZ(p1, sin_al_z, cos_al_z);

                p2 = Point3d.RatatePointX(p_p2, sin_al_x, cos_al_x);
                p2 = Point3d.RatatePointY(p2, sin_al_y, cos_al_y);
                p2 = Point3d.RatatePointZ(p2, sin_al_z, cos_al_z);

                p3 = Point3d.RatatePointX(p_p3, sin_al_x, cos_al_x);
                p3 = Point3d.RatatePointY(p3, sin_al_y, cos_al_y);
                p3 = Point3d.RatatePointZ(p3, sin_al_z, cos_al_z);

                if (isQueueFull)
                {

                    v1 = Vector3d.RatateVectorX(p_v1, sin_al_x, cos_al_x);
                    v1 = Vector3d.RatateVectorY(v1, sin_al_y, cos_al_y);
                    v1 = Vector3d.RatateVectorZ(v1, sin_al_z, cos_al_z);

                    v2 = Vector3d.RatateVectorX(p_v2, sin_al_x, cos_al_x);
                    v2 = Vector3d.RatateVectorY(v2, sin_al_y, cos_al_y);
                    v2 = Vector3d.RatateVectorZ(v2, sin_al_z, cos_al_z);

                    v3 = Vector3d.RatateVectorX(p_v3, sin_al_x, cos_al_x);
                    v3 = Vector3d.RatateVectorY(v3, sin_al_y, cos_al_y);
                    v3 = Vector3d.RatateVectorZ(v3, sin_al_z, cos_al_z);

                    scene.AddObject(
                        new Triangle3dn(
                            new Point3d(p1.X * scale + dx, p1.Y * scale + dy, p1.Z * scale + dz),
                            new Point3d(p2.X * scale + dx, p2.Y * scale + dy, p2.Z * scale + dz),
                            new Point3d(p3.X * scale + dx, p3.Y * scale + dy, p3.Z * scale + dz),
                            v1, v2, v3,
                            default_color,
                            default_material)
                        );
                }
                else {
                    scene.AddObject(
                        new Triangle3d(
                            new Point3d(p1.X * scale + dx, p1.Y * scale + dy, p1.Z * scale + dz),
                            new Point3d(p2.X * scale + dx, p2.Y * scale + dy, p2.Z * scale + dz),
                            new Point3d(p3.X * scale + dx, p3.Y * scale + dy, p3.Z * scale + dz),
                            default_color,
                            default_material)
                        );
                }

                p_p2 = p_p3;
                p_v2 = p_v3;
            }
        }
    }
}
