﻿using TPGame.Models;

namespace TPGame.Rooms
{
    public class MasterBedroom : Room
    {
        public MasterBedroom() : base()
        {
            Name = "Master Bedroom";
            EncounterChance = 0.6;
            Description = "You return to the Master Bedroom. Perhaps, you missed something before. Better safe than sorry. Couldn't hurt to check under the BED, through the DRESSER, or in the CLOSET.";
            GetItems = ["tool belt"];
            Interactables = ["light switch", "master bed", "dresser", "closet"];
            Image = @"
    |))
    |))
    |))
    |))                                                                                             
    |)) #######                                                                                      
    |))##########                                                                              ((| 
    |)),,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,((|  
    |)),,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,((|  
    |)),,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,((|  
    |)),,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,((|  
    |)),,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,((| 
    |))////////////////////////////////////////////////////////////////////////////////////////((|  
    |))////////////////////////////////////////////////////////////////////////////////////////((|  
    |))                                                                                        ((|                                      
    |))                                                                                        ((|";
        }
    }
}
