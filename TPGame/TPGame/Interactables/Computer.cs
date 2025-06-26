﻿using TPGame.Dictionaries;
using TPGame.Models;
using TPGame.Items;

namespace TPGame.Interactables
{
    public class Computer : Interactable
    {
        public Computer()
        {
            Name = "computer";
            Description = "The old girl is just as reliable as the day you got her, which is to say not very.";
        }

        public override void UseInteractable()
        {
            string message;
            if (!Collections.VerifyInventory("hints"))
            {
                message = "You dig through your folders to find your emergency plan. With that printed out, you'll be able to reference your plan whenever you forget it. You hover over the GET HINTS button to send the list to your printer.";
                Collections.AddInventory(new HintList());
            }
            else 
            {
                message = "You spot a folder of unfinished projects that were started and abandoned. You don't have the time right now. Just definitely don't forget to work on them when things calm down...";
            }
            base.UseInteractable(message);
        }
    }
}

