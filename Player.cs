using System;

namespace lemonadeStandGame
{
    public class Player
    {
        // member variables
        public string name {get; set;}
        public double balance {get; set;}
        public Inventory inventory;


        // constructor
        public Player(){
            inventory = new Inventory();
            balance = 20;
            SetName();
        }

        // member methods
        public void SetName()
        {
            Console.Write("\nPlease enter player name: ");
            name = Console.ReadLine();
            Console.WriteLine(name);
        }

        public void BuyItems(string itemName, int amount)
        {
            
        }
    }
}