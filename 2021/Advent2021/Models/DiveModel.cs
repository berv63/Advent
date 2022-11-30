using System;

namespace Advent2021.Models
{
    public class DiveModel
    {
        public DirectionEnum Direction { get; set; }
        public int Distance { get; set; }

        public DiveModel(string input)
        {
            var splitInput = input.Split(' ');
            
            this.Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), splitInput[0]);
            this.Distance = int.Parse(splitInput[1]);
        }
    }

    public enum DirectionEnum
    {
        forward,
        down,
        up
    }
}