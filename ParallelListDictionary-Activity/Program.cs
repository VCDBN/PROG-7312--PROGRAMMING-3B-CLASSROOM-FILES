using System;
using System.Collections.Generic;

class Program
{
    static void AddToInventory(List<string> itemNames, Dictionary<string, int> itemIDs, Dictionary<string,
        int> itemQuantities, string itemName, int itemID, int quantity)
    {
        itemNames.Add(itemName);
        itemIDs[itemName] = itemID;
        itemQuantities[itemName] = quantity;
    }
    static void Main()
    {
        // Create parallel lists and dictionaries for inventory management
        List<string> itemNames = new List<string>();
        Dictionary<string, int> itemIDs = new Dictionary<string, int>();
        Dictionary<string, int> itemQuantities = new Dictionary<string, int>();

        // Inventory items
        AddToInventory(itemNames, itemIDs, itemQuantities, "Cellphone", 101, 20);
        AddToInventory(itemNames, itemIDs, itemQuantities, "Headphones", 102, 50);
        AddToInventory(itemNames, itemIDs, itemQuantities, "C type Cable", 103, 100);
        AddToInventory(itemNames, itemIDs, itemQuantities, "Jbl Speaker", 104, 20);
        AddToInventory(itemNames, itemIDs, itemQuantities, "Pioneer Amplifier", 105, 10);



        while (true)//Menu options
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Find item name by ID");
            Console.WriteLine("2. Look up the quantity of a specific item");
            Console.WriteLine("3. Add or remove items from the inventory");
            Console.WriteLine("4. Quit");

            Console.Write("Enter your choice (1/2/3/4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FindItemNameByID(itemIDs);
                    break;

                case "2":
                    LookupItemQuantity(itemNames, itemQuantities);
                    break;

                case "3":
                    ManageInventory(itemNames, itemQuantities);
                    break;

                case "4":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

   

    static void FindItemNameByID(Dictionary<string, int> itemIDs)
    {
        Console.Write("Enter the item ID to find its name: ");
        if (int.TryParse(Console.ReadLine(), out int inputID))
        {
            foreach (var kvp in itemIDs)
            {
                if (kvp.Value == inputID)
                {
                    Console.WriteLine($"Item name for ID {inputID}: {kvp.Key}");
                    return;
                }
            }
            Console.WriteLine($"Item with ID {inputID} not found.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer ID.");
        }
    }

    static void LookupItemQuantity(List<string> itemNames, Dictionary<string, int> itemQuantities)
    {
        Console.Write("Enter the item name to look up its quantity: ");
        string itemName = Console.ReadLine();

        if (itemQuantities.ContainsKey(itemName))
        {
            int quantity = itemQuantities[itemName];
            Console.WriteLine($"Quantity of {itemName}: {quantity}");
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' not found in inventory.");
        }
    }

    static void ManageInventory(List<string> itemNames, Dictionary<string, int> itemQuantities)
    {
        Console.WriteLine("Options:");
        Console.WriteLine("1. Add items to inventory");
        Console.WriteLine("2. Remove items from inventory");
        Console.Write("Enter your choice (1/2): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddItemsToInventory(itemNames, itemQuantities);
                break;

            case "2":
                RemoveItemsFromInventory(itemNames, itemQuantities);
                break;

            default:
                Console.WriteLine("Invalid choice. Please enter 1 to add items or 2 to remove items.");
                break;
        }
    }

    static void AddItemsToInventory(List<string> itemNames, Dictionary<string, int> itemQuantities)
    {
        Console.Write("Enter the item name to add: ");
        string itemName = Console.ReadLine();

        if (!itemQuantities.ContainsKey(itemName))
        {
            Console.Write("Enter the quantity to add: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                itemNames.Add(itemName);
                itemQuantities[itemName] = quantity;
                Console.WriteLine($"{quantity} {itemName}(s) added to inventory.");
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a valid positive integer.");
            }
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' already exists in inventory.");
        }
    }

    static void RemoveItemsFromInventory(List<string> itemNames, Dictionary<string, int> itemQuantities)
    {
        Console.Write("Enter the item name to remove: ");
        string itemName = Console.ReadLine();

        if (itemQuantities.ContainsKey(itemName))
        {
            Console.Write("Enter the quantity to remove: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                if (itemQuantities[itemName] >= quantity)
                {
                    itemQuantities[itemName] -= quantity;
                    Console.WriteLine($"{quantity} {itemName}(s) removed from inventory.");
                    if (itemQuantities[itemName] == 0)
                    {
                        itemQuantities.Remove(itemName);
                        itemNames.Remove(itemName);
                        Console.WriteLine($"No more {itemName} in inventory. Removed from the inventory list.");
                    }
                }
                else
                {
                    Console.WriteLine($"Insufficient quantity of {itemName} in inventory.");
                }
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a valid positive integer.");
            }
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' not found in inventory.");
        }
    }
}
