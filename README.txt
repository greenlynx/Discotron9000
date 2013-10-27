Software for controlling the bike-powered disco floor. Better instructions coming soon...

Square are laid out in 5 rows of 5, and numbered internally from 0 to 24.

0 is top-left, 4 is top-right, 24 is bottom-right etc.

MIDI messages
-------------

Pitch bend:   cycles the hue of every square on the floor
CC7 (volume): controls the overall brightness of the floor

CC10:         controls the hue of square 0
CC11:         controls the shade of square 0
CC12:         controls the hue of square 1
CC13:         controls the shade of square 1
...
CC58:         controls the hue of square 24
CC59:         controls the shade of square 24


Turning squares on and off (note on/off messages)
-------------------------------------------------

C, C#, D, D#, E - selects the column
Octave (3 - 7)  - selects the row
Velocity        - sets the brightness of the square