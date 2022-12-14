using Advent2022.Models.Advent12;

namespace Advent2022;

public static class HillClimbing
{
    public static List<HillClimbModel> BuildHillClimbModels(List<string> fileData)
    {
        var hills = new List<List<HillClimbModel>>();
        for (int i = 0; i < fileData.Count; i++)
        {
            hills.Add(new List<HillClimbModel>());
            for (int j = 0; j < fileData[i].Length; j++)
            {
                hills[i].Add(new HillClimbModel(fileData[i][j]));
            }
        }
        
        return MapHills(hills);;
    }

    private static List<HillClimbModel> MapHills(List<List<HillClimbModel>> hills)
    {
        for (var i = 0; i < hills.Count; i++)
        {
            for (var j = 0; j < hills[i].Count; j++)
            {
                if (i > 0)
                {
                    hills[i][j].Up = hills[i - 1][j];
                }
                if (i < hills.Count - 1)
                {
                    hills[i][j].Down = hills[i + 1][j];
                }
                
                if (j > 0)
                {
                    hills[i][j].Left = hills[i][j - 1];
                }
                if (j < hills[i].Count - 1)
                {
                    hills[i][j].Right = hills[i][j+1];
                }
            }
        }

        return hills.SelectMany(x => x).ToList();
    }

    public static int ClimbFromStartToEnd(List<HillClimbModel> hills)
    {
        var startHill = hills.Single(x => x.IsStartValue);
        startHill.MoveToAllPassableNeighbors(0);
        return hills.Single(x => x.IsEndValue).ShortestDistance;
    }

    public static long ClimbFromAllStartToEnd(List<HillClimbModel> hills)
    {
        foreach (var startHill in hills.Where(x => x.Height == 0))
        {
            startHill.MoveToAllPassableNeighbors(0);
        }
        
        return hills.Single(x => x.IsEndValue).ShortestDistance;
    }
}