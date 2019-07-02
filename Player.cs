using System;
using System.Collections.Generic;

namespace lemonadeStandGame
{
    public class Player
    {
        // member variables
        public string name {get; set;}
        public double balance {get; set;}
        public List<Items> itemList;
        public Items paperCups {get; set;}
        public Items lemons {get; set;}
        public Items cupsOfSugar {get; set;}
        public Items iceCubes {get; set;}
        public bool SufficentBalance;

        // constructor
        public Player(){
            paperCups = new Items();
            lemons = new Items();
            cupsOfSugar = new Items();
            iceCubes = new Items();
            AddItems();
            balance = 20;
            SetName();
        }

        // member methods
        public void SetName()
        {
            Console.Write("\nPlease enter player name: ");
            name = Console.ReadLine();
        }

        public void CreateRecipe()
        {

        }

        public void DisplayInventory()
        {
            Console.WriteLine($"Paper Cups: {paperCups.amount}, Lemons: {lemons.amount}, Cups of Sugar: {cupsOfSugar.amount}, Ice Cubes: {iceCubes.amount}");
        }

        public void AddItems()
        {
            itemList = new List<Items>();
            itemList.Add(paperCups);
            itemList.Add(lemons);
            itemList.Add(cupsOfSugar);
            itemList.Add(iceCubes);
            paperCups.name = "papercups";
            paperCups.amount = 0;
            paperCups.price = 0.02;
            lemons.name = "lemons";
            lemons.amount = 0;
            lemons.price = 0.04;
            cupsOfSugar.name = "cupsofsugar";
            cupsOfSugar.amount = 0;
            cupsOfSugar.price = 0.04;
            iceCubes.name = "icecubes";
            iceCubes.amount = 0;
            iceCubes.price = 0.01;
        }


        public void BuyItems()
        {
            BuyItem(paperCups);
            BuyItem(lemons);
            BuyItem(cupsOfSugar);
            BuyItem(iceCubes);
        }

        public void BuyItem(Items item)
        {
            SufficentBalance = false;
            DisplayInventory();
            while(!SufficentBalance){
                Console.WriteLine($"Your current balance is ${balance}");
                Console.WriteLine($"How many {item.name} would you like to buy? (Price for each: ${item.price})");
                int amount = Convert.ToInt32(Console.ReadLine());
                if (balance >= (amount * item.price)) {
                    balance -= amount * item.price;
                    Console.WriteLine("Purchase successfull!");
                    SufficentBalance = true;
                    item.amount += amount;
                }
                else {
                    Console.WriteLine("Purchase unsuccessfull. Reason: Insufficient funds!");
                    SufficentBalance = false;
                }
            }
        }
    }
}