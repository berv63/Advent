namespace Advent2025.Advent03;

public class Bank
{
    public List<int> BankArray { get; set; } = new();

    public Bank(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            BankArray.Add(int.Parse(input[i].ToString()));
        }
    }

    public int GetJoltage()
    {
        var (largeValue, largeIndex) = GetValue(0, BankArray.Count - 1);
        var (secondValue, secondIndex) = GetValue(largeIndex + 1, BankArray.Count);
        
        var valueString = $"{largeValue}{secondValue}";
        return int.Parse(valueString);
    }
    
    public long GetNewJoltage()
    {
        var (firstValue, firstIndex) = GetValue(0, BankArray.Count - 11);
        var (secondValue, secondIndex) = GetValue(firstIndex + 1, BankArray.Count - 10);
        var (thirdValue, thirdIndex) = GetValue(secondIndex + 1, BankArray.Count - 9);
        var (forthValue, forthIndex) = GetValue(thirdIndex + 1, BankArray.Count - 8);
        var (fifthValue, fifthIndex) = GetValue(forthIndex + 1, BankArray.Count - 7);
        var (sixthValue, sixthIndex) = GetValue(fifthIndex + 1, BankArray.Count - 6);
        var (seventhValue, seventhIndex) = GetValue(sixthIndex + 1, BankArray.Count - 5);
        var (eighthValue, eighthIndex) = GetValue(seventhIndex + 1, BankArray.Count - 4);
        var (ninthValue, ninthIndex) = GetValue(eighthIndex + 1, BankArray.Count - 3);
        var (tenthValue, tenthIndex) = GetValue(ninthIndex + 1, BankArray.Count - 2);
        var (eleventhValue, eleventhIndex) = GetValue(tenthIndex + 1, BankArray.Count - 1);
        var (twelthValue, twelthIndex) = GetValue(eleventhIndex + 1, BankArray.Count);
        
        var valueString = $"{firstValue}{secondValue}{thirdValue}{forthValue}{fifthValue}{sixthValue}{seventhValue}{eighthValue}{ninthValue}{tenthValue}{eleventhValue}{twelthValue}";
        return long.Parse(valueString);
    }

    private (int, int) GetValue(int startIndex, int endIndex)
    {
        var value = 0;
        var index = 0;
        
        for (int i = startIndex; i < endIndex; i++)
        {
            if (BankArray[i] > value)
            {
                value = BankArray[i];
                index = i;
            }
        }

        return (value, index);
    }
}