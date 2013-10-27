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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discotron9000.NutsAndBolts
{
    public class DiscoFloor
    {
        private int _rows;
        private int _columns;

        private double _globalScalingFactor = 1.0;
        private int _globalHueShift = 0;

        private DiscoSquare[,] _discoSquares;

        public int Rows
        {
            get { return _rows; }
        }

        public int Columns
        {
            get { return _columns; }
        }

        public double GlobalScalingFactor
        {
            get { return _globalScalingFactor; }
            set
            {
                _globalScalingFactor = Math.Max(0, Math.Min(1, value));
                FireGlobalScalingFactorChanged();
            }
        }

        public int GlobalHueShift
        {
            get { return _globalHueShift; }
            set
            {
                _globalHueShift = Math.Max(-360, Math.Min(360, value));
                FireGlobalHueShiftChanged();
            }
        }

        public DiscoFloor(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;

            _discoSquares = new DiscoSquare[rows, columns];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    _discoSquares[x, y] = new DiscoSquare(this);
                }
            }
        }

        public DiscoSquare GetSquare(int x, int y)
        {
            x = Math.Max(0, Math.Min(_columns - 1, x));
            y = Math.Max(0, Math.Min(_rows - 1, y));
        
            return _discoSquares[x, y];
        }

        public void LightAllSquares()
        {
            for (int x = 0; x < _columns; x++)
            {
                for (int y = 0; y < _rows; y++)
                {
                    _discoSquares[x, y].IsLit = true;
                }
            }
        }

        public void DimAllSquares()
        {
            for (int x = 0; x < _columns; x++)
            {
                for (int y = 0; y < _rows; y++)
                {
                    _discoSquares[x, y].IsLit = false;
                }
            }
        }

        public event EventHandler GlobalScalingFactorChanged;

        private void FireGlobalScalingFactorChanged()
        {
            if (this.GlobalScalingFactorChanged != null)
            {
                this.GlobalScalingFactorChanged(new object(), EventArgs.Empty);
            }
        }

        public event EventHandler GlobalHueShiftChanged;

        private void FireGlobalHueShiftChanged()
        {
            if (this.GlobalHueShiftChanged != null)
            {
                this.GlobalHueShiftChanged(new object(), EventArgs.Empty);
            }
        }
    }
}
