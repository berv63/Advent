using System.Linq;

namespace Advent2021.Models
{
    public class HydroDirectionModel
    {
        public int StartX { get; set; }
        public int EndX { get; set; }
        public int StartY { get; set; }
        public int EndY { get; set; }
        
        public VentDirectionEnum Direction { get; set; }

        public HydroDirectionModel(string row)
        {
            var instructions = row.Split(' ').Where(x => x != "->").ToList();
            var start = instructions[0].Split(',');
            StartX = int.Parse(start[0]);
            StartY = int.Parse(start[1]);
            
            var end = instructions[1].Split(',');
            EndX = int.Parse(end[0]);
            EndY = int.Parse(end[1]);
            
            if (StartX == EndX)
            {
                Direction = VentDirectionEnum.horizontal;
                if (StartY > EndY)
                {
                    (EndY, StartY) = (StartY, EndY);
                }
            }
            else if (StartY == EndY)
            {
                Direction = VentDirectionEnum.vertical;
                if (StartX > EndX)
                {
                    (EndX, StartX) = (StartX, EndX);
                }
            }
            else
            {
                if (StartX > EndX)
                {
                    (EndX, StartX) = (StartX, EndX);
                    (EndY, StartY) = (StartY, EndY);
                }
                Direction = StartY > EndY ? VentDirectionEnum.diagonalUp : VentDirectionEnum.diagonalDown;
            }
        }
    }

    public enum VentDirectionEnum
    {
        diagonalUp,
        diagonalDown,
        horizontal,
        vertical,
    }
}