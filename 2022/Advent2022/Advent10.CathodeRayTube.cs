using System.Data;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Advent2022.Models;
using Advent2022.Models.Advent10;
using AdventShared;

namespace Advent2022;

public static class CathodeRayTube
{
    private static Dictionary<string, int> CommandToTicks = new()
    {
        {"noop", 1},
        {"addx", 2},
    };

    public static List<Tuple<int, int>> BuildCommands(List<string> fileData)
    {
        return fileData.Select(GetCommand).ToList();
    }

    private static Tuple<int, int> GetCommand(string data)
    {
        var dataSplit = data.Split(" ");
        if (dataSplit.Length == 2)
            return new Tuple<int, int>(CommandToTicks[dataSplit.First()], int.Parse(dataSplit.Last()));
        else
            return new Tuple<int, int>(CommandToTicks[dataSplit.First()], 0);
    }

    public static int GetIntervals(List<Tuple<int, int>> commands)
    {
        var result = new List<int>();
        for (int i = 20; i <= 220; i+=40)
        {
            result.Add(i * new CRTModel().GetCountAt(commands, i));
        }

        return result.Sum();
    }

    public static void RunCRT(List<Tuple<int, int>> commands)
    {
        var crt = new CRTModel();
        crt.PopulateCRTScreen(commands);
        crt.PrintCRT();
    }
}