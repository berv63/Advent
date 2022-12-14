using Advent2022.Models;

namespace Advent2022;

public static class NoSpace
{
    public static DirectoryModel BuildFileStructure(List<string> fileData)
    {
        var rootDirectory = new DirectoryModel(new CommandModel(fileData[0]));
        rootDirectory.RunCommandsInDirectory(fileData.Where(x => x != fileData[0]).ToList());
        return rootDirectory;
    }

    public static int GetSumOfDirectories(DirectoryModel rootDirectory, int size)
    {
        return rootDirectory.GetDirectoriesUnderSize(size).Sum(x => x.DirectorySize);
    }

    public static int FreeSpace(DirectoryModel rootDirectory, int totalSpace, int spaceRequired)
    {
        var currentUsed = rootDirectory.DirectorySize;
        var needToFree = spaceRequired - (totalSpace - currentUsed);
        return rootDirectory.GetDirectoryClosestInSize(needToFree)?.DirectorySize ?? 0;
    }
}