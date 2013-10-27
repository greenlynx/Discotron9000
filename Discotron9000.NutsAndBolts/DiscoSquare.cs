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
    public class DiscoSquare
    {
        private DiscoFloor _discoFloor;

        private bool _updatingMultipleProperties;

        private HsvTriplet _baseIntensities;
        private bool _isLit;

        public bool IsLit
        {
            get { return _isLit; }
            set
            {
                _isLit = value;

                FireIntensitiesChanged();
            }
        }

        public DiscoSquare(DiscoFloor discoFloor)
        {
            _discoFloor = discoFloor;
            _discoFloor.GlobalScalingFactorChanged += _discoFloor_GlobalValueChanged;
            _discoFloor.GlobalHueShiftChanged += _discoFloor_GlobalValueChanged;

            _baseIntensities = HsvTriplet.Zero;
        }

        private void _discoFloor_GlobalValueChanged(object sender, EventArgs e)
        {
            FireIntensitiesChanged();
        }

        private void BeginUpdatingMultipleProperties()
        {
            _updatingMultipleProperties = true;
        }

        private void EndUpdatingMultipleProperties()
        {
            _updatingMultipleProperties = false;
            FireIntensitiesChanged();
        }

        public HsvTriplet BaseIntensities
        {
            get { return _baseIntensities; }
            set
            {
                _baseIntensities = value;

                FireIntensitiesChanged();
            }
        }

        public HsvTriplet EffectiveIntensities
        {
            get
            {
                if (_discoFloor == null)
                {
                    return BaseIntensities;
                }

                if (!_isLit)
                {
                    return HsvTriplet.Zero;
                }

                return _baseIntensities.Transform(_discoFloor.GlobalScalingFactor, _discoFloor.GlobalHueShift);
            }
        }

        public void TurnOnWithValue(double value)
        {
            try
            {
                BeginUpdatingMultipleProperties();

                BaseIntensities = BaseIntensities.WithValue(value);
                IsLit = true;
            }
            finally
            {
                EndUpdatingMultipleProperties();
            }
        }

        public event EventHandler IntensitiesChanged;

        private void FireIntensitiesChanged()
        {
            if (_updatingMultipleProperties)
            {
                return;
            }

            if (this.IntensitiesChanged != null)
            {
                this.IntensitiesChanged(new object(), new IntensitiesChangedEventArgs(EffectiveIntensities));
            }
        }
    }
}
