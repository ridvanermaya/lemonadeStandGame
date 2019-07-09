using System;
using System.Threading;

namespace lemonadeStandGame
{
    public class Game
    {
        // member variables
        Player player;
        Day day;
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
        // playing game from the beginning to the end
        public void StartGame()
        {
            player = new Player();
            day = new Day();
            dayCounter = 1;
            Console.Clear();
            UserInterface.Greeting();
            daysToPlay = UserInterface.GameSettings(player);
            Console.Clear();
            
            while (dayCounter < (daysToPlay + 1)){
                OneDayGamePlay();
                dayCounter++;
            }
            
            CheckForTotalProfit();
            UserInterface.EndGameScreen();
        }

        // goes through the list of customers to see if they buy or not
        public void PlayEachCustomer()
        {
            foreach (var item in day.Customers){
                Console.Clear();
                UserInterface.DisplayCurrentDay(dayCounter);
                day.dailyweather.DisplayActualWeather();
                if(item.chanceToBuy >= 0.5){
                    if (player.inventory.paperCups.amount == 0 || player.inventory.iceCubes.amount < player.iceCubesPerCup){
                        Console.WriteLine("\nSOLD OUT!");
                    }
                    else {
                        player.inventory.CheckIfPitcherEmpty();
                        if(player.inventory.isPitcherEmpty){
                            player.RefillPitcher();
                        }
                        dailyBalance += player.pricePerCup / 100;
                        dailyBalance = Math.Round(dailyBalance, 2);
                        player.inventory.pitcher.cupsInPitcher--;
                        player.inventory.iceCubes.amount -= player.iceCubesPerCup;
                        player.inventory.paperCups.amount--;
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
            UserInterface.DisplayInventory(player.inventory);
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
            UserInterface.DisplayWeather(day.dailyweather);
            UserInterface.DisplayInventory(player.inventory);
            player.BuyItems(day.dailyweather);
            Console.Clear();
            UserInterface.DisplayWeather(day.dailyweather);
            day.dailyweather.SetActualWeather();
            player.CreateRecipe();
            player.RefillPitcher();
            UserInterface.CountToThree();
            day.dailyweather.DisplayActualWeather();
            GenerateDailyCustomers();
            PlayEachCustomer();
            player.inventory.iceCubes.amount = 0;
            player.balance += dailyBalance;
            player.balance = Math.Round(player.balance, 2);
            DisplayEndOfDayResults();
            Console.WriteLine("Press any button to continue..");
            Console.ReadKey();
            Console.Clear();
        }

        // generates daily customers depending on the temperature
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

        // checks the total profit for the end of the game and writes the results to the console
        // with different foreground color
        public void CheckForTotalProfit() {
            double totalProfit = player.balance - 20;
            totalProfit = Math.Round(totalProfit, 2);

            if (totalProfit < 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your total profit is ${totalProfit} and you lost money!");
                Console.ResetColor();
            }
            else if (totalProfit == 0) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Your total profit is ${totalProfit} and neither you earned nor lost money!");
                Console.ResetColor();
            }
            else {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congratulations your total profit is ${totalProfit}.");
                Console.ResetColor();
            }
        }
    }
}