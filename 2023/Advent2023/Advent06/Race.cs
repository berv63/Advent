namespace Advent2023.Advent06;

public class Race
{
    private long Time { get; set; }
    private long RecordDistance { get; set; }

    public List<int> WinningButtonHoldLengths { get; set; } = new();

    public Race(long time, long distance)
    {
        Time = time;
        RecordDistance = distance;
    }

    public void CalculateWinningButtonHoldLengths()
    {
        for (int i = 0; i <= Time; i++)
        {
            var distance = i * (Time - i);

            if (distance > RecordDistance)
            {
                WinningButtonHoldLengths.Add(i);
            }
        }
    }
}
