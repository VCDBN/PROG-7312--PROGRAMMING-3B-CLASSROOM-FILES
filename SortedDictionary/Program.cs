using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a sorted dictionary with integer keys and string values.
        SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();

        // Add key-value pairs to the sorted dictionary.
        sortedDictionary.Add(3, "Three");
        sortedDictionary.Add(1, "One");
        sortedDictionary.Add(2, "Two");

        // Iterate through the sorted dictionary and print its contents in sorted order.
        foreach (var kvp in sortedDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        // Access a value by key.
       string valueForKey2 = sortedDictionary[2];
        Console.WriteLine($"Value for Key 2: {valueForKey2}");

        // Check if a key exists in the sorted dictionary.
       bool containsKey = sortedDictionary.ContainsKey(3);
       Console.WriteLine($"Contains Key 3: {containsKey}");

        // Remove a key-value pair from the sorted dictionary.
       sortedDictionary.Remove(1);
        Console.WriteLine("After removing Key 1:");

        // Iterate through the sorted dictionary again.
        foreach (var kvp in sortedDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
       }
    }
}
