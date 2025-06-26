using System.Collections.Generic;
using TPGame.Commands;
using TPGame.Models;
using TPGame.Dictionaries;

namespace TPGame.Handlers
{
    public static class InputHandler
    {
        public readonly static RoomCommand Map = new();
        public readonly static CharacterCommand Character = new();

        /// <summary>
        /// Checks action and redirects to appropriate command
        /// </summary>
        /// <param name="action">command and target to be redirected</param>
        public static void HandleAction(InputAction action)
        {
            switch (action.Command)
            {
                case "lick":
                    Map.InCombat = Character.AttackEnemy(Map.InCombat);
                    break;
                case "move":
                    if (Map.ChangeRoom(action.Target) && Map.InCombat && !Map.CurrentLocation.BossDefeated)
                    {
                        Character.SpawnEnemy(Map.CurrentLocation.Name);
                    }
                    break;
                case "map":
                    Collections.ListRooms();
                    break;
                case "check":
                    StuffCommand.CheckItem(action.Target);
                    break;
                case "open":
                case "use":
                    StuffCommand.UseItem(action.Target, Map.CurrentLocation);
                    break;
                case "take":
                case "grab":
                case "get":
                    StuffCommand.GetItem(action.Target, Map.CurrentLocation);
                    break;
                case "help":
                    Collections.ListInputs();
                    break;
                case "hint":
                    Hints.DisplayHints();
                    break;
                case "quit":
                    CommandHandler.QuitGame();
                    break;
                case "search":
                    if (action.Target == "" || Collections.VerifyRoom(char.ToUpper(action.Target[0]) + action.Target.Substring(1)) != null)
                    {
                        Map.SearchRoom();
                    }
                    else
                    {
                        DialogueHandler.RespondWithJokes(action.Target);
                    }
                    break;
                case "sugar":
                    DialogueHandler.PrintLine($"Your sugar level is currently {Character.Player.GetSugar()}%");
                    break;
#if DEBUG
                case "gimmee":
                    Cheat.PlayGameForMe();
                    break;
#endif
                default: //Handles unrecognized inputs
                    DialogueHandler.PrintLine("Sorry. I didn't catch that. Please try again.");
                    break;
            }
        }

        public static void EnterRoom(string roomName)
        {
            DialogueHandler.PrintCentered(Map.CurrentLocation.Image);
            DialogueHandler.PrintLine(Map.CurrentLocation.Description);
            Character.SpawnEnemy(roomName);
            Map.InCombat = true;
        }

        public static string GetCurrentLocation() => Map.CurrentLocation.Name;
    }
}
