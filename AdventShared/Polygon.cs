using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventShared;

public class Node
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public List<Node> Neighbors { get; set; } = new();
    
    public Dictionary<int, ulong> NodePairRectangleAreas { get; set; } = new();

    public Node(string input, int id, Node? neighbor = null)
    {
        var stringParts = input.Split(',').ToList();
        X = int.Parse(stringParts[0]);
        Y = int.Parse(stringParts[1]);
        
        Id = id;

        if (neighbor != null)
        {
            Neighbors.Add(neighbor);
            neighbor.Neighbors.Add(this);
        }
    }
    
    public void CalculateRectangleAreasFromNodePairs(List<Node> nodes)
    {
        foreach (var node in nodes)
        {
            if (node.Id >= Id || NodePairRectangleAreas.ContainsKey(node.Id))
            {
                continue;
            }
            
            var area = ((ulong)Math.Abs(node.X - X) + 1) * ((ulong)Math.Abs(node.Y - Y) + 1);
            
            NodePairRectangleAreas[node.Id] = area;
        }
    }
    
    public void CalculateRectangleAreasFromNodePairsWhereNoNodesInside(List<Node> nodes)
    {
        foreach (var rectangleNode in nodes)
        {
            if (rectangleNode.Id >= Id || NodePairRectangleAreas.ContainsKey(rectangleNode.Id) || DoesRectangleContainAnyNodes(rectangleNode, nodes))
            {
                continue;
            }

            var area = ((ulong)Math.Abs(rectangleNode.X - X) + 1) * ((ulong)Math.Abs(rectangleNode.Y - Y) + 1);

            NodePairRectangleAreas[rectangleNode.Id] = area;
        }
    }
    
    private bool DoesRectangleContainAnyNodes(Node rectangleNode, List<Node> allNodes)
    {
        return allNodes.Any(node => DoesRectangleContainNode(this, rectangleNode, node));
    }
    
    private bool DoesRectangleContainNode(Node rectangleNode1, Node rectangleOppositeNode, Node nodeToCheck)
    {
        var minX = Math.Min(rectangleNode1.X, rectangleOppositeNode.X);
        var maxX = Math.Max(rectangleNode1.X, rectangleOppositeNode.X);
        var minY = Math.Min(rectangleNode1.Y, rectangleOppositeNode.Y);
        var maxY = Math.Max(rectangleNode1.Y, rectangleOppositeNode.Y);

        return nodeToCheck.X > minX && nodeToCheck.X < maxX && nodeToCheck.Y > minY && nodeToCheck.Y < maxY;
    }
}

public class Polygon
{
    public List<Node> Vertices { get; set; } = new();
    
    int MinX => Vertices.Min(v => v.X);
    int MaxX => Vertices.Max(v => v.X);
    int MinY => Vertices.Min(v => v.Y);
    int MaxY => Vertices.Max(v => v.Y);

    public List<List<char>> Grid { get; set; }
    
    public void BuildGridRepresentation()
    {
        BuildGrid();

        foreach (var vertex in Vertices)
        {
             AddVertexNode(vertex.Y - MinY, vertex.X - MinX);
        }
        
        AddPerimeter();
        AddInternal();
    }

    private void AddPerimeter()
    {
        for (int i = 0; i < Vertices.Count; i++)
        {
            var current = Vertices[i];
            var next = Vertices[(i + 1) % Vertices.Count];

            var xStep = current.X < next.X ? 1 : (current.X > next.X ? -1 : 0);
            var yStep = current.Y < next.Y ? 1 : (current.Y > next.Y ? -1 : 0);

            var x = current.X;
            var y = current.Y;

            while (x != next.X || y != next.Y)
            {
                AddPerimeterNode(y - MinY, x - MinX);
                x += xStep;
                y += yStep;
            }
            AddPerimeterNode(next.Y - MinY, next.X - MinX);
        }
    }

    private void AddInternal()
    {
        var perimeterDown = false;
        var perimeterUp = false;
        
        for (var y = 1; y < Grid.Count - 1; y++)
        {
            var startIndex = Grid[y].IndexOf('#');
            var startIndex2 = Grid[y].IndexOf('X');
            startIndex = startIndex == -1 ? startIndex2 : (startIndex2 == -1 ? startIndex : Math.Min(startIndex, startIndex2));
            
            var endIndex = Grid[y].LastIndexOf('#');
            var endIndex2 = Grid[y].LastIndexOf('X');
            endIndex = endIndex == -1 ? endIndex2 : (endIndex2 == -1 ? endIndex : Math.Max(endIndex, endIndex2));
            
            for (var x = startIndex; x <= endIndex; x++)
            {
                if (IsNodeOrEdge(y, x))
                {
                    if (IsNodeOrEdge(y-1, x))
                    {
                        perimeterUp = !perimeterUp;
                    }
                    if (IsNodeOrEdge(y+1, x))
                    {
                        perimeterDown = !perimeterDown;
                    }
                }

                if (!IsNodeOrEdge(y, x) && perimeterUp && perimeterDown)
                {
                    AddInternalNode(y, x);
                }
            }
        }
    }
    
    private bool IsNodeOrEdge(int y, int x)
    {
        return Grid[y][x] == '#' || Grid[y][x] == 'X';
    }

    private void AddVertexNode(int y, int x)
    {
        Grid[y][x] = '#';
    }

    private void AddPerimeterNode(int y, int x)
    {
        if(Grid[y][x] == '#') return;
        Grid[y][x] = 'X';
    }

    private void AddInternalNode(int y, int x)
    {
        if(Grid[y][x] == '#' || Grid[y][x] == 'X') return;
        Grid[y][x] = 'O';
    }

    private void BuildGrid()
    {
        Grid = [];
        for (var y = MinY; y <= MaxY; y++)
        {
            Grid.Add(new string('.', MaxX - MinX + 1).ToList());
        }
    }

    public Polygon(List<string> lines)
    {
        var id = 0;
        foreach (var line in lines)
        {
            Vertices.Add(new Node(line, id++, Vertices.LastOrDefault()));
        }
        
        Vertices.Last().Neighbors.Add(Vertices.First());
    }

    public void Print()
    {
        var list = Grid.Select(x => string.Join("", x.Select(y => y.ToString()))).ToList();
        FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent09", $"PolygonNodes")}", list);
    }
    
    public bool AreAllPerimeterPointsInternal(int minY, int maxY, int minX, int maxX)
    {
        for (var x = minX; x <= maxX; x++)
        {
            if (!IsInternalEdgeOrVertex(minY - MinY, x - MinX) || !IsInternalEdgeOrVertex(maxY - MinY, x - MinX))
            {
                return false;
            }
        }
        
        for (var y = minY; y <= maxY; y++)
        {
            if (!IsInternalEdgeOrVertex(y - MinY, minX - MinX) || !IsInternalEdgeOrVertex(y - MinY, maxX - MinX))
            {
                return false;
            }
        }

        return true;
    }
    
    private bool IsInternalEdgeOrVertex(int y, int x)
    {
        return Grid[y][x] == 'O' || Grid[y][x] == 'X' || Grid[y][x] == '#';
    }
}
