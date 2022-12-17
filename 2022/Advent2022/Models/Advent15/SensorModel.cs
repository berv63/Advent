namespace Advent2022.Models.Advent15;

public class SensorModel
{
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }
    
    public BeaconModel ClosestBeacon { get; set; }

    public int? MinXImpossibleAtY { get; set; }
    public int? MaxXImpossibleAtY { get; set; }
    
    public SensorModel(string data, List<BeaconModel> existingBeacons)
    {
        var firstXY = data.Split(":").First().Split(",");
        XCoordinate = int.Parse(firstXY.First().Split("=").Last());
        YCoordinate = int.Parse(firstXY.Last().Split("=").Last());
        
        var secondXY = data.Split(":").Last().Split(",");
        var x = int.Parse(secondXY.First().Split("=").Last());
        var y = int.Parse(secondXY.Last().Split("=").Last());

        if (existingBeacons.Any(beacon => beacon.XCoordinate == x && beacon.YCoordinate == y))
            ClosestBeacon = existingBeacons.Single(beacon => beacon.XCoordinate == x && beacon.YCoordinate == y);
        else
        {
            ClosestBeacon = new BeaconModel(existingBeacons.Count + 1, x, y);
            existingBeacons.Add(ClosestBeacon);
        }
    }

    public int GetClosestBeaconDistance()
    {
        return Math.Abs(YCoordinate - ClosestBeacon.YCoordinate) + Math.Abs(XCoordinate - ClosestBeacon.XCoordinate);
    }

    public List<int> GetImpossibleBeaconLocations(int y)
    {
        if (GetDistanceToY(y) > GetClosestBeaconDistance())
            return new List<int>();
        
        var minX = XCoordinate - (GetClosestBeaconDistance() - GetDistanceToY(y));
        var maxX = XCoordinate + (GetClosestBeaconDistance() - GetDistanceToY(y));

        var result = new List<int>();
        for (var i = minX; i <= maxX; i++)
        {
            result.Add(i);
        }

        return result;
    }
    
    public void SetImpossibleBeaconLocationsForRow(int y)
    {
        if (GetDistanceToY(y) > GetClosestBeaconDistance())
        {
            MinXImpossibleAtY = null;
            MaxXImpossibleAtY = null;
            return;
        }
        
        MinXImpossibleAtY = XCoordinate - (GetClosestBeaconDistance() - GetDistanceToY(y));
        MaxXImpossibleAtY = XCoordinate + (GetClosestBeaconDistance() - GetDistanceToY(y));

        if (MinXImpossibleAtY < 0)
            MinXImpossibleAtY = 0;
    }

    public bool DoImpossibleLocationsFullyInclude(SensorModel sensorCompare)
    {
        return sensorCompare.MinXImpossibleAtY <= MaxXImpossibleAtY && sensorCompare.MaxXImpossibleAtY <= MaxXImpossibleAtY;
    }

    public bool DoImpossibleLocationsButtOrOverlap(SensorModel sensorCompare)
    {
        return sensorCompare.MinXImpossibleAtY <= (MaxXImpossibleAtY + 1);
    }

    private int GetDistanceToY(int y)
    {
        return Math.Abs(YCoordinate - y);
    }
    
    
}