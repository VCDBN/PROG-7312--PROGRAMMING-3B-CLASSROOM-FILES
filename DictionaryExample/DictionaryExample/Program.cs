using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Declare and initialize a dictionary with string keys and int values.
        Dictionary<string, int> ageDictionary = new Dictionary<string, int>();

        // Add key-value pairs to the dictionary.
        //Dictionary<TKey, TValue>
        ageDictionary["Alice"] = 30;
        ageDictionary["Bob"] = 25;
        ageDictionary["Charlie"] = 35;

        // Retrieve values by key.
        int aliceAge = ageDictionary["Alice"];
        int bobAge = ageDictionary["Bob"];

        Console.WriteLine("Alice's age is " + aliceAge);
        Console.WriteLine("Bob's age is " + bobAge);

        // Check if a key exists in the dictionary.
        //Think about search operations here...
        if (ageDictionary.ContainsKey("Denzyl"))
        {
            int davidAge = ageDictionary["Denzyl"];
            Console.WriteLine("Denzyl's age is " + davidAge);
        }
        else
        {
            Console.WriteLine("Denzyl's age is not in the dictionary.");
        }
    }
}
