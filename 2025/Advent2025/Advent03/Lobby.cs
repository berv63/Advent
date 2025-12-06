namespace Advent2025.Advent03;

public class Lobby
{
    public int TotalSumJoltage(List<string> input)
    {
        var banks = input.Select(x => new Bank(x));
        return banks.Sum(x => x.GetJoltage());
    }
    
    public long TotalSumNewJoltage(List<string> input)
    {
        var banks = input.Select(x => new Bank(x));
        return banks.Sum(x => x.GetNewJoltage());
    }
}