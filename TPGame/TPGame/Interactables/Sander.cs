﻿using TPGame.Models;
using TPGame.Commands;
using TPGame.Handlers;

namespace TPGame.Interactables
{
    public class Sander : Interactable
    {
        public Sander() 
        {
            Name = "sander";
            Description = "A belt sander that looks like it could do some real damage. If the cord wasn't so short, you might be able to really put the hurt on some lolipops.";
        }

        public override void UseInteractable()
        {
            if (InputHandler.Character.Lolipop.Name == "Bishop" && InputHandler.Character.Lolipop.Health > 0)
            {
                InputHandler.Character.AttackBoss("You grab the sander and grind the bishop down to a thin shell. One more lick ought to reach the core.");
            }
            else
            {
                base.UseInteractable("The sander doesn't seem to have much use right now.");
            }
        }
    }
}
