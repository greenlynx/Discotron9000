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
    public class IntensitiesChangedEventArgs : EventArgs
    {
        public HsvTriplet Intensities { get; private set; }

        public IntensitiesChangedEventArgs(HsvTriplet intensities)
        {
            Intensities = intensities;
        }
    }
}
