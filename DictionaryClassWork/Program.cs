using System;
using System.Collections.Generic;
class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
class Program
{
    static void Main()
    {
        // Create a dictionary to store product information.
        Dictionary<int, Product> productInventory = new Dictionary<int, Product>();

        // Add products to the inventory.
        productInventory.Add(101, new Product { ProductId = 101, Name = "Laptop", Price = 899.99 });
        productInventory.Add(102, new Product { ProductId = 102, Name = "Smartphone", Price = 599.99 });
        productInventory.Add(103, new Product { ProductId = 103, Name = "Tablet", Price = 349.99 });

        // Access and display product information.
        Console.WriteLine("Product Information:");
        foreach (var key in productInventory.Keys)
        {
            Product product = productInventory[key];
            Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: ${product.Price}");
        }

        // Change the price of a product.
        if (productInventory.ContainsKey(102))
        {
            productInventory[102].Price = 649.99;
            Console.WriteLine("\nPrice of Smartphone updated.");
        }

        // Remove a product from the inventory.
        if (productInventory.ContainsKey(101))
        {
            productInventory.Remove(101);
            Console.WriteLine("\nLaptop removed from inventory.");
        }

        // Display updated product information.
        Console.WriteLine("\nUpdated Product Information:");
        foreach (var key in productInventory.Keys)
        {
            Product product = productInventory[key];
            Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: ${product.Price}");
        }



    }
}


