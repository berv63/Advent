namespace Advent2022.Models.Advent09
{
    public class CoordinatesModel
    {
        public int Index { get; set; }
        
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public string DirectionMoved { get; set; } = "";

        public CoordinatesModel(int index, int xCoord, int yCoord)
        {
            Index = index;
            
            XCoordinate = xCoord;
            YCoordinate = yCoord;
        }
    }
}