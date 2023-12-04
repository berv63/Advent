﻿namespace Advent2023.Advent04;

public class Card
{
    private int CardNumber => GetCardNumber();
    private IEnumerable<int> WinningNumbers => GetWinningNumbers();
    private IEnumerable<int> OwnedNumbers => GetOwnedNumbers();

    private List<Card> _childCards = new();

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
        var matchCount = GetMatchCount();
        return matchCount == 0 ? 0 : (int)Math.Pow(2, matchCount - 1);
    }

    private int GetMatchCount()
    {
        return OwnedNumbers.Count(owned => WinningNumbers.Contains(owned));
    }

    public void PopulateChildCards(List<Card> cards)
    {
        var matchCount = GetMatchCount();
        if (matchCount == 0) return;

        _childCards = GetNextNCards(cards, matchCount);
    }

    private List<Card> GetNextNCards(List<Card> cards, int n)
    {
        return cards.Where(x => x.CardNumber > CardNumber && x.CardNumber <= CardNumber + n).ToList();
    }

    //Recursion
    public void PopulateCopiesAccountedFor()
    {
        const int selfCount = 1;
        if (_childCards.Count == 0)
        {
            CopiesAccountedFor = selfCount;
            return;
        }

        PopulateChildCopiesAccountedFor();
        CopiesAccountedFor ??= _childCards.Sum(x => x.CopiesAccountedFor) + selfCount;
    }

    private void PopulateChildCopiesAccountedFor()
    {
        foreach (var card in _childCards)
        {
            card.PopulateCopiesAccountedFor();
        }
    }
}
