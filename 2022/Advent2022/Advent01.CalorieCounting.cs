using Advent2022.Models.Advent01;

namespace Advent2022;

public static class CalorieCounting
{
    public static List<ElfModel> BuildElfList(List<string> itemList)
    {
        var elfList = new List<ElfModel>{new ()};
        foreach (var item in itemList)
        {
            if (item == "")
            {
                elfList.Add(new ElfModel());
            }
            else
            {
                elfList.Last().AddItem(item);
            }
        }

        return elfList;
    }

    public static int MaxCalorieCount(List<ElfModel> elves)
    {
        return elves.Max(y => y.CarryCount);
    }
    
    public static int Top3CalorieTotal(List<ElfModel> elves)
    {
        var sortedElves = elves.OrderByDescending(x => x.CarryCount);
        return sortedElves.Take(3).Sum(x => x.CarryCount);
    }
}