using System;

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
            day.dailyweather.SetDailyWeather();
            day.dailyweather.DisplayWeather();
            player.inventory.DisplayInventory();
            player.BuyItems();
            player.CreateRecipe();
            Console.Clear();
            day.dailyweather.DisplayWeather();
            player.DisplayRecipe();
            player.inventory.DisplayInventory();
            Console.WriteLine($"\nYour current balance is ${player.balance}");
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