﻿using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Rooms;
using TPGame.Models;

namespace TPGame.Items
{
    public class Key : Item
    {
        public Key()
        {
            Name = "key";
            Description = "A bronze key with a green rubber cap to identify it as the garage key. The rubber is worn down where you have picked at it. Why you have a special lock and key for a single room is beyond you, but you weren't the one who designed and built this house.";
        }

        public override void UseItem()
        {
            Garage garage = (Garage)Collections.Rooms.Find(room => room.Name == "Garage");
            if (garage.Locked)
            {
                garage.Unlock();
                DialogueHandler.PrintLine("You turn the key in the door lock. This may have been an effective way of keeping anyone who broke into your garage from accessing the rest of the house, but now, it just seems like a huge hassle.");
            }
            else
            {
                DialogueHandler.PrintLine("You play with flipping the key in the air and catching it on the rubber end. The garage is already unlocked, so it's more useful this way. Just make sure to put it back on the key hook.");
            }
        }
    }
}
