using System;
using System.Linq;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee.ShopInfoTool
{
    class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
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

                var commandHandler =
                    string.Equals("help", line, StringComparison.OrdinalIgnoreCase) 
                    ? new HelpCommandHandler(coffeeShops) as ICommandHandler
                    : new  CoffeeShopCommandHandler(coffeeShops, line);

                commandHandler.HandleCommand();
            }

        }
    }
}
