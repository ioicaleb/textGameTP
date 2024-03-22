﻿using TPGame.Models;

namespace TPGame.MapLocations
{
    public class MasterBedroom : Room
    {
        public MasterBedroom() : base()
        {
            Name = "Master Bedroom";
            EncounterChance = 0.6;
            Description = "You return to the Master Bedroom. Perhaps, you missed something before. Better safe than sorry.";
            GetItems = ["tool belt"];
            Interactables = ["light switch", "bed", "dresser", "closet"];
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
