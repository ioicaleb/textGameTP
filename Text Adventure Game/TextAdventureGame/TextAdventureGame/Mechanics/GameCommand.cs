﻿using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Mechanics
{
    public class GameCommand
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public Combat Combat { get; set; }
        public string Target { get; set; }
        public Location Map { get; set; }
        public Prompt Prompt { get; set; }
        public bool InCombat { get; set; }
        public int Licks { get; set; } = 0;
        public List<int> Entries { get; }

        public virtual void Execute(int input) 
        {
            switch (input)
            {
                case 1: //Creates classes need to perform methods
                    CreateCommands();
                    break;
                case 2: //Creates a player using user input as a name
                    string name = Prompt.GetName();
                    Player = Player.CreatePlayer(name);
                    break;
                case 3: //Prompts the user for an action, checks the action against a list of possible actions, and then calls the necessary method
                    string thingToDo = Prompt.GetAction(); // Prompts user for action
                    string command = Prompt.StringToInput(thingToDo, 1); //Converts first input into command
                    string target = Prompt.StringToInput(thingToDo, 2); //Checks for second input and converts it to target
                    ActOnInput(command, target); //Calls appropriate method
                    break;
                case 4: //Begins combat encounter
                    Enemy = Enemy.Spawn(); //Creates and names Enemy
                    InCombat = Combat.Encounter(); //Sets InCombat to true
                    break;
                case 5: //Creates a list of room to populate the map
                    Map.MapList = Map.CreateMap();
                    break;
                case 6: //Changes current location
                    Location place = Map.Move(Target); // Converts input to a location value and checks that location is viable
                    if (place == null)
                    {
                        break;
                    }
                    bool encounter = Map.RollEncounter(place); //Rolls to see if a combat encounter begins
                    if (encounter)
                    {
                        Execute(4);
                    }
                    break;
                case 7:
                    int damage = Combat.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                    damage += Player.DamageMod;
                    Console.WriteLine($"You managed to get in {damage} licks!");
                    Enemy.Health = Enemy.DamageEnemy(damage); //Reduces enemy health
                    Player.SugarLevel = Player.GainSugar(); //Increments sugar level after every attack
                    if (Enemy.Health < 1 || Player.SugarLevel > 99) //Checks if enemy is dead or player crashes
                    {
                        InCombat = false;
                        Console.WriteLine(Player.EatCandy()); //Writes end of battle text including sugar level and experience
                    }
                    else 
                    {
                        Execute(3);
                    }
                    break;
                //case 8:
                    //break;
                default: //If the input is null or not yet implemented, sends the user back through the prompt
                    Execute(3);
                    break;
            }
            
        }

        public void CreateCommands()
        {
            Player = new Player();
            Prompt = new Prompt();
            Enemy = new Enemy();
            Map = new Location();
            Combat = new Combat();
        }

        public void ActOnInput(string command, string target)
        {
            
            switch (command)
            {
                case "move": //checks input for location input
                    bool run = false;
                    if (InCombat)
                    {
                        Console.Write("Do you want to run away? (Y/N): ");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "y" || input.ToLower() == "yes")
                        {
                            run = true;
                        }
                    }
                    if (!run)
                    {
                        string location;
                        switch (target)
                        {
                            case "":
                                location = Prompt.GetLocation();
                                break;
                            case null:
                                location = Prompt.GetLocation();
                                break;
                            default:
                                location = target;
                                break;
                        };
                        Target = location;
                        Execute(6); //Executes movement commands
                    }
                    else 
                    {
                        InCombat = false;
                    }
                    break;

                case "lick": //Writes a lone of not in combat or starts damage process
                    if (InCombat)
                    {
                        Licks = Licks++;
                        Execute(7);
                        break;
                    }
                    Console.WriteLine("Save your licks for the candies.");
                    Console.WriteLine();
                    break;

                case "help": //Needs implementing
                    break;

                case "rooms": //Displays list of rooms
                    Map.CheckMap();
                    Console.WriteLine();
                    break;

                default: //Handles unrecognized inputs
                    Console.WriteLine("Sorry. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
