using System;
using System.Collections.Generic;
using System.Linq;

namespace FractionalKnapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>();

            items.Add(new Item
            {
                Name = "Gold",
                Weight = 10,
                Value = 60
            });

            items.Add(new Item
            {
                Name = "Silver",
                Weight = 20,
                Value = 100
            });

            items.Add(new Item
            {
                Name = "Bronze",
                Weight = 30,
                Value = 120
            });

            Console.WriteLine("Profit of ${0}.", FractionalKnapsackMaxProfit(items, 50));

            Console.ReadKey();
        }

        static decimal FractionalKnapsackMaxProfit(IEnumerable<Item> items, decimal knapsackCapacity)
        {
            var knapsack = new List<Item>();

            //Order Items by there valubale
            var orderedItems = items.OrderByDescending(currentItem => currentItem.Valuable);

            foreach (var item in orderedItems)
            {
                if (knapsackCapacity == 0)
                    break;

                if (item.Weight > knapsackCapacity)
                {
                    item.Value = knapsackCapacity * item.Value / item.Weight;
                    item.Weight = knapsackCapacity;
                }
                Console.WriteLine("Adding {0} weighing {1} with the value of {2} with a Value/Weight ratio of {3}.", item.Name, item.Weight, item.Value, item.Valuable);
                knapsack.Add(item);
                knapsackCapacity -= item.Weight;
                Console.WriteLine("Knapsack capacity now {0} .", knapsackCapacity);
            }

            return knapsack.Sum(currentItem => currentItem.Value);
        }

        public class Item
        {
            public string Name { get; set; }
            public decimal Weight { get; set; }
            public decimal Value { get; set; }
            public decimal Valuable { get => Value / Weight; }
        }

    }
}

