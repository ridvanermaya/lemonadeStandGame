using System;

namespace lemonadeStandGame
{
    public class Weather
    {
        // Member variables
        public string currentForecast {get; set;}
        public int currentTemperature {get; set;}
        private Random rng;

        // Constructor
        public Weather(){
            rng = new Random();
        }

        // Member Methods
        public void SetRandomWeather()
        {
            var randomNumber = rng.Next(0, 7);
            WeatherTypes currentForecast = (WeatherTypes)randomNumber;
            Console.WriteLine(currentForecast);
        }
    }
}