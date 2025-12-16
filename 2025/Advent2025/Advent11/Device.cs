namespace Advent2025.Advent11;

public class Device
{
    public string Name { get; set; }
    public List<string> OutputNames { get; set; }
    public long PathsOut { get; set; }
    
    public long PathsPassingThroughDac { get; set; }
    public long PathsPassingThroughFft { get; set; }
    public long PathsPassingThroughBoth { get; set; }

    public List<Device> ParentDevices { get; set; } = new();
    public List<Device> ChildDevices { get; set; } = new();

    public Device(string input)
    {
        var splitColon = input.Split(":");
        Name = splitColon.First();

        OutputNames = splitColon.Last().Trim().Split(" ").ToList();
    }

    public void ConnectOutputs(List<Device> devices)
    {
        foreach (var device in OutputNames.Select(outputName => devices.Single(x => x.Name == outputName)))
        {
            device.ParentDevices.Add(this);
            ChildDevices.Add(device);
        }
    }

    public void ProcessPathsOut()
    {
        if (Name == "out")
        {
            PathsOut = 1;
        }

        if (PathsOut != 0)
        {
            return;
        }

        foreach (var child in ChildDevices)
        {
            child.ProcessPathsOut();
        }
        PathsOut = ChildDevices.Sum(x => x.PathsOut);

        if (Name == "dac")
        {
            PathsPassingThroughDac = PathsOut;
            PathsPassingThroughBoth = ChildDevices.Sum(x => x.PathsPassingThroughFft);
        }
        else if (Name == "fft")
        {
            PathsPassingThroughFft = PathsOut;
            PathsPassingThroughBoth = ChildDevices.Sum(x => x.PathsPassingThroughDac);
        }
        else
        {
            PathsPassingThroughDac = ChildDevices.Sum(x => x.PathsPassingThroughDac);
            PathsPassingThroughFft = ChildDevices.Sum(x => x.PathsPassingThroughFft);
            PathsPassingThroughBoth = ChildDevices.Sum(x => x.PathsPassingThroughBoth);
        }
    }
}