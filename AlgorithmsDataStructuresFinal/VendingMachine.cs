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
                Console.WriteLine($"{quantity} ${moneyDenomination} added to the machine's float");
            }
            else 
            {
                Console.WriteLine($"{moneyDenomination} is not a proper coin, please enter 20, 10, 5, 2, or 1");
            }
        }
    }
}
