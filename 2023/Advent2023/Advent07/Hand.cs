namespace Advent2023.Advent07;

public class Hand
{
    public string HandValue { get; set; }
    private int Bid { get; set; }

    public int Rank { get; set; }

    public HandType Type { get; set; }

    public string HandOutput => $"{HandValue} {Type.ToString()} {Rank}";

    public Hand(string input, bool hasJokers)
    {
        HandValue = input.Split(" ").First();
        Bid = int.Parse(input.Split(" ").Last());
        Type = hasJokers ? GetHandStrengthWithJokers() : GetHandStrengthWithoutJokers();
    }

    private HandType GetHandStrengthWithJokers()
    {
        var counts = GetCharacterCounts();
        if (HandValue.All(x => x != 'J'))
        {
            return GetHandStrength(counts);
        }
        if (HandValue.All(x => x == 'J'))
        {
            return HandType.FiveOfAKind;
        }

        var highestNonJokerCount = counts.Where(x => x.Key != 'J').Max(x => x.Value);
        var highestNonJokerItem = counts.First(x => x.Key != 'J' && x.Value == highestNonJokerCount);
        var jokerCount = counts.Single(x => x.Key == 'J').Value;

        counts[highestNonJokerItem.Key] += jokerCount;
        counts['J'] = 0;
        return GetHandStrength(counts);
    }

    private HandType GetHandStrengthWithoutJokers()
    {
        var counts = GetCharacterCounts();
        return GetHandStrength(counts);
    }

    private HandType GetHandStrength(Dictionary<char, int> counts)
    {
        if (HasXOfAKindCount(counts, 5, 1))
        {
            return HandType.FiveOfAKind;
        }
        if (HasXOfAKindCount(counts, 4, 1))
        {
            return HandType.FourOfAKind;
        }
        if (HasXOfAKindCount(counts, 2, 1) && HasXOfAKindCount(counts, 3, 1))
        {
            return HandType.FullHouse;
        }
        if (HasXOfAKindCount(counts, 3, 1))
        {
            return HandType.ThreeOfAKind;
        }
        if (HasXOfAKindCount(counts, 2, 2))
        {
            return HandType.TwoPair;
        }
        if (HasXOfAKindCount(counts, 2, 1))
        {
            return HandType.OnePair;
        }
        return HandType.HighCard;
    }

    private Dictionary<char, int> GetCharacterCounts()
    {
        var values = new Dictionary<char, int>();
        foreach (var character in HandValue)
        {
            if (values.ContainsKey(character))
            {
                values[character] += 1;
            }
            else
            {
                values.Add(character, 1);
            }
        }
        return values;
    }

    private bool HasXOfAKindCount(Dictionary<char, int> values, int x, int count)
    {
        return values.Count(y => y.Value == x) == count;
    }

    public int GetPayout(int rank)
    {
        Rank = rank;
        return Rank * Bid;
    }
}
