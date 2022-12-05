namespace Advent2022.Models
{
    public class CraneModel
    {
        private List<CraneInstructionModel> Instructions { get; set; }

        public CraneModel(List<string> instructions)
        {
            Instructions = instructions.Select(x => new CraneInstructionModel(x)).ToList();
        }

        public void ExecuteCrateMover9000(Dictionary<int, List<char>> stacks)
        {
            foreach (var instruction in Instructions)
            {
                for (int i = 1; i <= instruction.CountToMove; i++)
                {
                    var itemToMove = stacks[instruction.FromStack].Last();
                    stacks[instruction.ToStack].Add(itemToMove);
                    stacks[instruction.FromStack].RemoveAt(stacks[instruction.FromStack].Count - 1);
                }
            }
        }

        public void ExecuteCrateMover9001(Dictionary<int, List<char>> stacks)
        {
            foreach (var instruction in Instructions)
            {
                var itemsToMove = stacks[instruction.FromStack].TakeLast(instruction.CountToMove);
                stacks[instruction.ToStack].AddRange(itemsToMove);
                stacks[instruction.FromStack].RemoveRange(stacks[instruction.FromStack].Count - instruction.CountToMove, instruction.CountToMove);
            }
        }
    }
}