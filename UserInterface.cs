using System;
using System.Threading;

namespace lemonadeStandGame
{
    public static class UserInterface
    {
        // member variables

        // constructor

        // member methods
        public static void DisplayWeather(Weather weather)
        {
            Console.WriteLine("\nToday's Possible Weather");
            Console.WriteLine($"Forecast: {weather.dailyForecast}");
            Console.WriteLine($"Temperature: {weather.dailyTemperature}");
        }

        public static void DisplayInventory(Inventory inventory)
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("Your Inventory");
            Console.WriteLine("--------------");
            Console.WriteLine($"[Paper Cups]: {inventory.paperCups.amount}");
            Console.WriteLine($"[Lemons]: {inventory.lemons.amount}");
            Console.WriteLine($"[Cups of Sugar]: {inventory.cupsOfSugar.amount}");
            Console.WriteLine($"[Ice Cubes]: {inventory.iceCubes.amount}");
        }

        public static void DisplayRecipe(Player player)
        {
            Console.WriteLine("\nYour Recipe");
            Console.WriteLine("--------------");
            Console.WriteLine($"Price per cup: {player.pricePerCup}");
            Console.WriteLine($"Lemons per pitcher: {player.lemonsPerPitcher}");
            Console.WriteLine($"Cups of Sugar per pitcher: {player.cupsOfSugarPerPitcher}");
            Console.WriteLine($"Ice per cup: {player.iceCubesPerCup}");
        }

        public static void DisplayCurrentDay(int daycounter)
        {
            Console.WriteLine($"Day {daycounter}");
        }

        // greets the player and gives basic information about the game
        public static void Greeting()
        {
            Console.WriteLine("Welcome to Lemonade Stand Game");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. You've decided to open a lemonade stand!");
            Console.WriteLine("2. You set the amount of days to play.");
            Console.WriteLine("3. You have certain amount of days to make as much as money possible.");
            Console.WriteLine("4. You have complete control over your business.");
            Console.WriteLine("5. You will control pricing, quality, inventory, and purchasing new items.");
            Console.WriteLine("6. Buy your ingredients, set your recipe, and start selling!");
        }

        public static void EndGameScreen() 
        {
            Console.WriteLine("GAME OVER");
        }

        // asks users for days to play
        public static int GameSettings(Player player)
        {
            string userInput;
            player.SetName();
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"\nWelcome to {player.name}'s Lemonade Stand");
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("\nHow many days would you like to play?");
            userInput = Console.ReadLine();
            return ValidateUserInputForIntegers(userInput, "How many days would you like to play?");
        }

        // buying item for lemonade stand
        public static double BuyItem(Items item, double balance, bool sufficentBalance)
        {
            string userInput;
            int amount;
            sufficentBalance = false;
            while(!sufficentBalance){
                Console.WriteLine($"\nYour Balance: ${balance}");
                Console.WriteLine($"\nHow many {item.name} would you like to buy? (Price for each: ${item.price})"); 
                userInput = Console.ReadLine();
                amount = ValidateUserInputForIntegers(userInput, $"How many {item.name} would you like to buy? (Price for each: ${item.price})");

                if (balance >= (amount * item.price)) {
                    balance -= amount * item.price;
                    Console.WriteLine("\nPurchase successfull!");
                    sufficentBalance = true;
                    item.amount += amount;
                    balance = Math.Round(balance, 2);
                    return balance;
                }
                else {
                    Console.WriteLine("\nPurchase unsuccessfull. Reason: Insufficient funds!");
                    sufficentBalance = false;
                    balance = Math.Round(balance, 2);
                    return balance;
                }
            }
            return balance;
        }

        // setting price per cup
        public static double SetPricePerCup(double pricePerCup)
        {
            string userInput;
            Console.WriteLine("\nPrice per Cup? [cents]");
            userInput = Console.ReadLine();
            return pricePerCup = ValidateUserInputForIntegers(userInput, "Price per Cup [cents]");
        }

        // setting amount of lemons per pitcher
        public static int SetLemonsPerPitcher(int lemonsPerPitcher)
        {
            string userInput;
            Console.WriteLine("\nAmount of Lemons per Pitcher?");
            userInput = Console.ReadLine();
            return lemonsPerPitcher = ValidateUserInputForIntegers(userInput, "Amount of Lemons per Pitcher?");
        }

        // setting cups of suger per pitcher
        public static int SetCupsOfSugarPerPitcher(int cupsOfSugarPerPitcher) 
        {
            string userInput;
            Console.WriteLine("\nCups of Sugar per Pitcher?");
            userInput = Console.ReadLine();
            return cupsOfSugarPerPitcher = ValidateUserInputForIntegers(userInput, "Cups of Sugar per Pitcher?");
        }

        // setting amount of ice cube per cup
        public static int SetIceCubesPerCup(int iceCubesPerCup)
        {
            string userInput;
            Console.WriteLine("\nAmount of Ice Cubes per Cup?");
            userInput = Console.ReadLine();
            return iceCubesPerCup = ValidateUserInputForIntegers(userInput, "Amount of Ice Cubes per Cup?");
        }

        // SOLID DESIGN PRINCIPLE USED
        // In my design, I need to check if the user is inputing an integer in many places.
        // So I wrote a method that trys to convert the user input to integer
        // If the input cannot be converted to integer then the user is reprompted to enter a number again.
        // This method can be used in many places for user Input and as second parameter the developer can
        // put any message for the user to see
        // checks for user input if the user input is valid returns the valid value
        public static int ValidateUserInputForIntegers(string userInput, string message) 
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

        public static void CountToThree()
        {
            Console.Clear();
            Console.WriteLine("Game is starting...");
            Console.WriteLine("-------- 1 --------");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Game is starting...");
            Console.WriteLine("-------- 2 --------");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Game is starting...");
            Console.WriteLine("-------- 3 --------");
        }
    }
}