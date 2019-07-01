namespace lemonadeStandGame
{
    public class Inventory
    {
        // member variables
        public int paperCups {get; set;}
        public int lemons {get; set;}
        public int cupsOfSugar {get; set;}
        public int iceCubes {get; set;}

        // constructor
        public Inventory()
        {
            paperCups = 0;
            lemons = 0;
            cupsOfSugar = 0;
            iceCubes = 0;
        }

        // member methods
        public void AddPaperCups(int boughtPaperCups)
        {
            paperCups += boughtPaperCups;
        }

        public void RemovePaperCups(int soldPaperCups)
        {
            paperCups -= soldPaperCups;
        }

        public void AddLemons(int boughtLemons)
        {
            lemons += boughtLemons;
        }

        public void RemoveLemons(int soldLemons)
        {
            lemons -= soldLemons;
        }

        public void AddCupsOfSugar(int boughtCupsOfSugar)
        {
            cupsOfSugar += boughtCupsOfSugar;
        }

        public void RemoveCupsOfSugar(int soldCupsOfSugar)
        {
            cupsOfSugar -= soldCupsOfSugar;
        }

        public void AddIceCubes(int boughtIceCubes)
        {
            iceCubes += boughtIceCubes;
        }

        public void RemoveIceCubes(int soldIceCubes)
        {
            iceCubes -= soldIceCubes;
        }
    }
}