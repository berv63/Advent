namespace Advent2023.Advent04;

public class Card
{
    private int CardNumber => GetCardNumber();
    private IEnumerable<int> WinningNumbers => GetWinningNumbers();
    private IEnumerable<int> OwnedNumbers => GetOwnedNumbers();

    private int? _matchCount { get; set; }
    private int MatchCount => _matchCount ?? GetMatchCount();

    private List<Card> _childCards = new();
    public bool HasBeenPopulated = false;

    public int Score => GetScore();

    public int? CopiesAccountedFor { get; private set; }

    private string CardInput { get; }

    public Card(string cardInput)
    {
        CardInput = cardInput;
    }

    private int GetCardNumber()
    {
        return int.Parse(CardInput.Split(":").First().Split(" ").Last());
    }

    private IEnumerable<int> GetWinningNumbers()
    {
        return CardInput.Split(":").Last().Split("|").First().Split(" ").Where(x => x != "").Select(int.Parse).ToList();
    }

    private IEnumerable<int> GetOwnedNumbers()
    {
        return CardInput.Split(":").Last().Split("|").Last().Split(" ").Where(x => x != "").Select(int.Parse).ToList();
    }

    private int GetScore()
    {
        return MatchCount == 0 ? 0 : (int)Math.Pow(2, MatchCount - 1);
    }

    private int GetMatchCount()
    {
        _matchCount = OwnedNumbers.Count(owned => WinningNumbers.Contains(owned));
        return _matchCount.Value;
    }

    public void PopulateChildCards(IEnumerable<Card> cards)
    {
        if (MatchCount == 0) return;
        _childCards = GetNextNCards(cards, MatchCount);
    }

    private List<Card> GetNextNCards(IEnumerable<Card> cards, int n)
    {
        return cards.Where(x => x.CardNumber > CardNumber && x.CardNumber <= CardNumber + n).ToList();
    }

    //Recursion
    public void PopulateCopiesAccountedFor()
    {
        const int selfCount = 1;
        if (_childCards.Count == 0)
        {
            HasBeenPopulated = true;
            CopiesAccountedFor = selfCount;
            return;
        }

        PopulateChildCopiesAccountedFor();
        CopiesAccountedFor ??= _childCards.Sum(x => x.CopiesAccountedFor) + selfCount;
        HasBeenPopulated = true;
    }

    private void PopulateChildCopiesAccountedFor()
    {
        foreach (var card in _childCards.Where(x => !x.HasBeenPopulated))
        {
            card.PopulateCopiesAccountedFor();
        }
    }
}
