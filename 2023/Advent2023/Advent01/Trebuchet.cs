using AdventShared;

namespace Advent2023;

public class Trebuchet
{
    private List<string> NumberedStrings { get; } = new();

    public int Sum
    {
        get {
            return NumberedStrings.Select(x => int.Parse($"{x.First()}{x.Last()}")).Sum();
        }
    }

    public void Calibrate(List<string> input)
    {
        foreach (var line in input)
        {
            ConvertLineToNumbersOnly(line, false);
        }
    }

    public void CalibrateIncludingSpelledOutNumbers(List<string> input)
    {
        foreach (var line in input)
        {
            ConvertLineToNumbersOnly(line, true);
        }
    }

    private void ConvertLineToNumbersOnly(string line, bool includeLettersAsNumbers)
    {
        var numberedInput = "";
        for (var i = 0; i < line.Length; i++)
        {
            if (IsInteger(line[i]))
            {
                AppendNumberToNumberedInput(i, line, ref numberedInput);
            }
            else if (includeLettersAsNumbers && IsStartOfIntegerSpelledOut(i, line, out var number))
            {
                AppendStringNumberAsNumberToNumberedInput(number, ref numberedInput);
                i = JumpIndexToSecondToLastLetterOfFoundNumberString(i, number);
            }
        }
        NumberedStrings.Add(numberedInput);
    }

    private void AppendNumberToNumberedInput(int index, string line, ref string numberedInput)
    {
        numberedInput += line[index];
    }

    private void AppendStringNumberAsNumberToNumberedInput(string number, ref string numberedInput)
    {
        numberedInput += AlphaNumberMap.Map[number];
    }

    private bool IsInteger(char character)
    {
        return int.TryParse(character.ToString(), out _);
    }

    private bool IsStartOfIntegerSpelledOut(int index, string line, out string number)
    {
        number = AlphaNumberMap.Map.Keys.FirstOrDefault(key => line.Substring(index).StartsWith(key));
        return number != null;
    }

    // This is a bit of a hack, but it works for the given input due to the last letter of eight being the first letter of two.
    // this will cause both eight to convert to 8 and two to convert to 2. The instructions arent clear if this is desired or not.
    // It seems to be acceptable as no cases have this as the only number input so it is an edge case that is not validated by the input data.
    private int JumpIndexToSecondToLastLetterOfFoundNumberString(int index, string number)
    {
        return index + number.Length - 2;
    }
}
