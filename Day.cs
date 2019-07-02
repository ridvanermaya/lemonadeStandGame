using System;
using System.Collections.Generic;

namespace lemonadeStandGame
{
    public class Day
    {
        // member variables
        public Weather dailyweather;
        public List<string> names;
        public Customer customer;
        public Random rng;

        // constructor
        public Day()
        {
            dailyweather = new Weather();
            names = new List<string>();
            rng = new Random();
            AddNames();
        }
        // member methods
        public void GenerateRandomCustomer() 
        {
            int randonNumber = rng.Next(0, names.Count);
            customer = new Customer();
            customer.name = names[randonNumber];
            Console.WriteLine(customer.name);
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