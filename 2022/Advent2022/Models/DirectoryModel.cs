namespace Advent2022.Models
{
    public class DirectoryModel
    {
        public string DirectoryName { get; set; }
        public int DirectorySize => GetDirectorySize();
        
        public DirectoryModel ParentDirectory { get; set; }

        public List<DirectoryModel> Directories { get; set; } = new ();
        public List<FileModel> Files { get; set; } = new();

        public DirectoryModel(CommandModel command)
        {
            DirectoryName = command.CommandPartThree;
            ParentDirectory = null;
        }
        
        private DirectoryModel(string directoryList, DirectoryModel parentDirectory)
        {
            DirectoryName = directoryList.Split(" ")[1];
            ParentDirectory = parentDirectory;
        }

        public void RunCommandsInDirectory(List<string> followingCommands)
        {
            while (followingCommands.Any())
            {
                var command = new CommandModel(followingCommands[0]);
                followingCommands.RemoveAt(0);
                
                if (command.IsFileListCommand())
                {
                    ProcessFileListCommand(followingCommands);
                }

                if (command.IsReturnDirectoryCommand())
                {
                    return;
                }

                if (command.IsNewDirectoryCommand())
                {
                    var newDirectory = Directories.Single(x => x.DirectoryName == command.CommandPartThree);
                    newDirectory.RunCommandsInDirectory(followingCommands);
                }
            }
        }

        private void ProcessFileListCommand(List<string> followingCommands)
        {
            var i = 0;
            while (followingCommands[i].Split(" ")[0] != "$")
            {
                var lsList = followingCommands[i];
                ProcessNewDirectory(lsList);
                ProcessNewFile(lsList);
                
                followingCommands.RemoveAt(0);
                if (!followingCommands.Any())
                    break;
            }
        }

        private void ProcessNewDirectory(string directoryList)
        {
            if (directoryList.Split(" ")[0] == "dir")
            {
                Directories.Add(new DirectoryModel(directoryList, this));
            }
        }

        private void ProcessNewFile(string fileList)
        {
            if (int.TryParse(fileList.Split(" ")[0], out var fileSize))
            {
                Files.Add(new FileModel(fileList));
            }
        }

        private int GetDirectorySize()
        {
            return Files.Sum(x => x.FileSize) + Directories.Sum(x => x.GetDirectorySize());
        }

        public List<DirectoryModel> GetDirectoriesUnderSize(int size)
        {
            var result = new List<DirectoryModel>();
            foreach (var directory in Directories)
            {
                if (directory.DirectorySize < size)
                {
                    result.Add(directory);
                }
                
                result.AddRange(directory.GetDirectoriesUnderSize(size));
            }

            return result;
        }
        
        public DirectoryModel? GetDirectoryClosestInSize(int sizeNeeded)
        {
            var closestSizeDifference = int.MaxValue;

            var result = this;
            foreach (var directory in Directories)
            {
                if (sizeNeeded > directory.DirectorySize)
                    continue;
            
                var sizeDifference = directory.DirectorySize - sizeNeeded;
                if (sizeDifference < closestSizeDifference)
                {
                    closestSizeDifference = sizeDifference;
                    result =  GetClosestSub(directory, sizeNeeded, ref closestSizeDifference) ?? directory;
                }
                else
                {
                    result =  GetClosestSub(directory, sizeNeeded, ref closestSizeDifference) ?? result;
                }
            }

            return result;
        }

        private DirectoryModel? GetClosestSub(DirectoryModel directory, int sizeNeeded, ref int closestSizeDifference)
        {
            DirectoryModel? result = null;
            var closestSub = directory.GetDirectoryClosestInSize(sizeNeeded);
            if (closestSub != null)
            {
                var subSizeDifference = closestSub.DirectorySize - sizeNeeded;
                if (subSizeDifference < closestSizeDifference)
                {
                    closestSizeDifference = closestSub.DirectorySize - sizeNeeded;
                    result = closestSub;
                }
            }

            return result;
        }
    }
}