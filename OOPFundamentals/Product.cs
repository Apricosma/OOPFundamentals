using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructuresFinal
{
    internal class Product
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _price;
        public int Price { get { return _price; } }

        private string _code;
        public string Code { get { return _code; } }

        public Product(string name, int price, string code)
        {
            _name = name;
            _price = price;
            _code = code;
        }
    }
}