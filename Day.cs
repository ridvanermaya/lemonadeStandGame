using System;
using System.Collections.Generic;

namespace lemonadeStandGame 
{
    public class Day
    {
        // member variables
        public Weather dailyweather;
        public List<string> names;
        public List<Customer> Customers;
        public Customer customer;
        public Random rng;

        // constructor
        public Day()
        {
            dailyweather = new Weather();
            names = new List<string>();
            rng = new Random();
            Customers = new List<Customer>();
            AddNames();
        }
        // member methods
        public void GenerateRandomCustomer() 
        {
            bool isThirsty;
            bool likeLemonade;
            int randomNumberForName = rng.Next(0, names.Count);
            double randomNumberForChanceToBuy = rng.NextDouble();
            int randomNumberForThirstLevel = rng.Next(0, 11);
            int randomNumberForLikeLemonade = rng.Next(0, 11);
            int randomNumberForPriceOfLemonade = rng.Next(0, 11);

            if (dailyweather.dailyTemperature >= 76 && dailyweather.dailyTemperature <= 110 || dailyweather.dailyForecast == WeatherTypes.Sunny && dailyweather.dailyForecast == WeatherTypes.PartlySunny){
                randomNumberForThirstLevel += 2;
                randomNumberForLikeLemonade += 2;
            }
            else if (dailyweather.dailyTemperature >= 61 && dailyweather.dailyTemperature <= 75 || dailyweather.dailyForecast == WeatherTypes.Hazy && dailyweather.dailyForecast == WeatherTypes.Cloudy){
                randomNumberForThirstLevel += 1;
                randomNumberForLikeLemonade += 1;
            }

            if (randomNumberForThirstLevel >= 5) {
                isThirsty = true;
                randomNumberForChanceToBuy += 0.1;
            } 
            else {
                isThirsty = false;
            }

            if (randomNumberForLikeLemonade >= 5) {
                likeLemonade = true;
                randomNumberForChanceToBuy += 0.1;
            } 
            else {
                likeLemonade = false;
                randomNumberForChanceToBuy -= 0.1;
            }

            // if (player.pricePerCup > 30 || player.pricePerCup <= 40) {
            //     randomNumberForChanceToBuy -= 0.1;
            // }
            // else if (player.pricePerCup > 40) {
            //     randomNumberForChanceToBuy -= 0.2;
            // }
            // else if (player.pricePerCup < 20 || player.pricePerCup >= 10) {
            //     randomNumberForChanceToBuy += 0.1;
            // }
            // else if (player.pricePerCup < 10) {
            //     randomNumberForChanceToBuy += 0.2;
            // }
            
            customer = new Customer(names[randomNumberForName], randomNumberForChanceToBuy, isThirsty, likeLemonade);
            Customers.Add(customer);
        }

        public void GenerateDailyCustomers() 
        {
            int count = 0;
            int randomNumber = rng.Next(80, 120);
            while (count < randomNumber){
                GenerateRandomCustomer();
                count++;
            }
        }

        public void AddNames()
        {
            names.Add("Micheal");
            names.Add("Harry");
            names.Add("Sam");
            names.Add("Nathan");
            names.Add("Sophia");
            names.Add("Amy");
            names.Add("Luke");
            names.Add("Jordan");
            names.Add("Charles");
            names.Add("Megan");
            names.Add("Casey");
            names.Add("Oscar");
            names.Add("Daniel");
            names.Add("Chad");
            names.Add("Summe");
            names.Add("Bella");
            names.Add("Paige");
            names.Add("Caitlin");
            names.Add("Ben");
            names.Add("Zac");
        }
    }
}