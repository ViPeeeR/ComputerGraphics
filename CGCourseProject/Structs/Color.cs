using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject.Structs
{
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Color AddColors(Color c1, Color c2)
        {
            int r = (int)c1.R + c2.R;
            int g = (int)c1.G + c2.G;
            int b = (int)c1.B + c2.B;
            r = (r < byte.MaxValue) ? r : byte.MaxValue;
            g = (g < byte.MaxValue) ? g : byte.MaxValue;
            b = (b < byte.MaxValue) ? b : byte.MaxValue;

            return new Color((byte)r, (byte)g, (byte)b);
        }

        public static Color MixColors(Color c1, Color c2)
        {
            uint r = (uint)((c1.R * c2.R) >> 8);
            uint g = (uint)((c1.G * c2.G) >> 8);
            uint b = (uint)((c1.B * c2.B) >> 8);

            return new Color((byte)r, (byte)g, (byte)b);
        }

        public static Color MulColor(Color c, double k)
        {
            return new Color((byte)(c.R * k), (byte)(c.G * k), (byte)(c.B * k));
        }

        public static Color GrayScale(Color c)
        {
            byte gray = (byte)(c.R * 0.2126 + c.G * 0.7152 + c.B * 0.0722);
            return new Color(gray, gray, gray);
        }
    }
}
