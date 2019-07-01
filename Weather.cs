using System;

namespace lemonadeStandGame
{
    public class Weather
    {
        // Member variables
        public WeatherTypes dailyForecast {get; set;}
        public int dailyTemperature {get; set;}
        private Random rng;

        // Constructor
        public Weather(){
            rng = new Random();
        }

        // Member Methods
        public void SetRandomWeather()
        {
            var randomNumber = rng.Next(0, 6);
            dailyForecast = (WeatherTypes)randomNumber;
        }

        public void SetRandomTemperature()
        {
            var randomNumber = rng.Next(50, 100);
            dailyTemperature = randomNumber;
        }

        public void SetDailyWeather()
        {
            SetRandomTemperature();
            SetRandomWeather();
        }
    }
}