using System;

namespace Advent2021.Models
{
    public class ReactorRebootInstructionModel
    {
        public int MinX { get; set; }
        public int MaxX { get; set; }
        
        public int MinY { get; set; }
        public int MaxY { get; set; }
        
        public int MinZ { get; set; }
        public int MaxZ { get; set; }
        
        public bool OnOff { get; set; }
        
        public ReactorRebootInstructionModel(string instruction)
        {
            //on x=-20..26,y=-36..17,z=-47..7
            var actionCoordSplit = instruction.Split(' ');
            OnOff = actionCoordSplit[0].ToLower() == "on";

            var axisSplit = actionCoordSplit[1].Split(',');
            foreach (var axis in axisSplit)
            {
                var axisCoordSplit = axis.Split('=');
                var coordSplit = axisCoordSplit[1].Split('.');
                switch (axisCoordSplit[0])
                {
                    case "x":
                        MinX = int.Parse(coordSplit[0]);
                        MaxX = int.Parse(coordSplit[2]);
                        break;
                    case "y":
                        MinY = int.Parse(coordSplit[0]);
                        MaxY = int.Parse(coordSplit[2]);
                        break;
                    case "z":
                        MinZ = int.Parse(coordSplit[0]);
                        MaxZ = int.Parse(coordSplit[2]);
                        break;
                }
            }
        }
    }
}