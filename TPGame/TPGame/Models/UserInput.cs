using System;
using TPGame.Handlers;

namespace TPGame.Models
{
    public static class UserInput
    {
        /// <summary>
        /// Prints message and prompts user for string input
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetString(string message)
        {
            DialogueHandler.Print(message + " ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Prompts the user for action, breaks down space seperated input
        /// First word = Command
        /// Second word = Target
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InputAction GetAction()
        {

            DialogueHandler.Print("What do you do?: ");
            string input = Console.ReadLine().ToLower().Trim();
            string[] inputSplit = input.Split(" ");
            return new InputAction(inputSplit);
        }

        public static InputAction GetAction(string message)
        {

            DialogueHandler.Print(message);
            string input = Console.ReadLine().ToLower().Trim();
            string[] inputSplit = input.Split(" ");
            return new InputAction(inputSplit);
        }

        /// <summary>
        /// Displays message and prompts user for yes or no repsonse
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool GetBool(string message)
        {
            bool validInput = false;
            while (!validInput)
            {
                DialogueHandler.Print(message);
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                DialogueHandler.PrintLine("Invalid input. Please try again");
            }
            return false;
        }
    }
}




