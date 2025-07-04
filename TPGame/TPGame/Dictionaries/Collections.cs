﻿using System.Collections.Generic;
using TPGame.Interactables;
using TPGame.Items;
using TPGame.Rooms;
using TPGame.Models;
using System;
using TPGame.Handlers;

namespace TPGame.Dictionaries
{
    public static class Collections
    {
        public static List<Room> Rooms =
            [
                new Attic(),
                new Backyard(),
                new Basement(),
                new Bathroom(),
                new DiningRoom(),
                new Garage(),
                new GuestBedroom(),
                new Kitchen(),
                new LivingRoom(),
                new MasterBedroom(),
                new Office(),
                new Pantry()
            ];

        public static List<Item> Inventory = [];

        public static Item[] AllItems =
            [
                new Batteries(),
                new CampingLantern(),
                new Dentures(),
                new Guard(),
                new HintList(),
                new Key(),
                new Knife(),
                new Ladder(),
                new MetalDetector(),
                new Mints(),
                new Shovel(),
                new ToolBelt(),
                new WaterBottle()
            ];

        public static Interactable[] AllInteractables =
        [
            new Bathtub(),
            new Bed("Master Bedroom"),
            new Bed("Guest Bedroom"),
            new BuriedSwitch(),
            new EndGame(),
            new Cabinet(),
            new Candles(),
            new Chair(),
            new Car(),
            new Chest(),
            new Closet(),
            new Computer(),
            new Couch(),
            new CraftBench(),
            new Desk(),
            new Dresser(),
            new Fridge(),
            new Furnace(),
            new HomeGym(),
            new LawnMower(),
            new LightSwitch(),
            new MedicineCabinet(),
            new MilkCrates(),
            new Nightstand(),
            new Sander(),
            new Sink("Kitchen"),
            new Sink("Bathroom"),
            new Table(),
            new Toilet(),
            new Towel(),
            new WaterBowl(),
            new WaterMain()
         ];

        public readonly static Dictionary<string, string> ValidInputs = new()
        {
            ["Move"] = "(Room) All done in this room? Move on to the next room, but watch out for potential tootsie pops.",
            ["Lick"] = "The only way to get to the center is to erode the candy coating. Get licking!",
            ["Sugar"] = "Strategy, eh? Well if you're worried about taking that next lick, confirm your sugar level before going for it.",
            ["Map"] = "This house is so big that it's easy to get lost in. Pull out the map to see where to go next.",
            ["Search"] = "You may have missed something you can interact with. Take another look around.",
            ["Check"] = "(Item) You remember that thing you picked up earlier? It might be useful. Check it out just to be sure.",
            ["Use"] = "(Item) Those items in your pack aren't just there to look pretty. Put them to good use",
            ["Get"] = "(Item) Your supplies have been scattered. You must recover them. If you come across one, use this to add it to your tool belt.",
            ["Hint"] = "In the stress and surprise, you may have forgotten your master plan. That's fine. You can scan your mind for bits of the plan.",
            ["Help"] = "It helps to take time to reflect on your options. Help yourself out by stopping for a breather.",
#if DEBUG
            ["Gimme"] = "Shhhh... Debugging is long and hard. Just do it for me.",
#endif
            ["Quit"] = "There are no saves, but you can quit out whenever you feel like it."
        };

        public static Item VerifyItem(string itemName) => Array.Find(Collections.AllItems, i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        public static Item CheckInventory(string itemName)
        {
            Item item = VerifyItem(itemName);
            if (Inventory.Contains(item))
            {
                return item;
            }
            return null;
        }

        public static Interactable VerifyInteractable(string interactableName) => Array.Find(Collections.AllInteractables, i => i.Name.Equals(interactableName, StringComparison.OrdinalIgnoreCase));

        public static Room VerifyRoom(string roomName) => Collections.Rooms.Find(r => r.Name.Equals(roomName, StringComparison.OrdinalIgnoreCase));

        public static bool VerifyInventory(string itemName) => CheckInventory(itemName) != null;

        public static void HideUsedItem(string itemName) => CheckInventory(itemName).Hide = true;

        public static void AddInventory(Item item) => Inventory.Add(item);

        public static void AddHiddenRoom() => Rooms.Add(new HiddenRoom());

        public static void ListInputs()
        {
            foreach (KeyValuePair<string, string> i in ValidInputs)
            {
                DialogueHandler.PrintLine($"{i.Key} - {i.Value}");
            }
        }

        public static void ListRooms()
        {
            foreach (Room room in Rooms)
            {
                string roomName = room.Name;
                switch (roomName)
                {
                    case "Garage":
                        if (((Garage)room).Locked)
                        {
                            roomName += " (Locked)";
                        }
                        break;
                    case "Attic":
                        if (((Attic)room).Locked)
                        {
                            roomName += " (Locked)";
                        }
                        break;
                    case "Basement":
                        if (((Basement)room).IsDark)
                        {
                            roomName += " (Dark)";
                        }
                        break;
                    default:
                        break;
                }
                if (room.Name == InputHandler.Map.CurrentLocation.Name)
                {
                    roomName += " - Current Location";
                }
                DialogueHandler.PrintLine($"{roomName}");
            }
        }

        public static void ListInventory()
        {
            if (Inventory.Count > 1)
            {
                foreach (Item i in Inventory)
                {
                    if (!i.Hide && i.Name != "tool belt")
                    {
                        DialogueHandler.PrintLine($"-{char.ToUpper(i.Name[0])}{i.Name.Substring(1)}");
                    }
                }
            }
            else
            {
                DialogueHandler.PrintLine("");
            }
        }

        public static void ResetAll()
        {
            Inventory = [];
            Rooms =
            [
                new Attic(),
                new Backyard(),
                new Basement(),
                new Bathroom(),
                new DiningRoom(),
                new Garage(),
                new GuestBedroom(),
                new Kitchen(),
                new LivingRoom(),
                new MasterBedroom(),
                new Office(),
                new Pantry()
            ];
            AllItems =
            [
                new Batteries(),
                new CampingLantern(),
                new Dentures(),
                new Guard(),
                new HintList(),
                new Key(),
                new Knife(),
                new Ladder(),
                new MetalDetector(),
                new Mints(),
                new Shovel(),
                new ToolBelt(),
                new WaterBottle()
            ];
            AllInteractables =
            [
                new Bathtub(),
                new Bed("Master Bedroom"),
                new Bed("Guest Bedroom"),
                new BuriedSwitch(),
                new EndGame(),
                new Cabinet(),
                new Candles(),
                new Chair(),
                new Car(),
                new Chest(),
                new Closet(),
                new Computer(),
                new Couch(),
                new CraftBench(),
                new Desk(),
                new Dresser(),
                new Fridge(),
                new Furnace(),
                new HomeGym(),
                new LawnMower(),
                new LightSwitch(),
                new MedicineCabinet(),
                new MilkCrates(),
                new Nightstand(),
                new Sander(),
                new Sink("Kitchen"),
                new Sink("Bathroom"),
                new Table(),
                new Toilet(),
                new Towel(),
                new WaterBowl(),
                new WaterMain()
            ];
        }
    }
}
