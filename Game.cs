using System;
using System.Threading;

namespace lemonadeStandGame
{
    public class Game
    {
        // member variables
        Player player;
        Day day;
        Store store;

        // constructor
        public Game()
        {

        }

        // member methods
        public void StartGame()
        {
            Console.Clear();
            day = new Day();
            player = new Player();
            Greeting();
            player.SetName();
            Console.Clear();
            Console.WriteLine($"Welcome {player.name}");
            //
            //
            day.dailyweather.SetDailyWeather();
            day.dailyweather.DisplayWeather();
            player.inventory.DisplayInventory();
            player.BuyItems();
            player.CreateRecipe();
            Console.Clear();
            day.dailyweather.DisplayWeather();
            player.DisplayRecipe();
            player.inventory.DisplayInventory();
            player.RefillPitcher();
            Console.WriteLine($"\nYour Balance: ${player.balance}");
            foreach (var item in day.Customers)
            {
                Console.Clear();
                if(item.chanceToBuy >= 0.5){
                    if (player.inventory.paperCups.amount == 0 || player.inventory.iceCubes.amount < player.iceCubesPerCup){
                    Console.WriteLine("SOLD OUT!");
                    }
                    else {
                        player.inventory.CheckIfPitcherEmpty();
                        if(player.inventory.isPitcherEmpty){
                            player.RefillPitcher();
                        }
                        player.balance += player.pricePerCup / 100;
                        player.inventory.pitcher.cupsInPitcher--;
                        player.inventory.iceCubes.amount -= player.iceCubesPerCup;
                        player.inventory.paperCups.amount--;
                        player.DisplayBalance();
                        player.inventory.DisplayInventory();
                        item.BuyLemonade();
                    }
                }
                Thread.Sleep(1500);
            }
            Console.WriteLine(player.balance);
        }

        public void Greeting()
        {
            Console.WriteLine("Welcome to Lemonade Stand Game");
            Console.WriteLine("\nYou will have 7 days to make as much money as possible," +
            "\nand you've decided to open a lemonade stand! You'll have complete control" +
            "\nover your business, including pricing, quality control, inventory control," +
            "\nand purchasing supplies. Buy your ingredients, set your recipe, and start selling!");
        }
    }
}