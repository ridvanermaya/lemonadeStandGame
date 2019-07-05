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
            dayCounter = 0;

            while (dayCounter < daysToPlay){
                OneDayGamePlay();
                dayCounter++;
            }
            double totalProfit = player.balance - 20;

            if (totalProfit < 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your total profit is ${totalProfit} and you lost money!");
            }
            else if (totalProfit == 0) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Your total profit is ${totalProfit} and neither you earned nor lost money!");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congratulations your total profit is ${totalProfit}.");
            }
            Console.ResetColor();
            EndGameScreen();
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
            player.SetName();
            Console.Clear();
            Console.WriteLine($"Welcome to {player.name}'s Lemonade Stand");
            Console.WriteLine("How many days would you like to play?");
            userInput = Console.ReadLine();
            daysToPlay = ValidateUserInputForIntegers(userInput, "How many days would you like to play?");
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
                Thread.Sleep(500);
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
            int randomNumber;
            if (day.dailyweather.dailyTemperature > 80) {
                randomNumber = rng.Next(101, 125);
                while (count < randomNumber) {
                    day.GenerateRandomCustomer(player.pricePerCup, player.cupsOfSugarPerPitcher, player.lemonsPerPitcher, player.iceCubesPerCup);
                    count++;
                }
            }
            else {
                rng = new Random();
                randomNumber = rng.Next(75, 101);
                while (count < randomNumber){
                    day.GenerateRandomCustomer(player.pricePerCup, player.cupsOfSugarPerPitcher, player.lemonsPerPitcher, player.iceCubesPerCup);
                    count++;
                }
            }
        }

        public void EndGameScreen() 
        {
            Console.WriteLine("GAME OVER");
        }

        // checks for user input if the user input is valid returns the valid value
        public int ValidateUserInputForIntegers(string userInput, string message) 
        {
            bool isValid;
            int amount;
            do {
                isValid = int.TryParse(userInput, out amount);
                if (!isValid) {
                    Console.WriteLine("\nYou didn't enter a number.. Please enter a number..");
                    Console.WriteLine(message);
                    userInput = Console.ReadLine();
                }
            } while (!isValid);
            return amount;
        }
    }
}