namespace Advent2025.Advent01;

public class Direction
{
    public char Rotation { get; set; }
    public int Distance { get; set; }

    public Direction(string line)
    {
        Rotation = line[0];
        Distance = int.Parse(line[1..]);
    }

    public int GetZeroClicks(ref int currentValue)
    {
        var countZero = 0;
        for (int i = 0; i < Distance; i++)
        {
            if (Rotation == 'L')
            {
                currentValue--;
            }
            else if (Rotation == 'R')
            {
                currentValue++;
            }
            
            currentValue %= 100;
            if (currentValue == 0)
            {
                countZero++;
            }
        }

        return countZero;
    }
}