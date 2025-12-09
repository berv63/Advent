namespace Advent2025.Advent08;

public class Playground
{
    public long CircuitSizes(List<string> input, int numConnections)
    {
        var id = 0;
        var junctionBoxes = input.Select(row => new JunctionBox(row, id++)).ToList();
        
        foreach (var box in junctionBoxes)
        {
            box.CalculateCircuitDistancesIn3DSpace(junctionBoxes);
        }
        
        var circuitSizes = GetAllCircuitSizes(junctionBoxes).SelectMany(x => x.Value.Select(y => (x.Key, y.Key, y.Value))).OrderBy(x => x.Value).ToList();
        var circuits = BuildCircuits(numConnections, circuitSizes);
        
        return circuits.GetTopThreeCountMultiplied();
    }
    
    public long FinalCircuitDistance(List<string> input)
    {
        var id = 0;
        var junctionBoxes = input.Select(row => new JunctionBox(row, id++)).ToList();
        
        foreach (var box in junctionBoxes)
        {
            box.CalculateCircuitDistancesIn3DSpace(junctionBoxes);
        }
        
        var circuitSizes = GetAllCircuitSizes(junctionBoxes).SelectMany(x => x.Value.Select(y => (x.Key, y.Key, y.Value))).OrderBy(x => x.Value).ToList();
        var (finalCircuit1Id, finalCircuit2Id) = TrackBuiltCircuits(circuitSizes);
        
        var finalCircuit1 = junctionBoxes.First(x => x.Id == finalCircuit1Id);
        var finalCircuit2 = junctionBoxes.First(x => x.Id == finalCircuit2Id);
        
        return finalCircuit1.XCoordinate * finalCircuit2.XCoordinate;
    }

    private (int, int) TrackBuiltCircuits(List<(int, int, int)> circuitSizes)
    {
        var finalItemAdded = (0,0);
        
        var circuits = new CircuitList();

        foreach (var circuit in circuitSizes)
        {
            if(circuits.CircuitContainsBothItemsAlready(circuit))
                continue;
            
            if (circuits.TwoCircuitsContainTheItems(circuit))
            {
                circuits.MergeCircuits(circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
                continue;
            }

            if (circuits.CircuitContainsItem1(circuit))
            {
                circuits.AddItem2ToCircuit(circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
            }
            else if (circuits.CircuitsContainItem2(circuit))
            {
                circuits.AddItem1ToCircuit(circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
            }
            else
            {
                circuits.BuildNewCircuit(circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
            }
        }

        return finalItemAdded;
    }

    private static CircuitList BuildCircuits(int numConnections, List<(int, int, int)> circuitSizes)
    {
        var circuits = new CircuitList();

        for (var i = 0; i < numConnections; i++)
        {
            var circuit = circuitSizes[i];
            if(circuits.CircuitContainsBothItemsAlready(circuit))
                continue;
            
            if (circuits.TwoCircuitsContainTheItems(circuit))
            {
                circuits.MergeCircuits(circuit);
                continue;
            }

            if (circuits.CircuitContainsItem1(circuit))
            {
                circuits.AddItem2ToCircuit(circuit);
            }
            else if (circuits.CircuitsContainItem2(circuit))
            {
                circuits.AddItem1ToCircuit(circuit);
            }
            else
            {
                circuits.BuildNewCircuit(circuit);
            }
        }

        return circuits;
    }

    private Dictionary<int, Dictionary<int, int>> GetAllCircuitSizes(List<JunctionBox> junctionBoxes)
    {
        var filteredCircuitSizes = new Dictionary<int, Dictionary<int, int>>();
        foreach (var box in junctionBoxes)
        {
            foreach (var otherBox in box.CircuitDistances)
            {
                var id = box.Id < otherBox.Key ? box.Id : otherBox.Key;
                var key = box.Id < otherBox.Key ? otherBox.Key : box.Id;
                var value = otherBox.Value;

                if (filteredCircuitSizes.ContainsKey(id))
                {
                    if (!filteredCircuitSizes[id].ContainsKey(key))
                    {
                        filteredCircuitSizes[id][key] = value;
                    }
                }
                else
                {
                    filteredCircuitSizes[id] = new Dictionary<int, int> { { key, value } };
                }
            }
        }

        return filteredCircuitSizes;
    }
}