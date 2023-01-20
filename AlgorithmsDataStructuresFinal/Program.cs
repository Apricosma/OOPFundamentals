﻿
class Program
{
    static Dictionary<string, int> initializeCoins()
    {
        // create a dictionary with all the coins as a string, and in integer to keep track of the amount
        Dictionary<string, int> makeCoins = new Dictionary<string, int>();
        makeCoins.Add("$1", 17);
        makeCoins.Add("$2", 12);
        makeCoins.Add("$5", 10);
        makeCoins.Add("$10", 8);
        makeCoins.Add("$20", 3);

        return makeCoins;
    }

    static void printStoredCoins(Dictionary<string, int> coins)
    {
        foreach (KeyValuePair<string, int> pair in coins)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
    }

    static Dictionary<string, int> vendingMachineProducts()
    {
        // product: $price
        Dictionary<string, int> Products = new Dictionary<string, int>();
        Products.Add("skittles", 2);
        Products.Add("jollyrancher", 3);
        Products.Add("mars", 2);
        Products.Add("sodiepop", 4);

        return Products;
    }

    static void printProducts(Dictionary<string, int> products)
    {
        foreach(KeyValuePair<string, int> pair in products)
        {
            Console.WriteLine($"{pair.Key}: ${pair.Value}");
        }
    }


    static void Main(string[] args)
    {
        Dictionary<string, int> StoredCoins = initializeCoins();
        Dictionary<string, int> StoredProducts = vendingMachineProducts();


        Console.WriteLine("Hello, thank you for choosing vending inc.");
        printProducts(StoredProducts);
        Console.WriteLine();

        Console.WriteLine("Please, enter coins . . .");
        int inputCoins = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Enter the name of the product you'd like to purchase:");
        string productSelection = Console.ReadLine().ToLower();

        if (StoredProducts.ContainsKey(productSelection))
        {
            if (inputCoins > StoredProducts[productSelection])
            {
                Console.WriteLine($"You recieve 1 {productSelection}");
                
                // find the change value ...
                // check from biggest to smallest if you can match the change value in the lease amount of coins?
                // if change needed = 0
                    // no change needed to output
                // if change needed = 8
                // does 1 $20 <= 8
                // 1 $10 <= 8?
                // 1 $5 <= 8?
                    // yes, add 1 $5 to change pile, reduce changeNeeded by keyvalue
                    // repeat 5 <= 3?
                // 2 <= 3?
                    //yes, add 1 $2 coin to the output, reduce changeNeeded by keyvalue
                    // 2 <= 1?
                // 1 <= 1?
                    //yes, add 1 $1 coin to output, reduce changeNeeded by keyvalue
                // change needed = 0, so output

                int changeNeeded = inputCoins - StoredProducts[productSelection];
                int changePile = 0;
                Dictionary<string, int> Output = new Dictionary<string, int>();

                while (changeNeeded > 0)
                {
                    if (20 <= changeNeeded)
                    {
                        StoredCoins["$20"] -= 1;
                        changeNeeded = changeNeeded - 20;
                        Output.Add("$20", 1);
                    }

                    if (10 <= changeNeeded)
                    {
                        StoredCoins["$10"] -= 1;
                        changeNeeded = changeNeeded - 10;
                        Output.Add("$10", 1);
                    }

                    if (5 <= changeNeeded)
                    {
                        StoredCoins["$5"] -= 1;
                        changeNeeded = changeNeeded - 5;
                        Output.Add("$5", 1);
                    }

                    if (2 <= changeNeeded)
                    {
                        StoredCoins["$2"] -= 1;
                        changeNeeded = changeNeeded - 2;
                        Output.Add("$2", 1);
                    }

                    if (1 <= changeNeeded)
                    {
                        StoredCoins["$1"] -= 1;
                        changeNeeded = changeNeeded - 1;
                        Output.Add("$1", 1);
                    }
                }

                foreach(KeyValuePair<string, int> pair in Output)
                {
                    Console.WriteLine($"{pair.Key} {pair.Value}");
                }
            }
        }
    }
}