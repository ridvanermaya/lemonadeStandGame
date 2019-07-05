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
        // this method generates random customer by ...
        public void GenerateRandomCustomer(double pricePerCup, int amountOfSugar, int amountOfLemon, int amountOfIce) 
        {
            bool isThirsty;
            bool likeLemonade;
            bool likeSugar;
            bool likeLemon;
            bool caresAboutMoney;
            int randomNumberForName = rng.Next(0, names.Count);
            double randomNumberForChanceToBuy = rng.NextDouble();
            int randomNumberForThirstLevel = rng.Next(0, 11);
            int randomNumberForLikeLemonade = rng.Next(0, 11);
            int randomNumberForPriceOfLemonade = rng.Next(0, 11);
            int randomNumberForLikeLemon = rng.Next(0, 2);
            int randomNumberForLikeSugar = rng.Next(0, 2);
            int randomNumberForCareMoney = rng.Next(0, 2);

            if (dailyweather.dailyTemperature >= 90 && dailyweather.dailyTemperature <= 110 || dailyweather.dailyForecast == WeatherTypes.Sunny && dailyweather.dailyForecast == WeatherTypes.PartlySunny){
                randomNumberForThirstLevel += 3;
                randomNumberForLikeLemonade += 3;
            }
            else if (dailyweather.dailyTemperature >= 70 && dailyweather.dailyTemperature <= 89 || dailyweather.dailyForecast == WeatherTypes.Hazy && dailyweather.dailyForecast == WeatherTypes.Cloudy){
                randomNumberForThirstLevel += 2;
                randomNumberForLikeLemonade += 2;
            }

            if (randomNumberForThirstLevel >= 5) {
                isThirsty = true;
                randomNumberForChanceToBuy += 0.1;
            } 
            else {
                isThirsty = false;
                randomNumberForChanceToBuy -= 0.1;
            }

            if (randomNumberForLikeLemonade >= 5) {
                likeLemonade = true;
                randomNumberForChanceToBuy += 0.1;
            } 
            else {
                likeLemonade = false;
                randomNumberForChanceToBuy -= 0.1;
            }

            if (randomNumberForCareMoney == 1) {
                caresAboutMoney = true;
            }
            else {
                caresAboutMoney = false;
            }
            
            if (caresAboutMoney) {
                if (pricePerCup > 30 && pricePerCup <= 40) {
                    randomNumberForChanceToBuy -= 0.1;
                }
                else if (pricePerCup > 40 && pricePerCup <= 50) {
                    randomNumberForChanceToBuy -= 0.2;
                }
                else if (pricePerCup > 50) {
                    randomNumberForChanceToBuy -= 0.3;
                }
                else if (pricePerCup < 20 && pricePerCup >= 10) {
                    randomNumberForChanceToBuy += 0.2;
                }
                else if (pricePerCup < 10) {
                    randomNumberForChanceToBuy += 0.3;
                }
            }

            if (randomNumberForLikeLemon == 1) {
                likeLemon = true;
            }
            else {
                likeLemon = false;
            }

            if (randomNumberForLikeSugar == 1) {
                likeSugar = true;
            }
            else {
                likeSugar = false;
            }
            
            if (likeLemon && amountOfLemon >= 5) {
                randomNumberForChanceToBuy += 0.1;
            }
            else if (likeLemon && amountOfLemon < 5) {
                randomNumberForChanceToBuy -= 0.1;
            }
            else if (!likeLemon && amountOfLemon >= 5) {
                randomNumberForChanceToBuy -= 0.1;
            }
            else if (!likeLemon && amountOfLemon < 5){
                randomNumberForChanceToBuy += 0.1;
            }
            
            if (likeSugar && amountOfSugar >= 5) {
                randomNumberForChanceToBuy += 0.1;
            }
            else if (likeSugar && amountOfSugar < 5) {
                randomNumberForChanceToBuy -= 0.1;
            }
            else if (!likeSugar && amountOfSugar >= 5) {
                randomNumberForChanceToBuy -= 0.1;
            }
            else if (!likeSugar && amountOfSugar < 5){
                randomNumberForChanceToBuy += 0.1;
            }

            if (dailyweather.dailyTemperature >= 80 && amountOfIce < 5) {
                randomNumberForChanceToBuy -= 0.1;
            }
            else if (dailyweather.dailyTemperature >= 80 && amountOfIce >=5) {
                randomNumberForChanceToBuy += 0.1;
            }

            customer = new Customer(names[randomNumberForName], randomNumberForChanceToBuy, isThirsty, likeLemonade);
            Customers.Add(customer);
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