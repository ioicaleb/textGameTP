using TPGame.Rooms;
using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;

namespace TPGame.Commands
{
    public class RoomCommand
    {
        
        public Room CurrentLocation { get; set; } = new MasterBedroom();
        public bool InCombat { get; set; } = false;

        /// <summary>
        /// Verifies that input is a valid room
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool VerifyRoom(string target)
        {
            Room room = Collections.VerifyRoom(target);
            if (room != null)
            {
                if (room.Name == CurrentLocation.Name)
                {
                    DialogueHandler.PrintLine("You're already there");
                    return false;
                }
                CurrentLocation = room;
                return true;
            }
            DialogueHandler.PrintLine("Sorry. That's not a place you can go right now.");
            return false;
        }

        /// <summary>
        /// Changes the current location and didsplays room information
        /// </summary>
        /// <param name="place"></param>
        public bool ChangeRoom(string target)
        {
            if (InCombat)
            {
                if (!UserInput.GetBool("Do you want to flee combat? (Y/N) "))
                {
                    return false;
                }
            }
            if (VerifyRoom(target))
            {
                DialogueHandler.PrintCentered($"{CurrentLocation.Image}");
                DialogueHandler.PrintLine($"You are now in the {CurrentLocation.Name}");
                DialogueHandler.PrintLine($"{CurrentLocation.Description}");
                InCombat = CurrentLocation.RollEncounter(); //Rolls to see if a combat encounter begins
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckCombat() => InCombat;

        public void SearchRoom()
        {
            if (CurrentLocation.Name == "Pantry")
            {
                if (InCombat)
                {
                    DialogueHandler.PrintLine("You've already got trouble. Take it one at a time, cowboy.");
                }
                else
                {
                    InCombat = true;
                    InputHandler.Character.SpawnEnemy(CurrentLocation.Name);
                }
            }
            else
            {
                foreach (string i in CurrentLocation.Interactables)
                {
                    DialogueHandler.PrintLine(i);
                }
                if (CurrentLocation.Interactables.Count < 1)
                {
                    DialogueHandler.PrintLine("There's nothing you can interact with here. Try using you TOOL BELT to see if there is an item you can USE here.");
                }
            }
        }
    }
}
