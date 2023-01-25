
using System.Text.RegularExpressions;

namespace AlgorithmsDataStructuresFinal
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<int, int> initialMoneyFloat = new Dictionary<int, int>()
            {
                { 20, 3 },
                { 10, 5 },
                { 5, 7 },
                { 2, 6 },
                { 1, 9 }
            };

            Product mars = new Product("Mars", 4, "A1");
            Product coke = new Product("Coke", 5, "A2");
            var products = new Dictionary<Product, int>()
            {
                { mars, 4 },
                { coke, 3 }
            };

            
            VendingMachine vendor = new VendingMachine(1234, initialMoneyFloat, products);

            vendor.StockItem(mars, 1);
            vendor.StockItem(coke, 1);

            foreach (var product in vendor.Inventory)
            {
                Console.WriteLine($"{product.Key.Name}: {product.Value}");
            }
        }
    }
}
