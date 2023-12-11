using AdventShared;

namespace Advent2023.Advent10;

public class Maze
{
    private List<List<MazeNode>> MazeNodes { get; set; } = new();
    public int FurthestPoint => MazeNodes.SelectMany(x => x).Max(x => x.MinDistance)!.Value;
    public int EnclosedCount => MazeNodes.SelectMany(x => x).Count(x => x.IsInsideLoop);

    public Maze(List<string> input)
    {
        BuildNodes(input);
        AddNodeAdjacency();
    }

    private void BuildNodes(List<string> input)
    {
        for (var row = 0; row < input.Count; row++)
        {
            MazeNodes.Add(new List<MazeNode>());
            for (var column = 0; column < input[0].Length; column++)
            {
                MazeNodes[row].Add(new MazeNode(input[row][column], row, column));
            }
        }
    }

    private void AddNodeAdjacency()
    {
        for (var row = 0; row < MazeNodes.Count; row++)
        {
            for (var column = 0; column < MazeNodes[0].Count; column++)
            {
                if (row != 0)
                    MazeNodes[row][column].NorthNode = MazeNodes[row - 1][column];

                if (row != MazeNodes.Count - 1)
                    MazeNodes[row][column].SouthNode = MazeNodes[row + 1][column];

                if(column != 0)
                    MazeNodes[row][column].WestNode = MazeNodes[row][column - 1];

                if(column != MazeNodes[0].Count - 1)
                    MazeNodes[row][column].EastNode = MazeNodes[row][column + 1];
            }
        }
    }

    public void CalculateLoopDistances(bool replaceStartingValue)
    {
        var currentNode = MazeNodes.Select(x => x.SingleOrDefault(y => y.Value == 'S')).Single(x => x != null);
        var direction = currentNode!.GetStartDirection1();
        var distance = 0;
        do
        {
            currentNode = currentNode!.GetNextNode(ref direction, distance++, 1);
        } while (currentNode!.Value != 'S');


        currentNode = MazeNodes.Select(x => x.SingleOrDefault(y => y.Value == 'S')).Single(x => x != null);
        direction = currentNode!.GetStartDirection2();
        distance = 0;
        do
        {
            currentNode = currentNode!.GetNextNode(ref direction, distance++, 2);
        } while (currentNode!.Value != 'S');

        if (replaceStartingValue)
        {
            currentNode.Value = GetNewStartingValue(currentNode);
        }
    }

    private char GetNewStartingValue(MazeNode node)
    {
        if (node.ConnectsNorth)
        {
            if (node.ConnectsSouth)
            {
                return '|';
            }
            if (node.ConnectsEast)
            {
                return 'L';
            }
            if (node.ConnectsWest)
            {
                return 'J';
            }
        }
        else if (node.ConnectsSouth)
        {
            if (node.ConnectsEast)
            {
                return 'F';
            }
            if (node.ConnectsWest)
            {
                return '7';
            }
        }

        return '-';
    }


    public void CalculateEnclosedCount()
    {
        CalculateEnclosedHorizontally();
        CalculateEnclosedVertically();
    }

    private void CalculateEnclosedHorizontally()
    {
        var rowCount = 0;
        foreach (var row in MazeNodes)
        {
            var loopCount = 0;
            for (var column = 0; column < MazeNodes[0].Count; column++)
            {
                if (row[column].IsPartOfLoop && (row[column].Value == '|' || IsNonmatchingHorizontalCorner(row[column].Value)))
                    loopCount++;

                if (row[column].IsPartOfLoop && IsCorner(row[column].Value) && !PlaceHolder.HasValue)
                    PlaceHolder = row[column].Value;
                else if (!row[column].IsPartOfLoop || row[column].Value == '|' || IsCorner(row[column].Value))
                    PlaceHolder = null;

                if (!row[column].IsPartOfLoop && loopCount % 2 != 0)
                {
                    row[column].IsInsideLoopHorizontally = true;
                }
            }

            rowCount++;
        }
    }

    private char? PlaceHolder { get; set; }

    private bool IsCorner(char value)
    {
        return value is 'F' or 'J' or '7' or 'L';
    }

    private bool IsNonmatchingHorizontalCorner(char value)
    {
        if (!PlaceHolder.HasValue)
            return false;

        var matchingHorizontalMap = new Dictionary<char, char>
        {
            {'F', '7'},
            {'7', 'F'},
            {'L', 'J'},
            {'J', 'L'},
        };

        return IsCorner(value) && matchingHorizontalMap[PlaceHolder!.Value] != value;
    }

    private void CalculateEnclosedVertically()
    {
        for (var column = 0; column < MazeNodes[0].Count; column++)
        {
            var loopCount = 0;
            var rowCount = 0;
            foreach (var row in MazeNodes)
            {
                if (row[column].IsPartOfLoop && (row[column].Value == '-' || IsNonmatchingVerticalCorner(row[column].Value)))
                    loopCount++;

                if (row[column].IsPartOfLoop && IsCorner(row[column].Value) && !PlaceHolder.HasValue)
                    PlaceHolder = row[column].Value;
                else if (!row[column].IsPartOfLoop || row[column].Value == '-' || IsCorner(row[column].Value))
                    PlaceHolder = null;

                if (!row[column].IsPartOfLoop && loopCount % 2 != 0)
                {
                    row[column].IsInsideLoopVertically = true;
                }

                rowCount++;
            }
        }
    }

    private bool IsNonmatchingVerticalCorner(char value)
    {
        if (!PlaceHolder.HasValue)
            return false;

        var matchingHorizontalMap = new Dictionary<char, char>
        {
            {'7', 'J'},
            {'J', '7'},
            {'F', 'L'},
            {'L', 'F'},
        };

        return IsCorner(value) && matchingHorizontalMap[PlaceHolder!.Value] != value;
    }
}
