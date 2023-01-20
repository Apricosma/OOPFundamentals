
class Program
{
    static Dictionary<string, int> initializeCoins()
    {
        // create a dictionary with all the coins as a string, and in integer to keep track of the amount
        Dictionary<string, int> makeCoins = new Dictionary<string, int>();
        makeCoins.Add("1", 17);
        makeCoins.Add("2", 12);
        makeCoins.Add("5", 10);
        makeCoins.Add("10", 8);
        makeCoins.Add("20", 3);

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

    static Dictionary<string, int> outputChangeCoins()
    {
        Dictionary<string, int> Change = new Dictionary<string, int>();
        Change.Add("20", 0);
        Change.Add("10", 0);
        Change.Add("5", 0);
        Change.Add("2", 0);
        Change.Add("1", 0);

        return Change;
    }



    static void Main(string[] args)
    {
        bool mainProgramRunning = true;

        while(mainProgramRunning) {
            Console.WriteLine("1. Vending Machine 2. String Compressor 3. Quit");
            int input = Int32.Parse(Console.ReadLine());
            switch(input)
            {
                case 1:
                    // VENDOR
                    #region
                    Dictionary<string, int> StoredCoins = initializeCoins();
                    Dictionary<string, int> StoredProducts = vendingMachineProducts();

                    Console.WriteLine("Hello, thank you for choosing vending inc.");
                    printProducts(StoredProducts);
                    Console.WriteLine();

                    Console.WriteLine("Please, enter coins . . .");
                    int inputCoins = 0;
                    bool validInteger = false;
                    while(!validInteger)
                    {
                        string userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out inputCoins))
                        {
                            validInteger = true;
                        } else
                        {
                            Console.WriteLine("Please use a whole number");
                        }
                    }

                    // if sum of all values is less than the input money, reject
                    int keyValueSum = 0;
                    foreach (KeyValuePair<string, int> pair in StoredCoins)
                    {
                        int key = int.Parse(pair.Key);
                        keyValueSum += key * pair.Value;
                    }

                    if (keyValueSum < inputCoins)
                    {
                        Console.WriteLine("Sorry, we do not have enough change for this, please input less money");
                        Console.WriteLine($"Returned ${inputCoins}");
                    } else {
                        bool vendorRunning = true;

                        while (vendorRunning)
                        {
                            Console.WriteLine("Enter the name of the product you'd like to purchase: (q to quit)");
                            string productSelection = Console.ReadLine().ToLower();

                            if(productSelection == "q")
                            {
                                Console.WriteLine($"Returned ${inputCoins}");
                                inputCoins = 0;
                                break;
                            }

                            if (StoredProducts.ContainsKey(productSelection))
                            {
                                if (inputCoins >= StoredProducts[productSelection])
                                {
                                    Console.WriteLine($"You recieve 1 {productSelection}");
                                    int changeNeeded = inputCoins - StoredProducts[productSelection];
                                    Dictionary<string, int> Output = outputChangeCoins();

                                    while (changeNeeded > 0)
                                    {
                                        switch (changeNeeded)
                                        {
                                            case int n when (20 <= n && StoredCoins["20"] > 0):
                                                StoredCoins["20"] -= 1;
                                                changeNeeded = changeNeeded - 20;
                                                Output["20"] += 1;
                                                break;
                                            case int n when (10 <= n && StoredCoins["10"] > 0):
                                                StoredCoins["10"] -= 1;
                                                changeNeeded = changeNeeded - 10;
                                                Output["10"] += 1;
                                                break;
                                            case int n when (5 <= n && StoredCoins["5"] > 0):
                                                StoredCoins["5"] -= 1;
                                                changeNeeded = changeNeeded - 5;
                                                Output["5"] += 1;
                                                break;
                                            case int n when (2 <= n && StoredCoins["2"] > 0):
                                                StoredCoins["2"] -= 1;
                                                changeNeeded = changeNeeded - 2;
                                                Output["2"] += 1;
                                                break;
                                            case int n when (1 <= n && StoredCoins["1"] > 0):
                                                StoredCoins["1"] -= 1;
                                                changeNeeded = changeNeeded - 1;
                                                Output["1"] += 1;
                                                break;
                                            default:
                                                Console.WriteLine("No change needed");
                                                break;
                                        }
                                    }

                                    Console.WriteLine("Your change is: ");
                                    foreach (KeyValuePair<string, int> pair in Output)
                                    {
                                        if (pair.Value > 0)
                                        {
                                            Console.WriteLine($"${pair.Key}: {pair.Value}".ToString());
                                        }
                                    }

                                    inputCoins = inputCoins - StoredProducts[productSelection];
                                    Console.WriteLine($"You have: ${inputCoins}");
                                }
                            
                            }
                        }
                    }
                    #endregion
                    break;
                case 2:
                    // string compressor
                    break;
                case 3:
                    // quit
                    break;
            }
        }
    }
}