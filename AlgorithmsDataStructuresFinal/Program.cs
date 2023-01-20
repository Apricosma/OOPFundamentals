
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

    static Dictionary<string, double> vendingMachineProducts()
    {
        // product: $price
        Dictionary<string, double> Products = new Dictionary<string, double>();
        Products.Add("Skittles", 2);
        Products.Add("Jollyrancher", 3);
        Products.Add("Mars", 2);
        Products.Add("Sodiepop", 4);

        return Products;
    }


    static void Main(string[] args)
    {
        Dictionary<string, int> StoredCoins = initializeCoins();
        Dictionary<string, double> StoredProducts = vendingMachineProducts();

        

        foreach(KeyValuePair<string, int> pair in StoredCoins)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
    }
}