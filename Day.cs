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
            int randomNumberFour = rng.Next(0, 2);
            int randomNumberFive = rng.Next(0, 2);
            if (randomNumberFour == 1) {
                isThirsty = true;
            } 
            else {
                isThirsty = false;
            }
            if (randomNumberFive == 1) {
                likeLemonade = true;
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