using AdventShared;

namespace Advent2025.Advent11;

public class Reactor
{
    public long TotalPathsOut(List<string> input)
    {
        var devices = input.Select(line => new Device(line)).ToList();
        devices.Add(new Device("out"));
        foreach (var device in devices)
        {
            device.ConnectOutputs(devices);
        }

        var youDevice = devices.Single(x => x.Name == "you");
        youDevice.ProcessPathsOut();

        return youDevice.PathsOut;
    }
    
    public long TotalPathsOutThroughDacFft(List<string> input)
    {
        var devices = input.Select(line => new Device(line)).ToList();
        devices.Add(new Device("out"));
        foreach (var device in devices)
        {
            device.ConnectOutputs(devices);
        }

        var svrDevice = devices.Single(x => x.Name == "svr");
        svrDevice.ProcessPathsOut();

        return svrDevice.PathsPassingThroughBoth;
    }
}