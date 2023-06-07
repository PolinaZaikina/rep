using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using PhotoEnhancer.Filters;

namespace PhotoEnhancer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<SaturationParameters>(
                "Изменение насыщенности",
                (pixel, parameters) => ChangeSaturation(pixel, parameters.Coefficient)));

            Application.Run(mainForm);
        }
        private static Pixel ChangeSaturation(Pixel pixel, double coefficient)
        {
            double h, s, l;
            RGBToHSL(pixel.R, pixel.G, pixel.B, out h, out s, out l);

            s = s * coefficient;
            s = Clamp(s, 0, 1);

            double r, g, b;
            HSLToRGB(h, s, l, out r, out g, out b);

            return new Pixel(r, g, b);
        }
        private static void RGBToHSL(double r, double g, double b, out double h, out double s, out double l)
        {
            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);

            l = (max + min) / 2;

            if (Math.Abs(max - min) < 1e-9)
            {
                h = 0;
                s = 0;
            }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

                if (max == r)
                    h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;

                h /= 6;
            }
        }
        private static void HSLToRGB(double h, double s, double l, out double r, out double g, out double b)
        {
            if (Math.Abs(s) < 1e-9)
            {
                r = l;
                g = l;
                b = l;
            }
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;

                r = HueToRGB(p, q, h + 1 / 3.0);
                g = HueToRGB(p, q, h);
                b = HueToRGB(p, q, h - 1 / 3.0);
            }
        }
        private static double HueToRGB(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1 / 6.0) return p + (q - p) * 6 * t;
            if (t < 1 / 2.0) return q;
            if (t < 2 / 3.0) return p + (q - p) * (2 / 3.0 - t) * 6;
            return p;
        }
        private static double Clamp(double value, double min, double max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
    }
}
