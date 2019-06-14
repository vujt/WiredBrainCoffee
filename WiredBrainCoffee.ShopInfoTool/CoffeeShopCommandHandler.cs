using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.DataAccess.Model;

namespace WiredBrainCoffee.ShopInfoTool
{
    internal class CoffeeShopCommandHandler : ICommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;
        private string line;

        public CoffeeShopCommandHandler(IEnumerable<CoffeeShop> coffeeShops, string line)
        {
            this.coffeeShops = coffeeShops;
            this.line = line;
        }

        public void HandleCommand()
        {
            var foundCoffeShops = coffeeShops
                        .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                        .ToList();

            if (foundCoffeShops.Count == 0)
            {
                Console.WriteLine($"> Command '{line}' not found");
            }
            else if (foundCoffeShops.Count == 1)
            {
                var coffeeShop = foundCoffeShops.Single();
                Console.WriteLine($"> Location: {coffeeShop.Location}");
                Console.WriteLine($"> Beans in stock: {coffeeShop.BeansInStockInKg} kg");
            }
            else
            {
                Console.WriteLine($"> Multiple matching coffee shop commands found: ");
                foreach (var coffeeType in foundCoffeShops)
                {
                    Console.WriteLine($"> {coffeeType.Location}");
                }
            }

        }
    }
}