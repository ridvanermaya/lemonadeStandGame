using System;
using System.Threading;

namespace lemonadeStandGame
{
    public class Game
    {
        // member variables
        Player player;
        public Day day;
        Store store;
        int dayCounter;
        int daysToPlay;
        double dailyBalance;
        int soldLemonadeCount;
        Random rng;

        // constructor
        public Game()
        {

        }

        // member methods
        public void StartGame()
        {
            Console.Clear();
            Greeting();
            player = new Player();
            GameSettings();
            day = new Day();
            Console.Clear();

            while (dayCounter < (daysToPlay + 1)){
                OneDayGamePlay();
                dayCounter++;
            }
            double totalProfit = player.balance - 20;
            Console.WriteLine($"Your total balance is {totalProfit}");
        }

        public void Greeting()
        {
            Console.WriteLine("Welcome to Lemonade Stand Game");
            Console.WriteLine("\nYou will have certain amount of days to make as much money as possible," +
            "\nand you've decided to open a lemonade stand! You'll have complete control" +
            "\nover your business, including pricing, quality control, inventory control," +
            "\nand purchasing supplies. Buy your ingredients, set your recipe, and start selling!");
        }

        public void GameSettings()
        {
            string userInput;
            bool isValid;
            int amount;
            player.SetName();
            Console.Clear();
            Console.WriteLine($"Welcome {player.name}");
            Console.WriteLine("How many days would you like to play?");
            do
            {
                userInput = Console.ReadLine();
                isValid = int.TryParse(userInput, out amount);
                if (!isValid){
                    Console.WriteLine("Please enter a number.. For how many days would you like to play?");
                } 
            } while (!isValid);
            daysToPlay = amount;
        }

        // Goes through the list of customers to see if they buy or not
        public void PlayEachCustomer()
        {
            foreach (var item in day.Customers){
                Console.Clear();
                day.dailyweather.DisplayWeather();
                if(item.chanceToBuy >= 0.5){
                    if (player.inventory.paperCups.amount == 0 || player.inventory.iceCubes.amount < player.iceCubesPerCup){
                        Console.WriteLine("SOLD OUT!");
                    }
                    else {
                        player.inventory.CheckIfPitcherEmpty();
                        if(player.inventory.isPitcherEmpty){
                            player.RefillPitcher();
                        }
                        dailyBalance += player.pricePerCup / 100;
                        player.inventory.pitcher.cupsInPitcher--;
                        player.inventory.iceCubes.amount -= player.iceCubesPerCup;
                        player.inventory.paperCups.amount--;
                        player.inventory.DisplayInventory();
                        item.BuyLemonade();
                        soldLemonadeCount++;
                        Console.WriteLine($"\nDaily Earnings: ${dailyBalance}");
                    }
                }
                Thread.Sleep(1000);
            }
        }

        // displays end of day results
        public void DisplayEndOfDayResults()
        {
            Console.Clear();
            Console.WriteLine($"Remaining Ice {player.inventory.iceCubes.amount} melted.");
            player.inventory.DisplayInventory();
            Console.WriteLine($"\nYou sold {soldLemonadeCount} to {day.Customers.Count} potential customers.");
            Console.WriteLine($"\nToday's Earning's: ${dailyBalance}");
        }

        // gameplay for one day
        public void OneDayGamePlay()
        {
            soldLemonadeCount = 0;
            dailyBalance = 0;
            day.Customers.Clear();
            day.dailyweather.SetDailyWeather();
            day.dailyweather.DisplayWeather();
            player.inventory.DisplayInventory();
            player.BuyItems();
            Console.Clear();
            day.dailyweather.DisplayWeather();
            player.CreateRecipe();
            player.RefillPitcher();
            GenerateDailyCustomers();
            PlayEachCustomer();
            player.inventory.iceCubes.amount = 0;
            player.balance += dailyBalance;
            DisplayEndOfDayResults();
            Thread.Sleep(10000);
            Console.Clear();
        }

        // generate daily customers
        public void GenerateDailyCustomers()
        {
            int count = 0;
            rng = new Random();
            int randomNumber = rng.Next(80, 120);
            while (count < randomNumber){
                day.GenerateRandomCustomer(player.pricePerCup, player.cupsOfSugarPerPitcher, player.lemonsPerPitcher, player.iceCubesPerCup);
                count++;
            }
        }
    }
}