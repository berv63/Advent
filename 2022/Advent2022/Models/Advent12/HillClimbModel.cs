namespace Advent2022.Models.Advent12;

public class HillClimbModel
{
    public int Height { get; set; }
    public bool IsStartValue { get; set; } = false;
    public bool IsEndValue { get; set; } = false;

    public int ShortestDistance { get; set; } = int.MaxValue;
    
    public HillClimbModel? Up { get; set; }
    public HillClimbModel? Down { get; set; }
    public HillClimbModel? Left { get; set; }
    public HillClimbModel? Right { get; set; }
    
    public HillClimbModel(char value)
    {
        if (value == 'S')
        {
            IsStartValue = true;
            value = 'a';
        }
        
        if (value == 'E')
        {
            IsEndValue = true;
            value = 'z';
        }
            
            
        Height = value - 'a';
    }

    public bool IsPassableUp()
    {
        return Up != null && Up.Height <= Height + 1;
    }
    
    public bool IsPassableDown()
    {
        return Down != null && Down.Height <= Height + 1;
    }
    
    public bool IsPassableLeft()
    {
        return Left != null && Left.Height <= Height + 1;
    }
    
    public bool IsPassableRight()
    {
        return Right != null && Right.Height <= Height + 1;
    }

    public void MoveToAllPassableNeighbors(int currentDistance)
    {
        if (currentDistance >= ShortestDistance)
            return;
        
        ShortestDistance = currentDistance;
        
        if (IsEndValue)
            return;
        
        if(IsPassableUp())
            Up.MoveToAllPassableNeighbors(currentDistance + 1);
        
        if(IsPassableDown())
            Down.MoveToAllPassableNeighbors(currentDistance + 1);
        
        if(IsPassableLeft())
            Left.MoveToAllPassableNeighbors(currentDistance + 1);
        
        if(IsPassableRight())
            Right.MoveToAllPassableNeighbors(currentDistance + 1);
    }
}