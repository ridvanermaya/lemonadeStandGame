using System;

namespace lemonadeStandGame
{
    public class Weather
    {
        // Member variables
        public WeatherTypes currentForecast {get; set;}
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
            currentForecast = (WeatherTypes)randomNumber;
        }

        public void SetRandomTemperature()
        {
            var randomNumber = rng.Next(50, 100);
            currentTemperature = randomNumber;
        }
    }
}