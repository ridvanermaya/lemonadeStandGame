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
        int pricePerCup;
        int lemonsPerPitcher;
        int cupsOfSugarPerPitcher;
        int iceCubesPerCup;

        // constructor
        public Player(){
            inventory = new Inventory();
            balance = 20;
        }

        // member methods
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

        public void SetName()
        {
            Console.Write("\nPlease enter player name: ");
            name = Console.ReadLine();
        }

        public void SetPricePerCup()
        {
            int amount;
            bool validInput;
            string userInput;
            Console.WriteLine("\nPrice per Cup? [cents]");
            do
            {
                userInput = Console.ReadLine();
                validInput = int.TryParse(userInput, out amount);
                if (!validInput){
                    Console.WriteLine("\nPlese enter a number.. Price per Cup? [cents]");
                }
            } while (!validInput);
            pricePerCup = amount;
        }

        public void SetLemonsPerPitcher()
        {
            int amount;
            bool validInput;
            string userInput;
            Console.WriteLine("\nAmount of Lemons per Pitcher?");
            do
            {
                userInput = Console.ReadLine();
                validInput = int.TryParse(userInput, out amount);
                if (!validInput){
                    Console.WriteLine("\nPlease enter a number.. Amount of Lemons per Pitcher?");
                }
            } while (!validInput);
            lemonsPerPitcher = amount;
        }

        public void SetCupsOfSugarPerPitcher() 
        {
            int amount;
            bool validInput;
            string userInput;
            Console.WriteLine("\nCups of Sugar per Pitcher?");
            do
            {
                userInput = Console.ReadLine();
                validInput = int.TryParse(userInput, out amount);
                if (!validInput){
                    Console.WriteLine("\nPlease enter a number... Cups of Suger per Pitcher?");
                }
            } while (!validInput);
            cupsOfSugarPerPitcher = amount;
        }

        public void SetIceCubesPerCup()
        {
            int amount;
            bool validInput;
            string userInput;
            Console.WriteLine("\nAmount of Ice Cubes per Cup?");
            do
            {
                userInput = Console.ReadLine();
                validInput = int.TryParse(userInput, out amount);
                if (!validInput){
                    Console.WriteLine("\nPlease enter a number... Amount of Ice Cubes per Cup?");
                }
            } while (!validInput);
            iceCubesPerCup = amount;
        }
        
        public void CreateRecipe()
        {
            Console.WriteLine("\nCreating Recipe for the day!");
            SetPricePerCup();
            SetLemonsPerPitcher();
            SetCupsOfSugarPerPitcher();
            SetIceCubesPerCup();
        }

        public void BuyItems()
        {
            BuyItem(inventory.paperCups);
            BuyItem(inventory.lemons);
            BuyItem(inventory.cupsOfSugar);
            BuyItem(inventory.iceCubes);
        }

        public void BuyItem(Items item)
        {
            int amount;
            string userInput;
            bool validInput;
            sufficentBalance = false;
            while(!sufficentBalance){
                Console.WriteLine($"\nYour current balance is ${balance}");
                Console.WriteLine($"\nHow many {item.name} would you like to buy? (Price for each: ${item.price})"); 
                do
                {
                    userInput = Console.ReadLine();
                    validInput = int.TryParse(userInput, out amount);
                    if (!validInput){
                        Console.WriteLine($"\nPlease enter a number.. How many {item.name} would you like to buy? (Price for each: ${item.price}");
                    }
                } while (!validInput);

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

        public void DisplayRecipe()
        {
            Console.WriteLine("\nYour Recipe");
            Console.WriteLine($"Price per cup: {pricePerCup}");
            Console.WriteLine($"Lemons per pitcher: {lemonsPerPitcher}");
            Console.WriteLine($"Cups of Sugar per pitcher: {cupsOfSugarPerPitcher}");
            Console.WriteLine($"Ice per cup: {iceCubesPerCup}");
        }
    }
}