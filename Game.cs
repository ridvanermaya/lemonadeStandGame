using System;

namespace lemonadeStandGame
{
    public class Game
    {
        // member variables
        Player player;
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
            day = new Day();
            customer = new Customer();
            player = new Player();
            Greeting();
            
        }

        public void Greeting()
        {
            Console.WriteLine("Welcome to Lemonade Stand Game");
            Console.WriteLine("You will have 7 days to make as much money as possible," +
            "\nand you've decided to open a lemonade stand! You'll have complete control" +
            "\nover your business, including pricing, quality control, inventory control," +
            "\nand purchasing supplies. Buy your ingredients, set your recipe, and start selling!");
        }
    }
}