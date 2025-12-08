namespace Advent2025.Advent07;

public class Node
{
    public bool IsStarter { get; set; }
    public bool HasStarterBeenSplit { get; set; }
    
    public bool IsRootSplitter { get; set; }
    public bool IsSplitter { get; set; }
    public int XCoordinate { get; set; }
    public bool HasLeftBeenSplit { get; set; }
    public bool HasRightBeenSplit { get; set; }
    
    public int YCoordinate { get; set; }
    
    public Node? LeftNode { get; set; }
    public Node? RightNode { get; set; }
    
    public Node ParentNode { get; set; }
    
    public long? TotalChildTimelines { get; set; }
    
    public bool WasHit { get; set; }
    

    public Node(char nodeChar, int xCoordinate, int yCoordinate)
    {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
        
        if (nodeChar == 'S')
        {
            IsStarter = true;
        }
        else if (nodeChar == '^')
        {
            IsSplitter = true;
        }
    }

    public bool HitsNewNode(Node newNode)
    {
        return newNode.YCoordinate > YCoordinate && (HitsNewNodeFromStarter(newNode) || HitsNewNodeLeft(newNode) || HitsNewNodeRight(newNode));
    }

    private bool HitsNewNodeFromStarter(Node newNode)
    {
        if (!IsStarter || HasStarterBeenSplit || XCoordinate != newNode.XCoordinate) return false;
        IsRootSplitter = true;
        
        return HasStarterBeenSplit = true;
    }

    private bool HitsNewNodeLeft(Node newNode)
    {
        if (HasLeftBeenSplit || XCoordinate - 1 != newNode.XCoordinate) return false;
        
        LeftNode = newNode;
        newNode.ParentNode = this;
        
        return HasLeftBeenSplit = true;
    }

    private bool HitsNewNodeRight(Node newNode)
    {
        if (HasRightBeenSplit || XCoordinate + 1 != newNode.XCoordinate) return false;
        
        RightNode = newNode;
        newNode.ParentNode = this;
        
        return HasRightBeenSplit = true;
    }
    
    public void PopulateTotalChildTimelines()
    {
        if (LeftNode == null && RightNode == null)
        {
            TotalChildTimelines = 2;
            return;
        }

        if (TotalChildTimelines != null)
        {
            return;
        }

        LeftNode?.PopulateTotalChildTimelines();
        RightNode?.PopulateTotalChildTimelines();

        var leftTotal = LeftNode?.TotalChildTimelines ?? 1;
        var rightTotal = RightNode?.TotalChildTimelines ?? 1;

        TotalChildTimelines = leftTotal + rightTotal;
    }
}