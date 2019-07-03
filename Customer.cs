using System;

namespace lemonadeStandGame
{
    public class Customer
    {
        // member variables
        public string name;
        public double chanceToBuy;
        public bool isThirsty;
        public bool likeLemonade;
        public bool willBuy;

        // constructor
        public Customer(string name, double chanceToBuy, bool isThirsty, bool likeLemonade)
        {
            this.name = name;
            this.chanceToBuy = chanceToBuy;
            this.isThirsty = isThirsty;
            this.likeLemonade = likeLemonade;
        }

        // member methods
        public bool BuyLemonade(){
            if (chanceToBuy >= 0.5){
                Console.WriteLine($"{name} bought a lemonade.");
                return true;
            }
            else {
                return false;
            }
        }
    }
}