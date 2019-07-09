using System;

namespace lemonadeStandGame
{
    // SOLID DESIGN PRINCIPLE USED
    // This class is used to collaborate with Inventory class
    // Since the inventory class will need a pitcher, I needed to add a pitcher
    // Instead of creating a pitcher in the inventory class, I created a class for pitcher only
    // and add this to my inventory as another item in it.
    // The reason I wanted to do it this way is that this makes my code easier to read since
    // pitcher has its own member variable(s)
    public class Pitcher
    {
        // member variables (has a)
        public int cupsInPitcher;

        // constructor
        public Pitcher()
        {
            cupsInPitcher = 0;
        }

        // member methods
    }
}