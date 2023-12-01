namespace Advent2022.Models.Advent16;

public class ValveTunnelModel
{
    public string Name { get; set; }
    public int FlowRate { get; set; }

    public List<ValveTunnelModel> NeighborValves { get; set; } = new();

    public ValveTunnelModel(string data)
    {
        var dataSplit = data.Split(" ");
        Name = dataSplit[1];
        FlowRate = int.Parse(dataSplit.Last().Split("=").Last());
    }

    public void MapNeighbors(string data, List<ValveTunnelModel> models)
    {
        var neighborListString = data.Substring(GetValveNeighborIndex(data));
        var neighbors = neighborListString.Replace(" ", "").Split(",").ToList();
        foreach (var neighbor in neighbors)
        {
            NeighborValves.Add(models.Single(x => x.Name == neighbor));
        }
    }

    private int GetValveNeighborIndex(string data)
    {
        return data.IndexOf("valves") == -1 ? data.IndexOf("valve") + 6 : data.IndexOf("valves") + 7;
    }
}