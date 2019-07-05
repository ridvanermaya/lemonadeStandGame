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
            string userInput;
            Console.WriteLine("\nPrice per Cup? [cents]");
            userInput = Console.ReadLine();
            pricePerCup = ValidateUserInputForIntegers(userInput, "Price per Cup [cents]");
        }

        public void SetLemonsPerPitcher()
        {
            string userInput;
            Console.WriteLine("\nAmount of Lemons per Pitcher?");
            userInput = Console.ReadLine();
            lemonsPerPitcher = ValidateUserInputForIntegers(userInput, "Amount of Lemons per Pitcher?");
        }

        public void SetCupsOfSugarPerPitcher() 
        {
            string userInput;
            Console.WriteLine("\nCups of Sugar per Pitcher?");
            userInput = Console.ReadLine();
            cupsOfSugarPerPitcher = ValidateUserInputForIntegers(userInput, "Cups of Sugar per Pitcher?");
        }

        public void SetIceCubesPerCup()
        {
            string userInput;
            Console.WriteLine("\nAmount of Ice Cubes per Cup?");
            userInput = Console.ReadLine();
            iceCubesPerCup = ValidateUserInputForIntegers(userInput, "Amount of Ice Cubes per Cup?");
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
            Console.Clear();
            inventory.DisplayInventory();
            BuyItem(inventory.lemons);
            Console.Clear();
            inventory.DisplayInventory();
            BuyItem(inventory.cupsOfSugar);
            Console.Clear();
            inventory.DisplayInventory();
            BuyItem(inventory.iceCubes);
        }

        public void BuyItem(Items item)
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

        public void DisplayRecipe()
        {
            Console.WriteLine("\nYour Recipe");
            Console.WriteLine($"Price per cup: {pricePerCup}");
            Console.WriteLine($"Lemons per pitcher: {lemonsPerPitcher}");
            Console.WriteLine($"Cups of Sugar per pitcher: {cupsOfSugarPerPitcher}");
            Console.WriteLine($"Ice per cup: {iceCubesPerCup}");
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Your Balance: ${balance}");
        }

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

        // checks for user input if the user input is valid returns the valid value
        public int ValidateUserInputForIntegers(string userInput, string message) 
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