using Advent2022.Models.Advent13;

namespace Advent2022;

public static class DistressSignal
{
    public static List<DistressPairsModel> BuildDistressPairs(List<string> fileData)
    {
        var pairs = new List<DistressPairsModel>();
        var index = 1;
        while (fileData.Any())
        {
            pairs.Add(new DistressPairsModel(fileData.Take(2).ToList(), index++));
            fileData.RemoveRange(0, fileData.Count > 2 ? 3 : 2);
        }
        
        return pairs;
    }
    
    public static int GetOrderedSum(List<DistressPairsModel> pairs)
    {
        return pairs.Where(x => x.ArePacketsInTheCorrectOrder()).Sum(x => x.Index);
    }
    
    public static List<PacketModel> BuildPackets(List<string> fileData)
    {
        var packets = fileData.Where(x => x.Length > 0).Select(item => new PacketModel(item)).ToList();

        packets.Add(new PacketModel("[[2]]", true));
        packets.Add(new PacketModel("[[6]]", true));
        
        return packets;
    }

    public static void SortPackets(List<PacketModel> packets)
    {
        packets.Sort((m1, m2) => m1.IsSmallerThanPacket(m2) ? -1 : 1);
    }

    public static int GetDecoderKey(List<PacketModel> packets)
    {
        var result = 1;
        var index = 1;
        foreach (var packet in packets)
        {
            if (packet.IsDivider)
                result *= index;

            index++;
        }

        return result;
    }
}