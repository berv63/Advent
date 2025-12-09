namespace Advent2025.Advent08;

public class Playground
{
    public int CircuitSizes(List<string> input, int numConnections)
    {
        var id = 0;
        var junctionBoxes = input.Select(row => new JunctionBox(row, id++)).ToList();
        
        foreach (var box in junctionBoxes)
        {
            box.CalculateCircuitDistancesIn3DSpace(junctionBoxes);
        }
        
        var circuitSizes = GetAllCircuitSizes(junctionBoxes).SelectMany(x => x.Value.Select(y => (x.Key, y.Key, y.Value))).OrderBy(x => x.Value).ToList();
        var circuits = BuildCircuits(numConnections, circuitSizes).OrderByDescending(x => x.Count);
        
        var largestCircuit = circuits.First();
        var secondLargestCircuit = circuits.Skip(1).First();
        var thirdLargestCircuit = circuits.Skip(2).First();
        
        return largestCircuit.Count * secondLargestCircuit.Count * thirdLargestCircuit.Count;
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
        
        List<List<int>> circuits = new();

        foreach (var circuit in circuitSizes)
        {
            if(CircuitContainsBothItemsAlready(circuits, circuit))
                continue;
            
            if (TwoCircuitsContainTheItems(circuits, circuit))
            {
                MergeCircuits(circuits, circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
                continue;
            }

            if (CircuitContainsItem1(circuits, circuit))
            {
                AddItem2ToCircuit(circuits, circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
            }
            else if (CircuitsContainItem2(circuits, circuit))
            {
                AddItem1ToCircuit(circuits, circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
            }
            else
            {
                BuildNewCircuit(circuits, circuit);
                finalItemAdded = (circuit.Item1, circuit.Item2);
            }
        }

        return finalItemAdded;
    }

    private static List<List<int>> BuildCircuits(int numConnections, List<(int, int, int)> circuitSizes)
    {
        List<List<int>> circuits = new();

        for (var i = 0; i < numConnections; i++)
        {
            var circuit = circuitSizes[i];
            if(CircuitContainsBothItemsAlready(circuits, circuit))
                continue;
            
            if (TwoCircuitsContainTheItems(circuits, circuit))
            {
                MergeCircuits(circuits, circuit);
                continue;
            }

            if (CircuitContainsItem1(circuits, circuit))
            {
                AddItem2ToCircuit(circuits, circuit);
            }
            else if (CircuitsContainItem2(circuits, circuit))
            {
                AddItem1ToCircuit(circuits, circuit);
            }
            else
            {
                BuildNewCircuit(circuits, circuit);
            }
        }

        return circuits;
    }

    private static void BuildNewCircuit(List<List<int>> circuits, (int, int, int) circuit)
    {
        circuits.Add(new List<int> { circuit.Item1, circuit.Item2 });
    }

    private static void AddItem1ToCircuit(List<List<int>> circuits, (int, int, int) circuit)
    {
        var existingCircuit = circuits.First(x => x.Contains(circuit.Item2));
        existingCircuit.Add(circuit.Item1);
    }

    private static void AddItem2ToCircuit(List<List<int>> circuits, (int, int, int) circuit)
    {
        var existingCircuit = circuits.First(x => x.Contains(circuit.Item1));
        existingCircuit.Add(circuit.Item2);
    }

    private static bool CircuitsContainItem2(List<List<int>> circuits, (int, int, int) circuit)
    {
        return circuits.Any(x => x.Contains(circuit.Item2));
    }

    private static bool CircuitContainsItem1(List<List<int>> circuits, (int, int, int) circuit)
    {
        return circuits.Any(x => x.Contains(circuit.Item1));
    }

    private static void MergeCircuits(List<List<int>> circuits, (int, int, int) circuit)
    {
        var circuit1 = circuits.First(x => x.Contains(circuit.Item1));
        var circuit2 = circuits.First(x => x.Contains(circuit.Item2));
        circuit1.AddRange(circuit2);
        circuits.Remove(circuit2);
    }

    private static bool TwoCircuitsContainTheItems(List<List<int>> circuits, (int, int, int) circuit)
    {
        return circuits.Any(x => x.Contains(circuit.Item1)) && circuits.Any(x => x.Contains(circuit.Item2));
    }

    private static bool CircuitContainsBothItemsAlready(List<List<int>> circuits, (int, int, int) circuit)
    {
        return circuits.Any(x => x.Contains(circuit.Item1) && x.Contains(circuit.Item2));
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