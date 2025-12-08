using AdventShared;
using Range = Advent2025.Advent05.Range;

namespace Advent2025.Advent06;

public class Trash
{
    public long MathGrandTotal(List<string> input)
    {
        var trimmedInputs = input.Select(x => x.Split(' ').Where(y => !string.IsNullOrWhiteSpace(y)).ToList()).ToList();
        
        var equations = new List<Equation>();
        for (var i = 0; i < trimmedInputs[0].Count(); i++)
        {
            var values = new List<int>();
            for (var j = 0; j < trimmedInputs.Count() - 1; j++)
            {
                values.Add(int.Parse(trimmedInputs[j][i]));
            }
            var op = trimmedInputs[^1][i][0];
            equations.Add(new Equation(op, values.ToArray()));
        }
        
        return equations.Sum(x => x.SolveEquation());
    }
    
    public long VertMathGrandTotal(List<string> input)
    {
        var trimmedInputs = input.Select(x => x.ToList()).ToList().RotateMap().RotateMap().RotateMap().Select(x => string.Join("", x)).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        
        var equations = new List<Equation>();
        var values = new List<int>();
        foreach (var row in trimmedInputs)
        {
            var valueString = row.Substring(0, row.Length - 1).Trim();
            var value = int.Parse(valueString);
            values.Add(value);
            
            if (IsOperatorRow(row))
            {
                equations.Add(new Equation(row[row.Length - 1], values.ToArray()));
                values = new List<int>();
            }
        }

        return equations.Sum(x => x.SolveEquation());
    }
    
    private bool IsOperatorRow(string value)
    {
        return value.Contains('+') || value.Contains('*');
    }
}