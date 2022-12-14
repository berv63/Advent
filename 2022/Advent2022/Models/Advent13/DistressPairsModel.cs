using AdventShared;

namespace Advent2022.Models.Advent13;

public class DistressPairsModel
{
    public int Index { get; set; }
    
    private PacketModel Packet1 { get; set; }
    private PacketModel Packet2 { get; set; }

    public DistressPairsModel(List<string> data, int index)
    {
        Index = index;
        
        Packet1 = new PacketModel(data[0]);
        Packet2 = new PacketModel(data[1]);
    }

    public bool ArePacketsInTheCorrectOrder()
    {
        FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent13", $"CompareOutput")}", new List<string>());
        return Packet1.IsSmallerThanPacket(Packet2);
    }
}