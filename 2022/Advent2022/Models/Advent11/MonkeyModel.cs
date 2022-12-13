using System.Dynamic;

namespace Advent2022.Models.Advent11;

public class MonkeyModel
{
    public int Index { get; set; }
    public List<long> Items { get; set; } = new ();
    private List<string> OperationSplit { get; set; }
    public int TestValue { get; set; }
    public int TrueIndex { get; set; }
    public int FalseIndex { get; set; }

    public long ItemsInspected { get; set; } = 0;
    
    public MonkeyModel(IEnumerable<string> attributes)
    {
        foreach (var attribute in attributes)
        {
            var trimmed = attribute.Trim();
            var splitSpace = trimmed.Split(" ").ToList();
            var splitColon = trimmed.Split(":").ToList();
            SetIndex(splitSpace);
            SetStartingItems(splitColon);
            
            SetOperationSplit(splitColon);
            SetTestValue(splitColon);
            
            SetTrueIndex(splitSpace);
            SetFalseIndex(splitSpace);
        }
    }

    private void SetIndex(List<string> attributeSplit)
    {
        if (attributeSplit.First() == "Monkey")
        {
            var value = attributeSplit.Last().Replace(":", "");
            Index = int.Parse(value);
        }
    }

    private void SetStartingItems(List<string> attributeSplit)
    {
        if (attributeSplit.First() == "Starting items")
        {
            Items = attributeSplit.Last().Split(",").Select(long.Parse).ToList();
        }
    }

    private void SetOperationSplit(List<string> attributeSplit)
    {
        if (attributeSplit.First() == "Operation")
        {
            OperationSplit = attributeSplit.Last().Trim().Split("=").Last().Trim().Split(" ").ToList();
        }
    }

    private void SetTestValue(List<string> attributeSplit)
    {
        if (attributeSplit.First() == "Test")
        {
            TestValue = int.Parse(attributeSplit.Last().Trim().Split(" ").Last());
        }
    }
    
    private void SetTrueIndex(List<string> attributeSplit)
    {
        if (attributeSplit[1] == "true:")
        {
            TrueIndex = int.Parse(attributeSplit.Last());
        }
    }
    
    private void SetFalseIndex(List<string> attributeSplit)
    {
        if (attributeSplit[1] == "false:")
        {
            FalseIndex = int.Parse(attributeSplit.Last());
        }
    }

    
    public void InspectItemToThrow(int product, bool performRelief)
    {
        Items[0] = PerformOperation(Items[0]);
        
        if(performRelief)
            PerformRelief();
        
        SimplifyValue(product);
        
        ItemsInspected++;
    }

    private long PerformOperation(long item)
    {
        var operandOne = GetOperand(OperationSplit[0], item);
        var operandTwo = GetOperand(OperationSplit[2], item);

        return OperationSplit[1] switch
        {
            "+" => operandOne + operandTwo,
            "*" => operandOne * operandTwo,
            _ => throw new Exception("Invalid Operation")
        };
    }

    private long GetOperand(string operand, long old)
    {
        return operand == "old" ? old : long.Parse(operand);
    }
    
    private void PerformRelief()
    {
        Items[0] /= 3;
    }
    
    private void SimplifyValue(int product)
    {
        Items[0] %= product;
    }


    public int GetThrowIndex()
    {
        return Items.First() % (long)TestValue == 0 ? TrueIndex : FalseIndex;
    }


    public void ThrowItem(MonkeyModel throwToMonkey)
    {
        throwToMonkey.Items.Add(Items.First());
        Items.RemoveAt(0);
    }
}