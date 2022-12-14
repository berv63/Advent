using System.Runtime.CompilerServices;

namespace Advent2022.Models.Advent14;

public class RockCoordinates
{
    public int XCoord { get; set; }
    public int YCoord { get; set; }

    public RockCoordinates(string data)
    {
        XCoord = int.Parse(data.Split(",").First());
        YCoord = int.Parse(data.Split(",").Last());
    }
}