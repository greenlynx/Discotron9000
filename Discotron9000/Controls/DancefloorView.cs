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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discotron9000.NutsAndBolts;

namespace Discotron9000.Controls
{
    public partial class DancefloorView : UserControl
    {
        private DiscoFloor _discoFloor;

        public DiscoFloor DiscoFloor
        {
            get { return _discoFloor; }
            set
            {
                _discoFloor = value;
                DiscoFloorUpdated();
            }
        }

        private void DiscoFloorUpdated()
        {
            InitialiseDisplay();
        }

        private void InitialiseDisplay()
        {
            _floorLayoutPanel.Controls.Clear();

            if (_discoFloor == null)
            {
                return;
            }

            for (int x = 0; x < DiscoFloor.Columns; x++)
            {
                for (int y = 0; y < DiscoFloor.Rows; y++)
                {
                    var squareView = new DanceFloorSquareView()
                    {
                        AttachedDiscoSquare = DiscoFloor.GetSquare(x, y)
                    };
                    squareView.Dock = DockStyle.Fill;

                    _floorLayoutPanel.Controls.Add(squareView, x, y);
                }
            }
        }

        public DancefloorView()
        {
            InitializeComponent();

            InitialiseDisplay();
        }
    }
}
