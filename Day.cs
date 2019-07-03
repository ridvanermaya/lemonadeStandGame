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
            GenerateDailyCustomers();
        }
        // member methods
        public void GenerateRandomCustomer() 
        {
            bool isThirsty;
            bool likeLemonade;
            int randomNumberOne = rng.Next(0, names.Count);
            int randomNumberTwo = rng.Next(0, names.Count);
            double randomNumberThree = rng.NextDouble();
            int randomNumberFour = rng.Next(0, 11);
            int randomNumberFive = rng.Next(0, 11);
            if (dailyweather.dailyTemperature >= 76 && dailyweather.dailyTemperature <= 110 || dailyweather.dailyForecast == WeatherTypes.Sunny && dailyweather.dailyForecast == WeatherTypes.PartlySunny){
                randomNumberFour += 2;
                randomNumberFive += 2;
            }
            else if (dailyweather.dailyTemperature >= 61 && dailyweather.dailyTemperature <= 75 || dailyweather.dailyForecast == WeatherTypes.Hazy && dailyweather.dailyForecast == WeatherTypes.Cloudy){
                randomNumberFour += 1;
                randomNumberFive += 1;
            }

            if (randomNumberFour >= 5) {
                isThirsty = true;
                randomNumberThree += 0.1;
            } 
            else {
                isThirsty = false;
            }
            if (randomNumberFive >= 5) {
                likeLemonade = true;
                randomNumberThree += 0.1;
            } 
            else {
                likeLemonade = false;
            }
            
            customer = new Customer(names[randomNumberOne], randomNumberThree, isThirsty, likeLemonade);
            Customers.Add(customer);
        }

        public void GenerateDailyCustomers() 
        {
            int count = 0;
            int randomNumber = rng.Next(80, 120);
            while (count < randomNumber){
                GenerateRandomCustomer();
                count++;
                Console.WriteLine("");
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