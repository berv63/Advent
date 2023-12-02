namespace Advent2023.Advent02;

public class CubeConundrum
{
    private List<Game> Games { get; set; } = new();

    public void PlayGames(List<string> gamesInput)
    {
        foreach (var input in gamesInput)
        {
            var game = new Game();
            game.Play(input);
            Games.Add(game);
        }
    }

    public int GetPossibleGamesSum(int red, int green, int blue)
    {
        return Games.Where(x => x.IsPossible(red, green, blue)).Sum(x => x.GameNumber);
    }

    public int GetMinimumDrawPowerSum()
    {
        return Games.Select(x => x.RequiredMinimumDraw.Power).Sum();
    }
}
