using CGCourseProject.Abstracts;
using CGCourseProject.Logic;
using CGCourseProject.Structs;
using CGCourseProject.Utilits;
using System;
using System.Threading.Tasks;

namespace CGCourseProject.Trace
{
    public class Tracer : ITracer
    {
        private const float EPSILON = (float)(1e-5);

        public Color Trace(Scene scene, Camera camera, Vector3d vector)
        {
            var rotateVec = Vector3d.RatateVectorX(vector, (float)Math.Sin(camera.X), (float)Math.Cos(camera.X));
            rotateVec = Vector3d.RatateVectorZ(rotateVec, (float)Math.Sin(camera.Z), (float)Math.Cos(camera.Z));
            rotateVec = Vector3d.RatateVectorY(rotateVec, (float)Math.Sin(camera.Y), (float)Math.Cos(camera.Y));

            return Recursively(scene, camera.CameraPosition, rotateVec, 100, 0);
        }

        private Color Recursively(Scene scene, Point3d vectorStart, Vector3d vector,
            float intensity, int recursionLevel)
        {
            IObject3d nearestObj = null;
            Point3d nearestIntersectionPoint = new Point3d();
            float nearestIntersectionPointDist = float.MaxValue;

            if (scene.KDTree.FindIntersectionTree(vectorStart, vector,
                ref nearestObj, ref nearestIntersectionPoint, ref nearestIntersectionPointDist))
            {
                return CalcColor(scene, vectorStart, vector, nearestObj, nearestIntersectionPoint,
                    nearestIntersectionPointDist, intensity, recursionLevel);
            }

            return scene.BackgroundColor;
        }

        private Color CalcColor(Scene scene, Point3d vectorStart, Vector3d vector, IObject3d obj,
            Point3d point, float dist, float intensity, int recursionLevel)
        {
            Material material = obj.GetMaterial;

            Vector3d norm = obj.GetNormalVector(point);

            Color objColor = obj.GetColor;
            Color ambientColor = new Color();
            Color diffuseColor = new Color();
            Color reflectedColor = new Color();
            Color specularColor = new Color();

            float fogDensity = 0;
            if (scene.FogDestiny != null)
                fogDensity = scene.FogDestiny.Invoke(dist);


            Vector3d reflectedRay = new Vector3d();
            if ((material.Ks != 0f) || (material.Kr != 0f))
                reflectedRay = Utils.ReflectRay(vector, norm);

            // Ambient
            if (material.Ka != 0)
                ambientColor = Color.MixColors(scene.BackgroundColor, objColor);

            // Diffuse
            if (material.Kd != 0)
            {
                diffuseColor = objColor;
                if (scene.LightSources.Count > 0)
                {
                    Color light_color = GetLightingColor(point, norm, scene);
                    diffuseColor = Color.MixColors(diffuseColor, light_color);
                }
            }

            // Specular
            if (material.Ks != 0)
            {
                specularColor = scene.BackgroundColor;
                if (scene.LightSources.Count > 0)
                    specularColor = GetSpecularColor(point, reflectedRay, scene, material.P);
            }

            // Reflect
            if (material.Kr != 0)
            {
                if (intensity > 10 && recursionLevel < 10)
                    reflectedColor = Recursively(scene, point, reflectedRay, intensity * material.Kr * (1 - fogDensity),
                        recursionLevel + 1);
                else
                    reflectedColor = scene.BackgroundColor;
            }

            // Result
            Color resultColor = new Color(0, 0, 0);

            if (material.Ka != 0)
                resultColor = Color.AddColors(resultColor, Color.MulColor(ambientColor, material.Ka));

            if (material.Kd != 0)
                resultColor = Color.AddColors(resultColor, Color.MulColor(diffuseColor, material.Kd));

            if (material.Ks != 0)
                resultColor = Color.AddColors(resultColor, Color.MulColor(specularColor, material.Ks));

            if (material.Kr != 0)
                resultColor = Color.AddColors(resultColor, Color.MulColor(reflectedColor, material.Kr));

            if (scene.FogDestiny != null)
                resultColor = Color.AddColors(Color.MulColor(scene.BackgroundColor, fogDensity),
                    Color.MulColor(resultColor, 1 - fogDensity));

            return resultColor;
        }

        private Color GetSpecularColor(Point3d point, Vector3d reflectedRay, Scene scene, float p)
        {
            Color lightColor = new Color(0, 0, 0);
            LightSource3d light = null;
            Vector3d vLight = new Vector3d();
            float cosLight;
            Color colorLight = new Color();

            for (var i = 0; i < scene.LightSources.Count; i++)
            {
                light = scene.LightSources[i];
                if (IsViewable(light.Location, point, scene))
                {
                    vLight = new Vector3d(point, light.Location);
                    cosLight = Utils.CosVectors(reflectedRay, vLight);
                    if (cosLight > EPSILON)
                    {
                        colorLight = Color.MulColor(light.Color, Math.Pow(cosLight, p));
                        lightColor = Color.AddColors(lightColor, colorLight);
                    }
                }
            }

            return lightColor;
        }

        private Color GetLightingColor(Point3d point, Vector3d norm, Scene scene)
        {
            Color lightColor = new Color(0, 0, 0);
            LightSource3d light = null;
            Vector3d vLight = new Vector3d();
            float cosLight;
            Color colorLight = new Color();

            for (var i = 0; i< scene.LightSources.Count; i++)
            {
                light = scene.LightSources[i];
                if (IsViewable(light.Location, point, scene))
                {
                    vLight = new Vector3d(point, light.Location);
                    cosLight = Math.Abs(Utils.CosVectors(norm, vLight));
                    colorLight = Color.MulColor(light.Color, cosLight);
                    lightColor = Color.AddColors(lightColor, colorLight);
                }
            }

            return lightColor;
        }

        private bool IsViewable(Point3d targetPoint, Point3d startingPoint, Scene scene)
        {
            var ray = new Vector3d(startingPoint, targetPoint);
            float targetDist = Utils.ModuleVector(ray);

            IObject3d nearestObj = null;
            var nearestIntersectionPoint = new Point3d();
            var nearestIntersectionPointDist = float.MaxValue;

            if (scene.KDTree.FindIntersectionTree(startingPoint, ray, ref nearestObj,
                    ref nearestIntersectionPoint, ref nearestIntersectionPointDist))
                return targetDist < nearestIntersectionPointDist;

            return true;
        }
    }
}
