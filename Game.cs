using System;

namespace lemonadeStandGame
{
    public class Game
    {
        // member variables
        Player player;
        Weather weather;
        Day day;
        Customer customer;
        Store store;
        // constructor
        public Game()
        {

        }

        // member methods
        public void StartGame()
        {
            Console.WriteLine("Welcome to Lemonade Stand Game");
            player = new Player();
            BuyItems();
        }

        public void BuyItems()
        {
            player.DisplayInventory();
            Console.WriteLine($"Your current balance is ${player.balance}");
            Console.WriteLine($"How many [Paper Cups] would you like to buy? (Price for each: ${player.paperCups.price})");
            int amount = Convert.ToInt32(Console.ReadLine());
            player.balance -= amount * player.paperCups.price;
            player.paperCups.amount += amount;
            player.DisplayInventory();
            Console.WriteLine($"Your current balance is ${player.balance}");
            Console.WriteLine($"How many [Lemons] would you like to buy? (Price for each: ${player.lemons.price})");
            amount = Convert.ToInt32(Console.ReadLine());
            player.balance -= amount * player.lemons.price;
            player.lemons.amount += amount;
            player.DisplayInventory();
            Console.WriteLine($"Your current balance is ${player.balance}");
            Console.WriteLine($"How many [Cups Of Sugar] would you like to buy? (Price for each: ${player.cupsOfSugar.price})");
            amount = Convert.ToInt32(Console.ReadLine());
            player.balance -= amount * player.cupsOfSugar.price;
            player.cupsOfSugar.amount += amount;
            player.DisplayInventory();
            Console.WriteLine($"Your current balance is ${player.balance}");
            Console.WriteLine($"How many [Ice Cubes] would you like to buy? (Price for each: ${player.iceCubes.price})");      
            amount = Convert.ToInt32(Console.ReadLine());
            player.balance -= amount * player.iceCubes.price;
            player.iceCubes.amount += amount;
            player.DisplayInventory();
            Console.WriteLine($"Your current balance is ${player.balance}");
        }
    }
}