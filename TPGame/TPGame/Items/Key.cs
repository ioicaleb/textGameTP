﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Items
{
    public class Key : Item
    {
        public Key()
        {
            Name = "Key";
            Description = "A bronze key with a green rubber cap to identify it as the garage key. The rubber is worn down where you have picked at it.";
            Location = "Living Room";
        }
    }
}