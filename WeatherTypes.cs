namespace lemonadeStandGame
{
    // SOLID DESIGN PRINCIPLES USED
    // This enumerator is only designed for weather class and serves only one function
    // providing weather types for weather class
    // Instead of having each type in a list as string, this enum is giving me an easy way
    // to access weathe types
    public enum WeatherTypes
    {
        Sunny,
        Cloudy,
        Thunderstorm,
        PartlySunny,
        Hazy,
        Overcast,
    }
}