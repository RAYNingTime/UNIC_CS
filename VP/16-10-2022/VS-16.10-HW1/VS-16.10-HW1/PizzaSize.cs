using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_16._10_HW1
{
    internal class PizzaSize
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public PizzaSize(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
