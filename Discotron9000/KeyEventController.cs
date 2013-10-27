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

using Discotron9000.NutsAndBolts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discotron9000
{
    public class KeyEventController
    {
        private Form _form;

        public DiscoFloor DiscoFloor { get; set; }

        public Form Form
        {
            get { return _form; }
            set
            {
                UnHookEvents();
                _form = value;
                HookUpEvents();
            }
        }

        private void UnHookEvents()
        {
            if (Form == null)
            {
                return;
            }

            Form.KeyDown -= Form_KeyDown;
        }

        private void HookUpEvents()
        {
            UnHookEvents();

            if (Form == null)
            {
                return;
            }

            Form.KeyDown += Form_KeyDown;
        }

        //private void ToggleColour(int x, int y)
        //{
        //    if (DiscoFloor == null)
        //    {
        //        return;
        //    }

        //    var square = DiscoFloor.GetSquare(x, y);

        //    if (red)
        //    {
        //        if (square.BaseIntensities.Red == 0)
        //        {
        //            square.BaseIntensities = square.BaseIntensities.SetRed(int.MaxValue);
        //        }
        //        else
        //        {
        //            square.BaseIntensities = square.BaseIntensities.SetRed(0);
        //        }
        //    }

        //    if (green)
        //    {
        //        if (square.BaseIntensities.Green == 0)
        //        {
        //            square.BaseIntensities = square.BaseIntensities.SetGreen(int.MaxValue);
        //        }
        //        else
        //        {
        //            square.BaseIntensities = square.BaseIntensities.SetGreen(0);
        //        }
        //    }

        //    if (blue)
        //    {
        //        if (square.BaseIntensities.Blue == 0)
        //        {
        //            square.BaseIntensities = square.BaseIntensities.SetBlue(int.MaxValue);
        //        }
        //        else
        //        {
        //            square.BaseIntensities = square.BaseIntensities.SetBlue(0);
        //        }
        //    }
        //}

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            int x, y;
            switch (e.KeyCode)
            {
                case Keys.F1: x = 0; y = 0; break;
                case Keys.F2: x = 1; y = 0; break;
                case Keys.F3: x = 2; y = 0; break;
                case Keys.F4: x = 3; y = 0; break;
                case Keys.F5: x = 4; y = 0; break;

                case Keys.D1: x = 0; y = 1; break;
                case Keys.D2: x = 1; y = 1; break;
                case Keys.D3: x = 2; y = 1; break;
                case Keys.D4: x = 3; y = 1; break;
                case Keys.D5: x = 4; y = 1; break;

                case Keys.Q: x = 0; y = 2; break;
                case Keys.W: x = 1; y = 2; break;
                case Keys.E: x = 2; y = 2; break;
                case Keys.R: x = 3; y = 2; break;
                case Keys.T: x = 4; y = 2; break;

                case Keys.A: x = 0; y = 3; break;
                case Keys.S: x = 1; y = 3; break;
                case Keys.D: x = 2; y = 3; break;
                case Keys.F: x = 3; y = 3; break;
                case Keys.G: x = 4; y = 3; break;

                case Keys.Z: x = 0; y = 4; break;
                case Keys.X: x = 1; y = 4; break;
                case Keys.C: x = 2; y = 4; break;
                case Keys.V: x = 3; y = 4; break;
                case Keys.B: x = 4; y = 4; break;

                default: return;
            }

            var square = DiscoFloor.GetSquare(x, y);
            square.IsLit = !square.IsLit;
        }
    }
}
