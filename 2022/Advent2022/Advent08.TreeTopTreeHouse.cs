using Advent2022.Models.Advent08;

namespace Advent2022;

public static class TreeTopTreeHouse
{
    public static TreeGridModel BuildForrest(List<string> fileData)
    {
        return new TreeGridModel(fileData);
    }

    public static int GetVisibleTreeCount(TreeGridModel treeGrid)
    {
        return treeGrid.GetVisibleTreeCount();
    }
    
    public static int GetScenicScore(TreeGridModel treeGrid)
    {
        return treeGrid.GetScenicScore();
    }
}