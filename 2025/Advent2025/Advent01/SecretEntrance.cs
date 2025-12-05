namespace Advent2025.Advent01;

public class SecretEntrance
{
    public int TimesZero(List<string> input)
    {
        var currentSum = 50;
        var countZero = 0;
        
        foreach (var line in input)
        {
            var direction = new Direction(line);
            if (direction.Rotation == 'L')
            {
                currentSum -= direction.Distance;
            }
            else if (direction.Rotation == 'R')
            {
                currentSum += direction.Distance;
            }
            
            currentSum %= 100;
            
            if (currentSum == 0)
            {
                countZero++;
            }
        }
        
        return countZero;
    }
    
    public int ClicksZero(List<string> input)
    {
        var currentSum = 50;
        var directions = input.Select(x => new Direction(x)).ToList();
        return directions.Sum(direction => direction.GetZeroClicks(ref currentSum));
    }
}