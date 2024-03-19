﻿using System;
using System.Collections.Generic;
using TextAdventureGame.Models;
using TextAdventureGame.Items;

namespace TextAdventureGame.Handlers
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
            string input = Console.ReadLine().ToLower();
            string[] inputSplit = input.Split(" ");
            InputAction action = new InputAction
            {
                Command = inputSplit[0].ToLower(),
            };
            if (inputSplit.Length > 1)
            {
                for (int i = 1; i < 3 && i < inputSplit.Length; i++)
                {
                    action.Target += inputSplit[i].ToLower() + " ";
                }
                action.Target = action.Target.Trim();
            }
            return action;
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
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                DialogueHandler.Print("Invalid input. Please try again");
                Console.WriteLine();
            }
            return false;
        }
    }
}




