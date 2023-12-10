using AdventShared;

namespace Advent2023.Advent08;

public class HauntedWasteland
{
    private List<Node> Nodes { get; set; } = new();
    private CamelInstruction Instructions { get; set; }

    public HauntedWasteland(List<string> input)
    {
        Instructions = new CamelInstruction(input[0]);

        foreach (var line in input.Where(x => x != input[0] && x != ""))
        {
            Nodes.Add(new Node(line));
        }

        foreach (var node in Nodes)
        {
            node.SetAdjacentNodes(Nodes);
        }
    }

    public int Do()
    {
        var currentNode = Nodes.Single(x => x.Value == "AAA");
        var stepsTaken = 0;
        do
        {
            currentNode = currentNode.ExecuteStep(Instructions);
            stepsTaken++;
        } while (currentNode.Value != "ZZZ");
        return stepsTaken;
    }

    public int DoLonger()
    {
        var currentNodes = Nodes.Where(x => x.Value.EndsWith("A")).ToList();
        var stepsTaken = 0;
        do
        {
            var newCurrentNodes = new List<Node>();
            var direction = Instructions.GetCurrentDirection();
            foreach (var currentNode in currentNodes)
            {
                newCurrentNodes.Add(currentNode.ExecuteStep(direction));
            }
            currentNodes = newCurrentNodes;
            stepsTaken++;
        } while (currentNodes.Any(x => !x.Value.EndsWith("Z")));
        return stepsTaken;
    }
}
