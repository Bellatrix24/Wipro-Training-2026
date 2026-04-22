using System;

// This script demonstrates the difference between Properties and Indexers using an E-commerce scenario.

// Product Class represents the attributes of a single item
class Product
{
    private string name;
    private double price;
    private int quantity;

    // Property for Name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property for Price with validation logic
    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine("Error: Price cannot be negative!");
        }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Product(string name, double price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }
}

// Inventory Class uses an Indexer to manage a collection of Products
class Inventory
{
    private Product[] products = new Product[10];

    // Indexer: Allows accessing the inventory like an array (inventory[0])
    public Product this[int index]
    {
        get
        {
            if (index >= 0 && index < products.Length)
                return products[index];
            else
                return null;
        }
        set
        {
            if (index >= 0 && index < products.Length)
                products[index] = value;
        }
    }
}

class IndexingAndProperties
{
    static void Main()
    {
        Inventory myStore = new Inventory();

        // Adding products using the indexer
        myStore[0] = new Product("Laptop", 45000, 5);
        myStore[1] = new Product("Mouse", 500, 10);
        myStore[2] = new Product("Keyboard", -1200, 2); // This will trigger the validation error

        // Accessing products using the indexer
        Console.WriteLine("\n--- Inventory List ---");
        for (int i = 0; i < 3; i++)
        {
            if (myStore[i] != null)
            {
                Console.WriteLine($"Product: {myStore[i].Name} | Price: {myStore[i].Price} | Stock: {myStore[i].Quantity}");
            }
        }
    }
}
