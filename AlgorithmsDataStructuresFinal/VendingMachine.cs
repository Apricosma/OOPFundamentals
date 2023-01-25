﻿using System;
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
                //return $"{product.Name}, Code: {product.Code}, ${product.Price} added to stock. Current qty: {Inventory[product]}";
            }
            else
            {
                Inventory.Add(product, quantity);
            }

            Console.WriteLine($"{product.Name}, {product.Code}, ${product.Price} stocked. Current qty: {Inventory[product]}");
        }
    }
}
