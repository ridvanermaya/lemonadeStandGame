using System;
using System.Collections.Generic;

namespace lemonadeStandGame
{
    public class Player
    {
        // member variables
        public string name;
        public double balance;
        public Inventory inventory;
        public bool sufficentBalance;
        public double pricePerCup;
        public int lemonsPerPitcher;
        public int cupsOfSugarPerPitcher;
        public int iceCubesPerCup;

        // constructor
        public Player(){
            inventory = new Inventory();
            balance = 20;
        }

        // member methods
        // preparing new pitcher
        public void PreparePitcher()
        {
            if (inventory.cupsOfSugar.amount >= cupsOfSugarPerPitcher && 
                inventory.lemons.amount >= lemonsPerPitcher){
                inventory.cupsOfSugar.amount -= cupsOfSugarPerPitcher;
                inventory.lemons.amount -= lemonsPerPitcher;
                inventory.pitcher.cupsInPitcher = 12;
            }
            else {
                Console.WriteLine("You don't have necessary items to make lemonade.");
            }
        }

        // setting player name
        public void SetName()
        {
            Console.Write("\nPlease enter player name: ");
            name = Console.ReadLine();
        }
        
        // player creates recipe
        public void CreateRecipe()
        {
            Console.WriteLine("\nCreating Recipe for the day!");
            pricePerCup = UserInterface.SetPricePerCup(pricePerCup);
            lemonsPerPitcher = UserInterface.SetLemonsPerPitcher(lemonsPerPitcher);
            cupsOfSugarPerPitcher = UserInterface.SetCupsOfSugarPerPitcher(cupsOfSugarPerPitcher);
            iceCubesPerCup = UserInterface.SetIceCubesPerCup(iceCubesPerCup);
        }

        // buying items for the lemonade stand
        public void BuyItems(Weather weather)
        {
            Console.Clear();
            UserInterface.DisplayWeather(weather);
            UserInterface.DisplayInventory(inventory);
            balance = UserInterface.BuyItem(inventory.paperCups, balance, sufficentBalance);
            Console.Clear();
            UserInterface.DisplayWeather(weather);
            UserInterface.DisplayInventory(inventory);
            balance = UserInterface.BuyItem(inventory.lemons, balance, sufficentBalance);
            Console.Clear();
            UserInterface.DisplayWeather(weather);
            UserInterface.DisplayInventory(inventory);
            balance = UserInterface.BuyItem(inventory.cupsOfSugar, balance, sufficentBalance);
            Console.Clear();
            UserInterface.DisplayWeather(weather);
            UserInterface.DisplayInventory(inventory);
            balance = UserInterface.BuyItem(inventory.iceCubes, balance, sufficentBalance);
        }

        // displays player's money
        public void DisplayBalance()
        {
            Console.WriteLine($"Your Balance: ${balance}");
        }

        // refills pitcher when cupsInPicther drops to '0'
        public void RefillPitcher()
        {
            if(inventory.lemons.amount < lemonsPerPitcher || inventory.cupsOfSugar.amount < cupsOfSugarPerPitcher){
                Console.WriteLine("SOLD OUT");
            }
            else {
                inventory.lemons.amount -= lemonsPerPitcher;
                inventory.cupsOfSugar.amount -= cupsOfSugarPerPitcher;
                inventory.pitcher.cupsInPitcher = 12;
            }
        }
    }
}