
using System.Text.RegularExpressions;

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

    static bool isStringValid(string input)
    {
        if (!string.IsNullOrEmpty(input) && !Regex.IsMatch(input, @"^[A-Z]+$"))
        {
            return true;
        }
        return false;
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
                    // Complexity should be O(n), even the most intensive algorithm which is the change algorithm
                    // doesn't compare everything to each other. It just iterates down the list repeatedly
                    // until it runs out of stuff or reaches the result
                    #region
                    Dictionary<string, int> StoredCoins = initializeCoins();
                    Dictionary<string, int> StoredProducts = vendingMachineProducts();

                    Console.WriteLine("Hello, thank you for choosing vending inc.");
                    printProducts(StoredProducts);
                    Console.WriteLine();

                    // coin input
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

                        // main vendor loop
                        while (vendorRunning)
                        {
                            Console.WriteLine("Enter the name of the product you'd like to purchase: (q to quit)");
                            string productSelection = Console.ReadLine().ToLower();

                            // quit
                            if(productSelection == "q")
                            {
                                Console.WriteLine($"Returned ${inputCoins}");
                                inputCoins = 0;
                                break;
                            }

                            // change logic
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
                                } else
                                {
                                    Console.WriteLine("You do not have enough coins to purchase this item");
                                }
                            
                            }
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region
                    // string compressor
                    // O(n) time complexity
                    // I only check each index once

                    Console.WriteLine("Please enter a string of letters, ignoring spaces");
                    string originalString = Console.ReadLine()
                        .ToUpper()
                        .Trim()
                        .Replace(" ", "");

                    while (isStringValid(originalString))
                    {
                        Console.WriteLine("Invalid input, please input a string");
                        originalString = Console.ReadLine();
                    }

                    
                    int count = 0;

                    string result = "";
                    // use a count to count repeats

                    for (int i = 0; i < originalString.Length; i++)
                    {
                        count++;
                        // if index is different from the next index then append
                        // how to make it show nn instead of n2...? 
                        if (i + 1 >= originalString.Length || originalString[i] != originalString[i + 1])
                        {
                            result += originalString[i];
                            if (count > 1) 
                            {
                                result += count;
                            }
                            // reset the duplicate counter
                            count = 0;
                        }
                    }

                    Console.WriteLine(result);

                    // decompress
                    // I think this is O(n) even though there is a nested for, because the amount of sub-iterations
                    // is only equal to the integer it finds
                    Console.WriteLine("Enter a string to decompress (eg. a5b3c4)");
                    string decompInput = Console.ReadLine().Trim();
                    char[] characters = new char[decompInput.Length];
                    characters = decompInput.ToCharArray();
                    string decompressResult = "";

                    // doesn't yet work for compression values over 9
                    // since it only looks at 1 number at a time, I'm unsure how to do this
                    // maybe.. if ascii = number, peek the next char, and if the next char is also an ascii number, then add them together into an iterator
                    // and run the for j loop by the iterator amount, rather than directly from the digit found?
                    for (int i = 0; i < characters.Length; i++)
                    {
                        // if the index char has ascii value of chars 1 - 9
                        if (characters[i] >= 49 && characters[i]<= 57)
                        {
                            // .. convert to an int and iterate n amount of times where n = int found
                            for (int j = 0; j < Int32.Parse(characters[i].ToString()) - 1; j++)
                            {
                                decompressResult += characters[i - 1].ToString();
                            }
                            
                        } else
                        {
                            decompressResult += characters[i];
                        }
                    }

                    Console.WriteLine(decompressResult);
                    #endregion
                    break;
                case 3:
                    // quit
                    mainProgramRunning = false;
                    break;
            }
        }
    }
}