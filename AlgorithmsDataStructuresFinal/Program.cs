
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

            var products = new Dictionary<Product, int>()
            {
                { new Product("Mars", 4, "A1"), 4 },
                { new Product("Coke", 5, "A2"), 3 }
            };

            
            VendingMachine vendor = new VendingMachine(1234, initialMoneyFloat, products);
            
            foreach(var product in products)
            {
                Console.WriteLine($"{product.Key.Name}: {product.Value}");
            }
        }
    }
}
