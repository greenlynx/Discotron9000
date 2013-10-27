/*
 * Copyright 2013 PoWWow Pedal Power
 * 
 * This file is part of Discotron 9000.
 * 
 * Discotron 9000 is free software: you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation, either version 3 of the License,
 * or (at your option) any later version.
 * 
 * Discotron 9000 is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even
 * the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public
 * License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with Discotron 9000. If not, see
 * http://www.gnu.org/licenses/.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discotron9000.NutsAndBolts
{
    public struct HsvTriplet
    {
        private double _hue;
        private double _saturation;
        private double _value;

        public double Hue
        {
            get { return _hue; }
        }

        public double Saturation
        {
            get { return _saturation; }
        }

        public double Value
        {
            get { return _value; }
        }
        
        private static double Clamp(double value, double maximum, double minimum = 0)
        {
            return Math.Max(minimum, Math.Min(maximum, value));
        }

        public HsvTriplet(double hue, double saturation, double value)
        {
            _hue = Clamp(hue, 360);
            _saturation = Clamp(saturation, 1);
            _value = Clamp(value, 1);
        }

        public Color ToColor()
        {
            return HSVToRGB(_hue, _saturation, _value);
        }

        public HsvTriplet WithHue(double hue)
        {
            return new HsvTriplet(hue, _saturation, _value);
        }

        public HsvTriplet WithSaturation(double saturation)
        {
            return new HsvTriplet(_hue, saturation, _value);
        }

        public HsvTriplet WithValue(double value)
        {
            return new HsvTriplet(_hue, _saturation, value);
        }

        private static Color HSVToRGB(double _hue, double _saturation, double _brightness)
        {
            double Min;
            double Chroma;
            double Hdash;
            double X;
            double red = 0;
            double green = 0;
            double blue = 0;

            Chroma = _saturation * _brightness;
            Hdash = _hue / 60.0;
            X = Chroma * (1.0 - Math.Abs((Hdash % 2.0) - 1.0));

            if (Hdash < 1.0)
            {
                red = Chroma;
                green = X;
            }
            else if (Hdash < 2.0)
            {
                red = X;
                green = Chroma;
            }
            else if (Hdash < 3.0)
            {
                green = Chroma;
                blue = X;
            }
            else if (Hdash < 4.0)
            {
                green = X;
                blue = Chroma;
            }
            else if (Hdash < 5.0)
            {
                red = X;
                blue = Chroma;
            }
            else if (Hdash <= 6.0)
            {
                red = Chroma;
                blue = X;
            }

            Min = _brightness - Chroma;

            red += Min;
            green += Min;
            blue += Min;

            return Color.FromArgb((int)(red * 255), (int)(green * 255), (int)(blue * 255));
        }
        
        public HsvTriplet Transform(double valueScalingFactor, int hueShift)
        {
            return new HsvTriplet((((_hue + hueShift) % 360) + 360) % 360, _saturation, _value * valueScalingFactor);
        }

        public static HsvTriplet Zero
        {
            get { return new HsvTriplet(0, 0, 0); }
        }
    }
}
