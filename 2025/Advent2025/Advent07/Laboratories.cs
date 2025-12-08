namespace Advent2025.Advent07;

public class Laboratories
{
    public int TachyonSplitCount(List<string> input)
    {
        var nodes = GetNodes(input);
        MapNodes(nodes);

        return nodes.Count(x => x.WasHit);
    }

    public long TachyonTimelineCount(List<string> input)
    {
        var nodes = GetNodes(input);
        MapNodes(nodes);

        var rootNode = nodes.Single(x => x.IsRootSplitter);
        rootNode.PopulateTotalChildTimelines();

        return rootNode.TotalChildTimelines ?? 2;
    }

    private static List<Node> GetNodes(List<string> input)
    {
        var nodes = new List<Node>();
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                if (input[i][j] == '.') continue;
                
                nodes.Add(new Node(input[i][j], j, i));
            }
        }

        return nodes;
    }
    
    private static void MapNodes(List<Node> nodes)
    {
        foreach (var node in nodes.OrderBy(x => x.YCoordinate))
        {
            if (node.IsStarter)
            {
                continue;
            }
            
            var beamOrigins = nodes.Where(x => x.HitsNewNode(node)).ToList();
            
            if (beamOrigins.Any())
            {
                node.WasHit = true;
            }
        }
    }
}