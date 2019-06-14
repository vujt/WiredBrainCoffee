using System;
using System.Linq;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee - Shop Info Tool!");

            Console.WriteLine("Write 'help' to list available coffee shop commands, " +
                "write 'quit' to exit application");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands:");
                    foreach (var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine($"> " + coffeeShop.Location);
                    }
                }
                else
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
    }
}
