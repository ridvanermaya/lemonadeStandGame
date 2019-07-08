using System;

namespace lemonadeStandGame
{
    public static class UserInterface
    {
        // member variables

        // constructor

        // member methods
        public static void DisplayWeather(Weather weather)
        {
            Console.WriteLine("\nToday's Atmosphere Condition");
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
        public static void BuyItem(Items item, double balance, bool sufficentBalance)
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
                }
                else {
                    Console.WriteLine("\nPurchase unsuccessfull. Reason: Insufficient funds!");
                    sufficentBalance = false;
                }
            }
        }

        // setting price per cup
        public static void SetPricePerCup(double pricePerCup)
        {
            string userInput;
            Console.WriteLine("\nPrice per Cup? [cents]");
            userInput = Console.ReadLine();
            pricePerCup = ValidateUserInputForIntegers(userInput, "Price per Cup [cents]");
        }

        // setting amount of lemons per pitcher
        public static void SetLemonsPerPitcher(double lemonsPerPitcher)
        {
            string userInput;
            Console.WriteLine("\nAmount of Lemons per Pitcher?");
            userInput = Console.ReadLine();
            lemonsPerPitcher = ValidateUserInputForIntegers(userInput, "Amount of Lemons per Pitcher?");
        }

        // setting cups of suger per pitcher
        public static void SetCupsOfSugarPerPitcher(double cupsOfSugarPerPitcher) 
        {
            string userInput;
            Console.WriteLine("\nCups of Sugar per Pitcher?");
            userInput = Console.ReadLine();
            cupsOfSugarPerPitcher = ValidateUserInputForIntegers(userInput, "Cups of Sugar per Pitcher?");
        }

        // setting amount of ice cube per cup
        public static void SetIceCubesPerCup(double iceCubesPerCup)
        {
            string userInput;
            Console.WriteLine("\nAmount of Ice Cubes per Cup?");
            userInput = Console.ReadLine();
            iceCubesPerCup = ValidateUserInputForIntegers(userInput, "Amount of Ice Cubes per Cup?");
        }

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
    }
}