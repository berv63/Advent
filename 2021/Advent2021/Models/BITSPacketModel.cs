using System.Collections.Generic;
using System.Linq;
using AdventShared;

namespace Advent2021.Models
{
    public class BITSPacketModel
    {
        public int Version { get; set; }
        public PacketVersionTypeEnum Type { get; set; }

        public string Literal { get; set; }
        public string RemainingBits { get; set; }
        
        public int SubPacketLengths { get; set; }
        
        public long VersionSum { get; set; }
        
        public long Value { get; set; }

        public List<BITSPacketModel> SubPackets { get; set; } = new List<BITSPacketModel>();

        public BITSPacketModel(string packetBinary)
        {
            Version = (int) GetPacketVersion(packetBinary).BinaryToDecimal();
            Type = (PacketVersionTypeEnum)GetPacketType(packetBinary).BinaryToDecimal();

            if (Type == PacketVersionTypeEnum.Exact)
                Literal = GetStringLiteral(packetBinary.Substring(6));
            else
            {
                if (GetLengthType(packetBinary) == (int) LengthTypeEnum.PacketLength)
                {
                    SubPacketLengths = GetSubPacketLengths(packetBinary, 15);
                    BITSPacketModel currentSubPacket;
                    RemainingBits = packetBinary.Substring(22, SubPacketLengths);
                    do
                    {
                        currentSubPacket = new BITSPacketModel(RemainingBits);
                        SubPackets.Add(currentSubPacket);
                        RemainingBits = currentSubPacket.RemainingBits;
                    } while (currentSubPacket.HasRemainingPackets());

                    if (packetBinary.Length >= 22 + SubPacketLengths)
                        RemainingBits = packetBinary.Substring(22 + SubPacketLengths);
                }
                else
                {
                    SubPacketLengths = GetSubPacketLengths(packetBinary, 11);
                    RemainingBits = packetBinary.Substring(18);
                    do
                    {
                        var currentSubPacket = new BITSPacketModel(RemainingBits);
                        SubPackets.Add(currentSubPacket);
                        RemainingBits = currentSubPacket.RemainingBits;
                    } while (SubPackets.Count < SubPacketLengths);
                }
            }
            
            GetValue();
            GetVersionSums();
        }

        private string GetPacketVersion(string packetBinary)
        {
            return packetBinary.Substring(0, 3);
        }

        private string GetPacketType(string packetBinary)
        {
            return packetBinary.Substring(3, 3);
        }

        private string GetStringLiteral(string packetBinaryLiteral)
        {
            var isLastBit = false;
            var stringLiteralBits = "";
            do
            {
                if (packetBinaryLiteral[0] == '0')
                    isLastBit = true;

                stringLiteralBits += packetBinaryLiteral.Substring(1, 4);

                packetBinaryLiteral = packetBinaryLiteral.Length >= 6 ? packetBinaryLiteral.Substring(5) : "";
            } while (!isLastBit);

            RemainingBits = packetBinaryLiteral;
            return stringLiteralBits;
        }

        private bool HasRemainingPackets()
        {
            return RemainingBits.Any(x => x == '1');
        }

        private int GetLengthType(string packetBinary)
        {
            return int.Parse(packetBinary.Substring(6, 1));
        }

        private int GetSubPacketLengths(string packetBinary, int length)
        {
            var lengthsString = packetBinary.Substring(7, length);
            return (int)lengthsString.BinaryToDecimal();
        }

        private void GetVersionSums()
        {
            VersionSum = Version + SubPackets.Sum(x => x.VersionSum);
        }

        private void GetValue()
        {
            
            switch (Type)
            {
                case PacketVersionTypeEnum.Sum:
                    Value = SubPackets.Sum(x => x.Value);
                    break;
                case PacketVersionTypeEnum.Product:
                    Value = SubPackets.Aggregate((long)1, (result, item) => result * item.Value);
                    break;
                case PacketVersionTypeEnum.Minimum:
                    Value = SubPackets.Min(x => x.Value);
                    break;
                case PacketVersionTypeEnum.Maximum:
                    Value = SubPackets.Max(x => x.Value);
                    break;
                case PacketVersionTypeEnum.Exact:
                    Value = Literal.BinaryToDecimal();
                    break;
                case PacketVersionTypeEnum.GreaterThan:
                    Value = SubPackets[0].Value > SubPackets[1].Value ? 1 : 0; 
                    break;
                case PacketVersionTypeEnum.LessThan:
                    Value = SubPackets[0].Value < SubPackets[1].Value ? 1 : 0; 
                    break;
                case PacketVersionTypeEnum.EqualTo:
                    Value = SubPackets[0].Value == SubPackets[1].Value ? 1 : 0; 
                    break;
            }
                
        }
    }

    public enum LengthTypeEnum
    {
        PacketLength = 0,
        PacketCount = 1,
    }
    
    public enum PacketVersionTypeEnum
    {
        Sum = 0,
        Product = 1,
        Minimum = 2,
        Maximum = 3,
        Exact = 4,
        GreaterThan = 5,
        LessThan = 6,
        EqualTo = 7,
    }
}