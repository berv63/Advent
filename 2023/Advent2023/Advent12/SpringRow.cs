using AdventShared;

namespace Advent2023.Advent12;

public class SpringRow
{
    private string Springs { get; set; }
    private List<int> Checksum { get; set; }

    public List<string> Possibilities => GetValidPermutations();

    public SpringRow(string input)
    {
        Springs = input.Split(" ").First();
        Checksum = input.Split(" ").Last().Split(",").Select(int.Parse).ToList();
    }

    public void Unfold(int copies)
    {
        var newSpring = Springs;
        var newChecksum = Checksum.Copy();

        for (var i = 0; i < copies - 1; i++)
        {
            newSpring += $"?{Springs}";
            newChecksum.AddRange(Checksum);
        }

        Springs = newSpring;
        Checksum = newChecksum;
    }

    private List<string> GetValidPermutations()
    {
        var permutations = GetPermutations();
        var validPermutations = permutations.Where(IsValidChecksum).ToList();
        return validPermutations;
    }

    private IEnumerable<string> GetPermutations()
    {
        var brokenAllowance = GetUnknownCount();
        var permutations = new List<string>();
        GeneratePermutations("", Springs, brokenAllowance, permutations);
        return permutations;
    }

    private void GeneratePermutations(string currentValue, string remainingValues, int brokenAllowance, List<string> results)
    {
        var unknownIndex = remainingValues.IndexOf('?');
        if (unknownIndex == -1)
        {
            results.Add(currentValue + remainingValues);
            return;
        }
        if (brokenAllowance == 0)
        {
            currentValue += remainingValues.Replace("?", ".");
            results.Add(currentValue);
            return;
        }

        if (unknownIndex > 0)
        {
            currentValue += remainingValues.Substring(0, unknownIndex);
            remainingValues = remainingValues.Substring(unknownIndex);
        }

        GenerateBrokenPermutation(currentValue, remainingValues, brokenAllowance, results);
        GenerateNonbrokenPermutation(currentValue, remainingValues, brokenAllowance, results);
    }

    private void GenerateBrokenPermutation(string currentValue, string remainingValues, int brokenAllowance, List<string> results)
    {
        currentValue += "#";
        remainingValues = remainingValues.Substring(1);
        brokenAllowance -= 1;
        if (IsCurrentBrokenCountMoreThanChecksum(currentValue + remainingValues) || !IsValidPartialChecksum(currentValue))
        {
            return;
        }
        GeneratePermutations(currentValue, remainingValues, brokenAllowance, results);
    }

    private void GenerateNonbrokenPermutation(string currentValue, string remainingValues, int brokenAllowance, List<string> results)
    {
        currentValue += ".";
        remainingValues = remainingValues.Substring(1);
        if (IsCurrentBrokenCountMoreThanChecksum(currentValue + remainingValues) || !IsValidPartialChecksum(currentValue))
        {
            return;
        }
        GeneratePermutations(currentValue, remainingValues, brokenAllowance, results);
    }

    private int GetUnknownCount()
    {
        return Springs.Count(x => x == '?');
    }

    private bool IsCurrentBrokenCountMoreThanChecksum(string currentValue)
    {
        return currentValue.Count(x => x == '#') > Checksum.Sum();
    }

    private bool IsValidChecksum(string value)
    {
        var brokenSplit = value.Split(".").Where(x => !string.IsNullOrEmpty(x)).ToList();
        if (brokenSplit.Count != Checksum.Count) { return false; }

        return !Checksum.Where((length, index) => length != brokenSplit[index].Length).Any();
    }

    //.#.
    //1,1,3
    private bool IsValidPartialChecksum(string value)
    {
        var brokenSplit = value.Split(".").Where(x => !string.IsNullOrEmpty(x)).ToList();

        var isValid = true;
        for (int i = 0; i < brokenSplit.Count; i++)
        {
            if (Checksum.Count < brokenSplit.Count)
            {
                return false;
            }

            if (i == brokenSplit.Count - 1)
            {
                isValid = isValid && Checksum[i] >= brokenSplit[i].Length;
            }
            else
            {
                isValid = isValid && Checksum[i] == brokenSplit[i].Length;
            }
        }

        return isValid;
    }
}
