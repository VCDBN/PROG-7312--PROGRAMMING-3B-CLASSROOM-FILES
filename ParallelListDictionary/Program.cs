using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    static void AddToParallelList(List<string> keys, Dictionary<string, int> values, string key, int value)
    {
        keys.Add(key);
        values[key] = value;
    }

    static void Main()
    {
        // Create a parallel list using a List and a Dictionary
        List<string> keys = new List<string>();

        Dictionary<string, int> values = new Dictionary<string, int>();


        // Add elements to the parallel list- this ensures the key and values stay in sync.
        AddToParallelList(keys, values, "Key1", 10);
        AddToParallelList(keys, values, "Key2", 20);
        AddToParallelList(keys, values, "Key3", 30);

        // Access elements by key
        string keyToLookup = "Key2";
        if (values.ContainsKey(keyToLookup))
        {
            int value = values[keyToLookup];
            Console.WriteLine($"Value for key '{keyToLookup}': {value}");
        }

        // Access elements by value
        int valueToLookup = 20;
        if (keys.Any(k => values.ContainsKey(k) && values[k] == valueToLookup))
        {
            string key = keys.First(k => values.ContainsKey(k) && values[k] == valueToLookup);
            Console.WriteLine($"Key for value '{valueToLookup}': {key}");
        }
    }

  
}
