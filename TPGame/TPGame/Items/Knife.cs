﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Items
{
    public class Knife : Item
    {
        public Knife() 
        {
            Name = "Knife";
            Description = "The various tools pn the utility knife have been worn down. The screwdriver is bent. The corkscrew is fine, but you don't drink wine. The magnifying glass is stuck. The only thing that seems useful is the small knife. " +
                "It's a little dull from your whittling practice, but your duck carvings are getting much better.";
            Location = "Kitchen";
        }
    }
}
