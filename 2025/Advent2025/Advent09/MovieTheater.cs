using AdventShared;

namespace Advent2025.Advent09;

public class MovieTheater
{
    public ulong LargestRectangleArea(List<string> input)
    {
        var polygon = new Polygon(input);
        polygon.Vertices.ForEach(v => v.CalculateRectangleAreasFromNodePairs(polygon.Vertices));
        
        return polygon.Vertices.SelectMany(x => x.NodePairRectangleAreas.Select(y => y.Value)).ToList().Max();
    }
    
    public ulong LargestEnclosedRectangleArea(List<string> input)
    {
        var polygon = new Polygon(input);
        polygon.BuildGridRepresentation();
        
        polygon.Vertices.ForEach(v => v.CalculateRectangleAreasFromNodePairsWhereNoNodesInside(polygon.Vertices));
        var verticesPairAreas = polygon.Vertices.SelectMany(x => x.NodePairRectangleAreas.Select(y => (x.Id, y.Key, y.Value))).ToList().OrderByDescending(x => x.Value);

        foreach (var vertPairs in verticesPairAreas)
        {
            var vertex = polygon.Vertices.First(x => x.Id == vertPairs.Id);
            var otherVertex = polygon.Vertices.First(x => x.Id == vertPairs.Key);
            
            var minX = Math.Min(vertex.X, otherVertex.X);
            var maxX = Math.Max(vertex.X, otherVertex.X);
            var minY = Math.Min(vertex.Y, otherVertex.Y);
            var maxY = Math.Max(vertex.Y, otherVertex.Y);
            
            if (polygon.AreAllPerimeterPointsInternal(minY, maxY, minX, maxX))
            {
                FileExtensions.AppendFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent09", $"PolygonNodes2")}", $"{vertPairs.Id},{vertPairs.Key},{vertPairs.Value}");
                return vertPairs.Value;
            }
            FileExtensions.AppendFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent09", $"PolygonNodes2")}", $"{vertPairs.Id},{vertPairs.Key},{vertPairs.Value}");
        }

        return 0;
    }
}