﻿using System;
using System.Collections.Generic;
using TPGame.Models;
using TPGame.Handlers;
using TPGame.Rooms;
using TPGame.Commands;
using System.Linq;

namespace TPGame.Dictionaries
{
    public static class Hints
    {
        /// <summary>
        /// Checks inventory and displays hint for first missing item from list
        /// </summary>
        public static void DisplayHints()
        {
            if (!Collections.VerifyInventory("hints"))
            {
                DialogueHandler.PrintLine("Don't panic. Just stick to the plan.");
                DialogueHandler.AddPause(800);
                DialogueHandler.PrintLine("You forgot the plan?");
                DialogueHandler.AddPause(400);
                DialogueHandler.PrintLine("...");
                DialogueHandler.AddPause(800);
                DialogueHandler.PrintLine("That's fine...");
                DialogueHandler.AddPause(400);
                DialogueHandler.PrintLine("I'm sure you wrote it down somewhere. In fact, I'm sure you typed it up. Go USE the COMPUTER in your OFFICE to see if you saved it.");
            }
            else
            {

                string[] itemOrder = ["tool belt", "water bottle", "key", "knife", "ladder", "lantern", "batteries", "metal detector", "shovel", "dentures", "guard"];
                string missing = "";

                foreach (Item i in Array.FindAll(Collections.AllItems, i => !(Collections.VerifyInventory(i.Name))))
                {
                    missing = i.Name;
                }

                if (missing != "")
                {
                    DialogueHandler.PrintLine($"Get {missing}");
                }
                else if (missing == "")
                {
                    DialogueHandler.PrintLine($"Get some fresh air");
                }
                else if (!Collections.VerifyRoom("Hidden Room").BossDefeated)
                {
                    DialogueHandler.PrintLine($"Find what changed");
                }
                else
                {
                    DialogueHandler.PrintLine($"End it!");
                }
                switch (Array.IndexOf(itemOrder, missing))
                {
                    case 0: //tool belt in MB
                        DialogueHandler.PrintLine("You haven't grabbed your tool belt yet? That's part of the tutorial.");
                        DialogueHandler.AddPause(300);
                        DialogueHandler.PrintLine("Go back to the MASTER BEDROOM and USE the CLOSET to GET the TOOL BELT.");
                        break;
                    case 1: //water bottle in kitchen
                        DialogueHandler.PrintLine("You need something to help you stave off the sugar shakes.\nThere's some water in a few places, but it would be a lot better if you had something with which to drink.\nMaybe in the KITCHEN.");
                        break;
                    case 2: //key in living room
                        DialogueHandler.PrintLine("The GARAGE door is locked. As silly as it seemed at the time, it has it's own lock and special KEY. You never remember to put it on the hook when you're done with it.\nMaybe it fell out of your pockets when you were sitting around in the LIVING ROOM.");
                        break;
                    case 3: //knife in kitchen
                        if (((Garage)Collections.VerifyRoom("Garage")).Locked)
                        {
                            DialogueHandler.PrintLine("Don't forget to USE the KEY on the GARAGE door.");
                        }
                        else
                        {
                            DialogueHandler.PrintLine("The GARAGE craft bench has almost everything you need to build a LADDER to the ATTIC. The only thing missing is 10 LOLIPOP STICKS and something to cut them to the right shape.\nLast you remember, you were cutting open packages in the KITCHEN. Seems like a good place to start.");
                        }
                        break;
                    case 4: //ladder in garage
                        if (((Garage)Collections.VerifyRoom("Garage")).Locked)
                        {
                            DialogueHandler.PrintLine("Don't forget to USE the KEY on the GARAGE door.");
                        }
                        else if (InputHandler.Character.Player.GetSticks() < 10)
                        {
                            DialogueHandler.PrintLine("You need " + (10 - InputHandler.Character.Player.GetSticks()) + " more sticks. The PANTRY is full of lolipops. Go start some trouble there for some extra sticks.");
                        }
                        else
                        {
                            DialogueHandler.PrintLine("Now, you have everything you need for the CRAFT BENCH. You should be able to somehow fashion a LADDER to the ATTIC.\nThe CRAFT BENCH in the GARAGE should be able to help you GET your LADDER.");
                        }
                        break;
                    case 5: //lantern in attic
                        if (((Attic)Collections.VerifyRoom("Attic")).Locked)
                        {
                            DialogueHandler.PrintLine("Don't forget to USE the LADDER to climb to the ATTIC.");
                        }
                        DialogueHandler.PrintLine("The BASEMENT is way too dark to see anything. You need some kind of light source.\nYou finally moved all of that gear from your camping trip to the ATTIC last week. Maybe there's something useful there.");
                        break;
                    case 6: //batteries in office
                        DialogueHandler.PrintLine("The lantern won't light itself... Well, not without BATTERIES at least.\nYou have that junk drawer in your OFFICE. Maybe there are BATTERIES in there.");
                        break;
                    case 7: //metal detector in basement
                        if (((Basement)Collections.VerifyRoom("Basement")).IsDark)
                        {
                            DialogueHandler.PrintLine("Don't forget to USE the LANTERN in the BASEMENT.");
                        }
                        else
                        {
                            DialogueHandler.PrintLine("The BACKYARD has been dug up with several spots of freshly turned dirt. It would take forever to check each one.\nMaybe your METAL DETECTOR you keep in the BASEMENT can check them faster.");
                        }
                        break;
                    case 8: //shovel in garage
                        if (((Backyard)Collections.VerifyRoom("Backyard")).UsableItems.Contains("shovel"))
                        {
                            DialogueHandler.PrintLine("You've found something in the BACKYARD but you can't dig it up with your hands.\nYour SHOVEL is normally in the GARAGE but you had to move it to create space for a personal project. You think it's in the BASEMENT now.");
                        }
                        else
                        {
                            DialogueHandler.PrintLine("You can't check every pile of dirt. USE the METAL DETECTOR instead.");
                        }
                        break;
                    case 9: //dentures in bathroom
                        DialogueHandler.PrintLine("You have all of the essentials but a little help wouldn't hurt. You think that something to give you a little more bite would be amazing.\nDid you check the BATHROOM yet? You always seem to forget you even have a MEDICINE CABINET.");
                        break;
                    case 10: //guard in guest bedroom
                        DialogueHandler.PrintLine("You have all of the essentials but a little help wouldn't hurt. You can already feel all of the sugar dissolving your teeth. They could use some protection.\nDid you check the GUEST BEDROOM yet? You recently had company. Maybe they left something worthwhile behind.");
                        break;
                    default: //got all items except maybe mints
                        if (Collections.VerifyRoom("Hidden Room") != null)
                        {
                            DialogueHandler.PrintLine("The SWITCH must have changed something! Check the MAP to see if there's anything new that wasn't there before!");
                        }
                        else if (InputHandler.GetCurrentLocation() == "Hidden Room" && !Collections.VerifyRoom("Hidden Room").BossDefeated)
                        {
                            DialogueHandler.PrintLine("Don't be scared! You have everything you need. Use everything you have to take down the King!");
                        }
                        else if (Collections.VerifyRoom("Hidden Room").BossDefeated)
                        {
                            if (!Collections.VerifyInventory("mints"))
                            {
                                DialogueHandler.PrintLine("Phew! The king has been defeated! You can push that BUTTON on the wall and end this madness.");
                            }
                            else if (!Collections.VerifyItem("mints").Hide)
                            {
                                DialogueHandler.PrintLine("Phew! The king has been defeated! You can push that BUTTON on the wall, but there's a mysterious laughter coming from your pocket. Oh yeah! You still have those MINTS.");
                            }
                            else
                            {
                                DialogueHandler.PrintLine("With the true villains dissolving in your cheeks and stomach, all that remains is the BUTTON on the wall of the HIDDEN ROOM. That should finally resolve this mess.");
                            }
                        }
                        else
                        {
                            DialogueHandler.PrintLine("You have everything you need. The lolipops' base must be nearby.\nMaybe a breath of fresh air will help you think clearly.");
                        }
                        break;
                }
            }
        }
    }
}
