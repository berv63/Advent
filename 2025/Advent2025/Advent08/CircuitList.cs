namespace Advent2025.Advent08;

public class CircuitList
{
    public List<List<int>> Circuits { get; set; } = new();
    
    public long GetTopThreeCountMultiplied()
    {
        var topThree = Circuits.OrderByDescending(x => x.Count).Take(3).ToList();
        return topThree[0].Count * topThree[1].Count * topThree[2].Count;
    }
    
    public void BuildNewCircuit((int, int, int) circuit)
    {
        Circuits.Add(new List<int> { circuit.Item1, circuit.Item2 });
    }

    public void AddItem1ToCircuit((int, int, int) circuit)
    {
        var existingCircuit = Circuits.First(x => x.Contains(circuit.Item2));
        existingCircuit.Add(circuit.Item1);
    }

    public void AddItem2ToCircuit((int, int, int) circuit)
    {
        var existingCircuit = Circuits.First(x => x.Contains(circuit.Item1));
        existingCircuit.Add(circuit.Item2);
    }

    public bool CircuitsContainItem2((int, int, int) circuit)
    {
        return Circuits.Any(x => x.Contains(circuit.Item2));
    }

    public bool CircuitContainsItem1((int, int, int) circuit)
    {
        return Circuits.Any(x => x.Contains(circuit.Item1));
    }

    public void MergeCircuits((int, int, int) circuit)
    {
        var circuit1 = Circuits.First(x => x.Contains(circuit.Item1));
        var circuit2 = Circuits.First(x => x.Contains(circuit.Item2));
        circuit1.AddRange(circuit2);
        Circuits.Remove(circuit2);
    }

    public bool TwoCircuitsContainTheItems((int, int, int) circuit)
    {
        return Circuits.Any(x => x.Contains(circuit.Item1)) && Circuits.Any(x => x.Contains(circuit.Item2));
    }

    public bool CircuitContainsBothItemsAlready((int, int, int) circuit)
    {
        return Circuits.Any(x => x.Contains(circuit.Item1) && x.Contains(circuit.Item2));
    }
}