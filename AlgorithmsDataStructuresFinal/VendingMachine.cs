using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructuresFinal
{
    internal class VendingMachine
    {
        private int _serialNumber;
        public int SerialNumber { get { return _serialNumber; } }

        private Dictionary<int, int> _moneyFloat;
        public Dictionary<int, int> MoneyFloat { 
            get { return _moneyFloat; }
            set { _moneyFloat = value; }
        }

        private Dictionary<Product, int> _inventory;
        public Dictionary<Product, int> Inventory {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public VendingMachine(int serialNumber, Dictionary<int, int> moneyFloat, Dictionary<Product, int> inventory)
        {
            _serialNumber = serialNumber;
            _moneyFloat = moneyFloat;
            _inventory = inventory;
        }

        public void StockItem(Product product, int quantity)
        {
            if (Inventory.ContainsKey(product))
            {
                Inventory[product] += quantity;
            }
            else
            {
                Inventory.Add(product, quantity);
            }

            Console.WriteLine($"{product.Name}, {product.Code}, ${product.Price} stocked. Current qty: {Inventory[product]}");
        }

        public void StockFloat(int moneyDenomination, int quantity)
        {
            if (MoneyFloat.ContainsKey(moneyDenomination))
            {
                MoneyFloat[moneyDenomination] += quantity;
                Console.WriteLine($"{quantity} ${moneyDenomination} coin added to the machine's float");
                
                foreach(KeyValuePair<int, int> coin in MoneyFloat)
                {
                    Console.WriteLine($"${coin.Key} qty: {coin.Value}");
                }
            }
            else 
            {
                Console.WriteLine($"{moneyDenomination} is not a proper coin, please enter 20, 10, 5, 2, or 1");
            }
        }

        public void VendItem(string code, int money) 
        {
            int change = 0;
            Product product = null;

            foreach (KeyValuePair<Product, int> item in Inventory)
            {
                if (item.Key.Code == code)
                {
                    product = item.Key;
                    change = money - item.Key.Price;
                    break;
                }
            }

            if (product != null && money >= product.Price) 
            {
                foreach(KeyValuePair<int, int> pair in MoneyFloat)
                {
                    while(pair.Key <= change && MoneyFloat[pair.Key] > 0 && change > 0)
                    {
                        change -= pair.Key;
                        Console.WriteLine($"Returning {pair.Key}");

                        MoneyFloat[pair.Key]--;
                        
                    }
                }
            }
        }
    }
}
