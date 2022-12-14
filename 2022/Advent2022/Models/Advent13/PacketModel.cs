using System.Collections;
using System.Text.Json.Nodes;
using AdventShared;

namespace Advent2022.Models.Advent13;

public class PacketModel
{
    public bool IsDivider { get; set; }
    private List<dynamic> Items { get; set; } = new();

    public PacketModel(dynamic data, bool isDivider = false)
    {
        IsDivider = isDivider;
        
        dynamic items;
        if (data is string)
        {
            items = JsonObject.Parse(data);

            foreach (var item in (IEnumerable) items)
            {
                SortPacketModel(item);
            }
        }
        else if(data is JsonArray)
        {
            foreach (var item in data)
            {
                SortPacketModel(item);
            }
        }
        else
        {
            SortPacketModel(data);
        }
    }

    private void SortPacketModel(dynamic item)
    {
        try
        {
            var value = (int) item;
            Items.Add(value);
        }
        catch
        {
            Items.Add(new PacketModel(item));   
        }
    }

    public bool IsSmallerThanPacket(PacketModel packet)
    {
        var shouldStop = false;
        return IsSmallerRecursive(packet, ref shouldStop);
    }
    
    private bool IsSmallerRecursive(PacketModel packet, ref bool shouldStop)
    {
        var result = true;
        
        AppendFile($"Compare {PrintPacket()} vs {packet.PrintPacket()}");
        
        for (var i = 0; i < Items.Count; i++)
        {
            if (packet.Items.Count <= i)
            {
                AppendFile("Right side ran out of items, so inputs are not in the right order");
                
                shouldStop = true;
                return false;
            }

            var item1 = Items[i];
            var item2 = packet.Items[i];

            switch (item1)
            {
                case int int1 when item2 is int int2:
                {
                    AppendFile($"Compare {int1} vs {int2}");
                    
                    if (int1 == int2)
                        break;

                    AppendFile(int1 < int2
                        ? $"Left side is smaller, so inputs are in the right order"
                        : $"Right side is smaller, so inputs are not in the right order");

                    shouldStop = true;
                    return int1 < int2;
                }
                case PacketModel model when item2 is PacketModel:
                    result = result && model.IsSmallerRecursive(item2, ref shouldStop);
                    break;
                case PacketModel model when item2 is int:
                    result = result && model.IsSmallerRecursive(new PacketModel(item2), ref shouldStop);
                    break;
                case int when item2 is PacketModel:
                    result = result && new PacketModel(item1).IsSmallerRecursive(item2, ref shouldStop);
                    break;
                default:
                    throw new Exception();
            }

            if (!result || shouldStop)
            {
                return result;
            }
        }
        
        if (Items.Count < packet.Items.Count)
        {
            AppendFile("Left side ran out of items, so inputs are in the right order");
            shouldStop = true;
            return true;
        }

        return result;
    }

    private void AppendFile(string text)
    {
        FileExtensions.AppendFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent13", $"CompareOutput")}", text);
    }
    
    private string PrintPacket()
    {
        var stringResult = "[";
        stringResult += string.Join(",", Items.Select(item => item is int ? (string) item.ToString() : ((PacketModel) item).PrintPacket()).ToList());
        stringResult += "]";

        return stringResult;
    }
}