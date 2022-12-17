namespace Advent2022.Models.Advent05
{
    public class CraneModel
    {
        private List<CraneInstructionModel> Instructions { get; set; }

        public CraneModel(List<string> instructions)
        {
            Instructions = instructions.Select(x => new CraneInstructionModel(x)).ToList();
        }

        public void ExecuteCrateMover9000(Dictionary<int, Stack<char>> stacks)
        {
            foreach (var instruction in Instructions)
            {
                for (int i = 1; i <= instruction.CountToMove; i++)
                {
                    var itemToMove = stacks[instruction.FromStack].Pop();
                    stacks[instruction.ToStack].Push(itemToMove);
                }
            }
        }

        public void ExecuteCrateMover9001(Dictionary<int, Stack<char>> stacks)
        {
            foreach (var instruction in Instructions)
            {
                var itemsToMove = stacks[instruction.FromStack].Take(instruction.CountToMove);

                foreach (var item in itemsToMove.Reverse())
                {
                    stacks[instruction.FromStack].Pop();
                    stacks[instruction.ToStack].Push(item);
                }
            }
        }
    }
}