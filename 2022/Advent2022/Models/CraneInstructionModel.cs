namespace Advent2022.Models
{
    public class CraneInstructionModel
    {
        public int CountToMove { get; set; }
        public int FromStack { get; set; }
        public int ToStack { get; set; }

        public CraneInstructionModel(string instruction)
        {
            var instructionParts = instruction.Replace("move ", "").Replace(" from ", " ").Replace(" to ", " ").Split(" ");
            CountToMove = GetValueFromInstructionParts(instructionParts, 0);
            FromStack = GetValueFromInstructionParts(instructionParts, 1);
            ToStack = GetValueFromInstructionParts(instructionParts, 2);
        }

        private int GetValueFromInstructionParts(string[] instructionParts, int index)
        {
            return int.Parse(instructionParts[index]);
        }
    }
}