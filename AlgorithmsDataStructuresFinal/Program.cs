
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
            if (inputCoins > StoredCoins[productSelection])
            {
                Console.WriteLine($"You recieve 1 {productSelection}");
                
            }
        }
    }
}