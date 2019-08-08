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
                Name = "Silver",
                Weight = 5,
                Value = 100
            });

            items.Add(new Item
            {
                Name = "Gold",
                Weight = 2,
                Value = 70
            });

            items.Add(new Item
            {
                Name = "Plate",
                Weight = 8,
                Value = 50
            });

            items.Add(new Item
            {
                Name = "Diamond A",
                Weight = 15,
                Value = 150
            });

            items.Add(new Item
            {
                Name = "Diamond B",
                Weight = 4,
                Value = 50
            });

            Console.WriteLine(FractionalKnapsackMaxProfit(items, 25));

            Console.ReadKey();
        }

        static decimal FractionalKnapsackMaxProfit(IEnumerable<Item> items, decimal knapsackCapacity)
        {
            var knapsack = new List<Item>();

            //Order Items
            var orderedItems = items.OrderByDescending(currentItem => currentItem.Valuable);

            foreach(var item in orderedItems)
            {
                if (knapsackCapacity == 0)
                    break; //Se não cabe mais nada, saio

                if (item.Weight > knapsackCapacity)
                {
                    item.Value = knapsackCapacity * item.Value / item.Weight; 
                    item.Weight = knapsackCapacity; //Levo de item o quanto cabe na mochila
                }
                knapsack.Add(item);
                knapsackCapacity -= item.Weight;
            }

            return knapsack.Sum(currentItem => currentItem.Value);
        }
    }
}
