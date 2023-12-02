namespace Advent2023.Advent02;

public class Game
{
    public int GameNumber { get; set; }

    private List<CubeCount> DrawCounts { get; set; } = new();

    public CubeCount RequiredMinimumDraw => new()
    {
        RedCount = DrawCounts.Max(x => x.RedCount),
        GreenCount = DrawCounts.Max(x => x.GreenCount),
        BlueCount = DrawCounts.Max(x => x.BlueCount)
    };

    public void Play(string game)
    {
        var gameSplit = game.Split(":");
        SetGameNumber(gameSplit.First());
        AddDraws(gameSplit.Last());
    }

    private void SetGameNumber(string gameValue)
    {
        GameNumber = int.Parse(gameValue[5..]);
    }

    private void AddDraws(string drawList)
    {
        var draws = drawList.Split(";");
        foreach (var draw in draws)
        {
            AddDraw(draw);
        }
    }

    private void AddDraw(string draw)
    {
        var drawSplit = draw.Split(",").Select(x => x.Trim());
        var drawToAdd = new CubeCount
        {
            BlueCount = GetColorDraw(drawSplit, "blue"),
            RedCount = GetColorDraw(drawSplit, "red"),
            GreenCount = GetColorDraw(drawSplit, "green")
        };
        DrawCounts.Add(drawToAdd);
    }

    private int GetColorDraw(IEnumerable<string> drawSplit, string color)
    {
        var blueDraw = drawSplit.SingleOrDefault(x => x.Contains(color));
        return blueDraw == null ? 0 : int.Parse(blueDraw.Split(" ").First());
    }

    public bool IsPossible(int red, int green, int blue)
    {
        return DrawCounts.All(x => x.RedCount <= red) &&
               DrawCounts.All(x => x.GreenCount <= green) &&
               DrawCounts.All(x => x.BlueCount <= blue);
    }
}
