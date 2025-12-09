namespace Advent2025.Advent08;

public class JunctionBox
{
    public int Id { get; set; }
    public int XCoordinate { get; set; } 
    public int YCoordinate { get; set; } 
    public int ZCoordinate { get; set; }
    
    public Dictionary<int, int> CircuitDistances { get; set; } = new();

    public JunctionBox(string input, int id)
    {
        var stringParts = input.Split(',').ToList();
        XCoordinate = int.Parse(stringParts[0]);
        YCoordinate = int.Parse(stringParts[1]);
        ZCoordinate = int.Parse(stringParts[2]);
        Id = id;
    }
    
    public void CalculateCircuitDistancesIn3DSpace(List<JunctionBox> circuitNodes)
    {
        foreach (var node in circuitNodes)
        {
            if (node.Id == Id || CircuitDistances.ContainsKey(node.Id))
            {
                continue;
            }
            
            var distance = (int)Math.Sqrt(
                Math.Pow(node.XCoordinate - XCoordinate, 2) +
                Math.Pow(node.YCoordinate - YCoordinate, 2) +
                Math.Pow(node.ZCoordinate - ZCoordinate, 2)
            );
            
            CircuitDistances[node.Id] = distance;
            node.CircuitDistances[Id] = distance;
        }
        
        CircuitDistances = CircuitDistances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }
}