﻿using TPGame.Handlers;
using TPGame.Models;
using TPGame.Rooms;
using TPGame.Dictionaries;

namespace TPGame.Items
{
    public class Knife : Item
    {
        public Knife()
        {
            Name = "knife";
            Description = "The various tools on the utility knife have been worn down. The screwdriver is bent. The corkscrew is fine, but you don't drink wine. The magnifying glass is stuck. The only thing that seems useful is the small knife. " +
                "It's a little dull from your whittling practice, but your duck carvings are getting much better.";
        }

        public override void GetItem()
        {
            ((Kitchen)Collections.VerifyRoom("Kitchen")).KnifeTaken = true;
            base.GetItem();
        }

        public override void UseItem()
        {
            string message;
            if (InputHandler.Character.Player.GetSticks() >= 10)
            {
                ((Garage)Collections.VerifyRoom("Garage")).GetItems.Add("ladder");
                message = "You shave down and cut the sticks into various shapes, removing bits of candy left behind. To your amazement, you can definitely GET a LADDER out of the parts on the CRAFT BENCH now.\nThen again, are you really surprised? You have been practicing very hard recently for something, well not quite exactly like this, but not too dissimilar.";
            }
            else if (InputHandler.Map.CurrentLocation.Name == "Hidden Room")
            {
                message = "You flick out your knife and frantically whittle away at the king's candy shell, removing layer after layer of candy coating until your knife is dull and useless. " + InputHandler.Character.AttackKing(25);
                Collections.HideUsedItem(Name);
            }
            else
            {
                message = "You have all of the tools you need but just aren't able to visualize in your mind how all of this could be used together.\nMaybe with " + (10 - InputHandler.Character.Player.GetSticks()) + " more sticks the picture might become clearer.";
            }
            base.UseItem(message);
        }
    }
}
