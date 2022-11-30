namespace Advent2021.Models
{
    public class DumboOctopusModel
    {
        public int EnergyLevel { get; set; }
        public bool Flashed { get; set; }
        
        public  DumboOctopusModel(char energyLevel)
        {
            EnergyLevel = int.Parse(energyLevel.ToString());
        }
    }
}