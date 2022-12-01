using Advent2022.Models;

namespace Advent2022;

public static class CalorieCounting
{
    public static List<ElfModel> BuildElfList(List<string> itemList)
    {
        var i = 0;
        var elfList = new List<ElfModel>{new (1)};
        var elfCount = 2;
        do
        {
            if (itemList[i] == "")
            {
                elfList.Add(new ElfModel(elfCount));
                elfCount++;
                i++;
                continue;
            }
            elfList.Last().AddItem(itemList[i]);
            i++;
        } while (i < itemList.Count);

        return elfList;
    }

    public static int MaxCalorieCount(List<ElfModel> elfs)
    {
        return elfs.Max(y => y.CarryCount);
    }
    
    public static int Top3CalorieTotal(List<ElfModel> elfs)
    {
        var calorieCount = 0;
        var maxCarryCount = int.MaxValue;
        for (int i = 0; i < 3; i++)
        {
            maxCarryCount = elfs.Where(x => x.CarryCount < maxCarryCount).Max(y => y.CarryCount);
            calorieCount += maxCarryCount;
        }
        return calorieCount;
    }
}