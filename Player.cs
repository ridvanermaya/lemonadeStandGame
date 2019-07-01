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

        public void BuyItems()
        {

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
    }
}