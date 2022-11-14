using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali_s_Supermarket
{
    internal class SupermarketItem
    {
        public SupermarketItem(string name, UnitType unitType, double unitPrice)
        {
            Name = name;
            UnitType = unitType;
            UnitPrice = unitPrice;
        }

        public string Name { get; set; }
        public UnitType UnitType { get; set; }
        public double UnitPrice { get; set; }
    }
}
