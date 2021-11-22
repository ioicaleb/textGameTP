﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Models
{
    public class InputAction
    {
        public InputAction() { }

        public string Command { get; set; }
        public string Target { get; set; }

        public InputAction SetAction(string command)
        {
            InputAction action = new InputAction { Command = command };
            return action;
        }
    }
}
