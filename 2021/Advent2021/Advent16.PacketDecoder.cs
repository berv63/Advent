using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;
using AdventShared;

namespace Advent2021
{
    public static class PacketDecoder
    {
        public static long GetPacketValue(string hex)
        {
            var packetBinary = hex.ToBinary();
            var packet = new BITSPacketModel(packetBinary);
            return packet.Value;
        }
        
        public static long GetPacketVersionSum(string hex)
        {
            var packetBinary = hex.ToBinary();
            var packet = new BITSPacketModel(packetBinary);
            return packet.VersionSum;
        }
    }
}