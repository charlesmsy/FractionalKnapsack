using System;
using System.Collections.Generic;
using System.Text;

namespace FractionalKnapsack
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Value { get; set; }
        public decimal Valuable { get => Value / Weight; }
    }
}
