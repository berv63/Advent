namespace Advent2023.Advent04;

public class ScratchCards
{
    private List<Card> Cards { get; } = new();

    public ScratchCards(List<string> cardsInput)
    {
        foreach (var cardInput in cardsInput)
        {
            Cards.Add(new Card(cardInput));
        }
    }

    public int GetPointsTotal()
    {
        return Cards.Sum(x => x.Score);
    }

    public int GetCardCount()
    {
        foreach (var card in Cards)
        {
            card.PopulateChildCards(Cards);
        }

        foreach (var card in Cards)
        {
            card.PopulateCopiesAccountedFor();
        }

        return Cards.Sum(x => x.CopiesAccountedFor!.Value);
    }
}
