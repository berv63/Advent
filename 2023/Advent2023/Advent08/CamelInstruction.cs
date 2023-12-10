namespace Advent2023.Advent08;

public class CamelInstruction
{
    public string Value { get; set; }
    public int Index { get; set; }

    public CamelInstruction(string input)
    {
        Value = input;
        Index = 0;
    }

    public char GetCurrentDirection()
    {
        return Value[Index++ % Value.Length];
    }
}
