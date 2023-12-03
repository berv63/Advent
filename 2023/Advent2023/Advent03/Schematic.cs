using AdventShared;

namespace Advent2023.Advent03;

public class Schematic
{
    private List<string> EngineMap { get; set; }

    public List<Part> Parts { get; set; } = new();
    public List<Gear> Gears { get; set; } = new();

    public Schematic(List<string> engineMap)
    {
        EngineMap = engineMap;
    }

    public void PopulateParts()
    {
        for (var i = 0; i < EngineMap.Count; i++)
        {
            for (var j = 0; j < EngineMap.First().Length; j++)
            {
                if (!EngineMap[i][j].IsSymbol(new List<char>{ '.' })) continue;
                var adjacentParts = AddAdjacentParts(i, j);

                if (!IsGear(EngineMap[i][j], adjacentParts)) continue;
                AddGear(i, j, adjacentParts);
            }
        }
    }

    private List<Part> AddAdjacentParts(int i, int j)
    {
        var adjacentParts = new List<Part>();
        foreach (var indices in ListHelper.GetAdjacentIndices(i, j).Where(indices => IsPartNumber(indices.row, indices.column)))
        {
            AddPart(indices.row, indices.column, adjacentParts);
        }

        return adjacentParts;
    }

    private bool IsPartNumber(int targetRow, int targetColumn)
    {
        if (!EngineMap.IsWithinMap(targetRow, targetColumn)) return false;

        var targetChar = EngineMap[targetRow][targetColumn];
        return int.TryParse(targetChar.ToString(), out _);
    }

    private void AddPart(int targetRow, int targetColumn, List<Part> adjacentParts)
    {
        var startNumberColumn = GetStartIndex(targetRow, targetColumn);
        if (DoesPartAlreadyExist(targetRow, startNumberColumn)) return;

        var endNumberColumn = GetEndIndex(targetRow, targetColumn);

        var part = new Part
        {
            Number = int.Parse(EngineMap[targetRow].Substring(startNumberColumn, endNumberColumn - startNumberColumn + 1)),
            StartIndices = (targetRow, startNumberColumn)
        };

        adjacentParts.Add(part);
        Parts.Add(part);
    }

    private int GetStartIndex(int targetRow, int targetColumn)
    {
        var startNumberIndex = targetColumn;
        for (var k = targetColumn; k >= 0; k--)
        {
            var targetChar = EngineMap[targetRow][k];
            if (int.TryParse(targetChar.ToString(), out _))
            {
                startNumberIndex = k;
            }
            else
            {
                break;
            }
        }

        return startNumberIndex;
    }

    private int GetEndIndex(int targetRow, int targetColumn)
    {
        var endNumberIndex = targetColumn;
        for (var k = targetColumn; k < EngineMap[targetRow].Length; k++)
        {
            var targetChar = EngineMap[targetRow][k];
            if (int.TryParse(targetChar.ToString(), out _))
            {
                endNumberIndex = k;
            }
            else
            {
                break;
            }
        }

        return endNumberIndex;
    }

    private bool DoesPartAlreadyExist(int partRow, int partColumn)
    {
        return Parts.Any(x => x.StartIndices.Row == partRow && x.StartIndices.Column == partColumn);
    }

    private void AddGear(int i, int j, List<Part> adjacentParts)
    {
        var gear = new Gear
        {
            Number1 = adjacentParts.First()!.Number,
            Number2 = adjacentParts.Last()!.Number
        };
        Gears.Add(gear);
    }

    private bool IsGear(char targetCharacter, List<Part> adjacentParts)
    {
        return targetCharacter == '*' && adjacentParts.Count == 2;
    }

}
