namespace Advent2025.Advent06;

public class Equation
{
    public List<int> Values { get; set; }
    public char Operator { get; set;  }

    public Equation(char op, params int[] values)
    {
        Values = values.ToList();
        Operator = op;
    }
    
    public long SolveEquation()
    {
        var result = Operator switch
        {
            '+' => Values.Sum(),
            '*' => MultiplyValues(),
            _ => throw new NotImplementedException($"Operator {Operator} not implemented")
        };
        return result;
    }
    
    private long MultiplyValues()
    {
        long product = 1;
        foreach (var value in Values)
        {
            product *= value;
        }
        return product;
    }
}