using System;
using System.Collections.Generic;

namespace lemonadeStandGame
{
    public class Inventory
    {
        // member variables
        public List<Items> itemList;
        public Items paperCups;
        public Items lemons;
        public Items cupsOfSugar;
        public Items iceCubes;
        public Pitcher pitcher;
        public bool isPitcherEmpty;


        // constructor
        public Inventory()
        {
            paperCups = new Items();
            lemons = new Items();
            cupsOfSugar = new Items();
            iceCubes = new Items();
            pitcher = new Pitcher();
            AddItems();
        }
        // member methods
        public void AddItems()
        {
            itemList = new List<Items>();
            itemList.Add(paperCups);
            itemList.Add(lemons);
            itemList.Add(cupsOfSugar);
            itemList.Add(iceCubes);
            paperCups.name = "papercups";
            paperCups.amount = 0;
            paperCups.price = 0.0294;
            lemons.name = "lemons";
            lemons.amount = 0;
            lemons.price = 0.0569;
            cupsOfSugar.name = "cupsofsugar";
            cupsOfSugar.amount = 0;
            cupsOfSugar.price = 0.0712;
            iceCubes.name = "icecubes";
            iceCubes.amount = 0;
            iceCubes.price = 0.0078;
        }

        // SOLID DESIGN PRINCIPLE USED
        // I wrote a method here to check if the pitcher is empty or not
        // So during the gameplay I can eaisly call this method to check if the pitcher is empty or not
        public void CheckIfPitcherEmpty()
        {
            if(pitcher.cupsInPitcher == 0){
                isPitcherEmpty = true;
            }
            else {
                isPitcherEmpty = false;
            }
        }
    }
}