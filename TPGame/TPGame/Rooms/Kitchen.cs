﻿using TPGame.Models;

namespace TPGame.Rooms
{
    public class Kitchen : Room
    {
        public Kitchen() : base()
        {
            Name = "Kitchen";
            EncounterChance = 0.8;
            Description = "The kitchen seems disturbingly still. Your FRIDGE is silent, the SINK is dry as a bone, the CABINET doors are shut tight, and the WATER BOWL is full and still. Everything seems to be neatly in its place.\nExcept for your utility KNIFE, which you seem to have left on the counter near the sink.";
            GetItems = ["knife", "water bottle"];
            Interactables = ["light switch", "kitchen sink", "cabinet", "fridge", "water bowl"];
            Image = @"
                                         /------------\                                           
                                        /**************\                                          
                                        |**/--------\***|                                         
                                        |**|        |***|                                        
                                        |**|        |***|                                        
                                        |**|                                                       
                                        |**|                                                       
                                        |**|                                                       
                              (____     |**|     ____)                                             
                                 ||     |**|     ||                                                
                                 ||     |**|     ||                                             
           ____________________________________________________________                          
            \%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%/                           
            |########################################################|                           
            |########################################################|                           
            |________________________________________________________|
";
        }
    }
}
