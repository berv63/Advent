using System;
using System.Collections.Generic;

namespace Advent2021.Models
{
    public class CoordinateModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public CoordinateModel(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    
    public class ScannerModel
    {
        public CoordinateModel CurrentScannerCoords { get; set; }
        public List<CoordinateModel> BeaconCoordinates { get; set; } = new List<CoordinateModel>();

        public ScannerModel(List<string> beaconCoords)
        {
            CurrentScannerCoords = new CoordinateModel(0, 0, 0);
            foreach (var beaconCoord in beaconCoords)
            {
                var coordSplit = beaconCoord.Split(',');
                BeaconCoordinates.Add(new CoordinateModel(int.Parse(coordSplit[0]), int.Parse(coordSplit[1]), int.Parse(coordSplit[2])));
            }
        }
    }
}