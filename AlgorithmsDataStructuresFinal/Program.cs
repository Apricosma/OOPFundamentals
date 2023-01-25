
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

            // initial stock
            Product mars = new Product("Mars", 4, "A1");
            Product coke = new Product("Coke", 5, "A2");
            Product skittles = new Product("Skittles", 3, "A3");
            // product, quant
            Dictionary<Product, int> products = new Dictionary<Product, int>()
            {
                { mars, 4 },
                { coke, 3 },
                { skittles, 2 },
            };

            VendingMachine vendor = new VendingMachine(7634, initialMoneyFloat, products);

            Console.WriteLine($"Starting vendor.. Serial No. {vendor.SerialNumber}");
            Console.WriteLine("-----------------------------------------------");

            bool programRunning = true;
            while (programRunning)
            {
                int inputMoney = 0;
                bool validMoneyInput = false;

                while (!validMoneyInput)
                {
                    Console.WriteLine("Please input money: ");
                    try
                    {
                        inputMoney = Int32.Parse(Console.ReadLine());
                        validMoneyInput = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Please input a whole number");
                    }
                }

                int keyValueSum = 0;
                foreach (KeyValuePair<int, int> pair in vendor.MoneyFloat)
                {
                    int key = pair.Key;
                    keyValueSum += key * pair.Value;
                }

                if (keyValueSum < inputMoney)
                {
                    Console.WriteLine("Sorry, we don't have enough change available to perform this transaction");
                    Console.WriteLine($"Returned ${inputMoney}");
                    inputMoney = 0;
                } else
                {
                    Console.WriteLine("Please choose a yummy snack with its corresponding key (eg. A2) or 'Q' to quit");
                    foreach (var product in vendor.Inventory)
                    {
                        Console.WriteLine($"{product.Key.Code} | {product.Key.Name}: ${product.Key.Price} (Qty: {product.Value})");
                    }

                    string productCode = "";
                    while (true)
                    {
                        try
                        {
                            productCode = Console.ReadLine().ToUpper();
                            if (productCode == "Q")
                            {
                                Console.WriteLine($"Returned ${inputMoney}");
                                Environment.Exit(0);
                            }

                            if (productCode.Length != 2)
                            {
                                throw new Exception("Invalid, please input the code of the product (eg. A2, B1)");
                            }

                            char firstCharacter = productCode[0];
                            if (!Char.IsLetter(firstCharacter))
                            {
                                throw new Exception("Invalid format, the first character should be a letter");
                            }
                            if (!Char.IsDigit(productCode[1]))
                            {
                                throw new Exception("Invalid format, the second character should be a number");
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    foreach (KeyValuePair<Product, int> product in vendor.Inventory)
                    {
                        if (product.Key.Code == productCode)
                        {
                            vendor.VendItem(productCode, inputMoney);
                        }
                    }
                }

                
            }

            
        }
    }
}
