using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace LagerSystem
{
    class Item
    {
        List<string> SerialNumbers=new List<string>() { "4100", "4101", "4102", "4103", "4104", "4105" };
        List<string> Product = new List<string>() { "Gloves", "Trousers", "Jeans", "T-shirts", "Overalls", "Turtle neck" };
        List<string> Amount = new List<string>() { "10", "25", "50", "100", "250", "500" };

        public List<string> GetSerial()
        {
            return SerialNumbers;
        }
        public List<string> GetProduct()
        {
            return Product;
        }
        public List<string> GetAmount()
        {
            return Amount;
        }

    }
}
