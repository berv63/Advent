using Advent2022.Models.Advent11;
using AdventShared;

namespace Advent2022;

public static class MonkeyMiddle
{
    public static List<MonkeyModel> BuildMonkeyModels(List<string> fileData)
    {
        var monkeys = new List<MonkeyModel>();
        do
        {
            monkeys.Add(new MonkeyModel(fileData.Take(6)));
            fileData.RemoveRange(0, fileData.Count > 6 ? 7 : 6);
        } while (fileData.Any());
        
        return monkeys;
    }

    public static void ProcessMonkeyMiddle(List<MonkeyModel> monkeys, int roundCount, bool performRelief)
    {
        var product = monkeys.Select(x => x.TestValue).ToList().GetCommonProduct();
        
        for (var i = 0; i < roundCount; i++)
        {
            foreach (var monkey in monkeys.OrderBy(x => x.Index))
            {
                while (monkey.Items.Any())
                {
                    monkey.InspectItemToThrow(product, performRelief);
                    
                    var throwIndex = monkey.GetThrowIndex();

                    var throwToMonkey = monkeys.Single(x => x.Index == throwIndex);
                    monkey.ThrowItem(throwToMonkey);
                }
            }
        }
    }

    public static long GetActiveMonkeyResult(List<MonkeyModel> monkeys)
    {
        var activeMonkeys = monkeys.OrderByDescending(x => x.ItemsInspected).Take(2).ToList();
        return activeMonkeys.First().ItemsInspected * activeMonkeys.Last().ItemsInspected;
    }
}