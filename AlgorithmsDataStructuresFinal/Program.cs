
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


    static void Main(string[] args)
    {
        Dictionary<string, int> StoredCoins = initializeCoins();

        foreach(KeyValuePair<string, int> pair in StoredCoins)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
    }
}