namespace Advent2022.Models
{
    public class CommandModel
    {
        public string CommandPartOne { get; set; }
        public string CommandPartTwo { get; set; }
        public string CommandPartThree { get; set; }
        
        public CommandModel(string command)
        {
            var commandParts = command.Split(" ");
            
            CommandPartOne = commandParts[0];
            CommandPartTwo = commandParts[1];
            CommandPartThree = commandParts.Length >= 3 ? commandParts[2] : string.Empty;
        }

        public bool IsReturnDirectoryCommand()
        {
            return CommandPartTwo == "cd" && CommandPartThree == "..";
        }

        public bool IsNewDirectoryCommand()
        {
            return CommandPartTwo == "cd";
        }

        public bool IsFileListCommand()
        {
            return CommandPartTwo == "ls";
        }
    }
}