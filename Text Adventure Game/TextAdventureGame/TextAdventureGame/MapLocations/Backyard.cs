﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Backyard : Location
    {
        public Backyard() : base()
        {
            Name = "Backyard";
            EncounterChance = 0.1;
            Description = "You step outside for just a moment.\nThe air is temperate and comfortable.\nFresh air fills your lungs and reinvigorates you.";
            Image = @"
  _   _   _   _   _   _   _   _   _   _
_| |_| |_| |_| |_| |_| |_| |_| |_| |_| |_
-| |-| |-| |-| |-| |-| |-| |-| |-| |-| |-
 | | | | | | | | | | | | | | | | | | | |
_| |_| |_| |_| |_| |_| |_| |_| |_| |_| |_
-| |-| |-| |-| |-| |-| |-| |-| |-| |-| |-
 |_| |_| |_| |_| |_| |_| |_|||_| |_| |_| 
,,,,,,||,,,,,,,,,,,,,,,,,,,,||,,,,,,,,,,,,,,,,";
        }
    }
}
