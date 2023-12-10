namespace Advent2023.Advent08;

public class Node
{
    public string Value { get; set; }

    private string LeftNodeValue { get; set; }
    public Node LeftNode { get; set; }

    private string RightNodeValue { get; set; }
    public Node RightNode { get; set; }

    public Node(string input)
    {
        Value = input.Split("=").First().Trim();
        LeftNodeValue = input.Split("=").Last().Split(",").First().Replace("(", "").Trim();
        RightNodeValue = input.Split("=").Last().Split(",").Last().Replace(")", "").Trim();
    }

    public void SetAdjacentNodes(List<Node> nodes)
    {
        LeftNode = nodes.Single(x => x.Value == LeftNodeValue);
        RightNode = nodes.Single(x => x.Value == RightNodeValue);
    }

    public Node ExecuteStep(CamelInstruction instruction)
    {
        var direction = instruction.GetCurrentDirection();
        return direction == 'L' ? LeftNode : RightNode;
    }

    public Node ExecuteStep(char direction)
    {
        return direction == 'L' ? LeftNode : RightNode;
    }
}
