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
            player.BuyItems();
        }
    }
}