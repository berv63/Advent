using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventShared
{
    public static class BinaryExtensions
    {
        private static readonly Dictionary<char, string> HexToBinaryMap = new Dictionary<char, string>
        {
            {'0', "0000"},
            {'1', "0001"},
            {'2', "0010"},
            {'3', "0011"},
            {'4', "0100"},
            {'5', "0101"},
            {'6', "0110"},
            {'7', "0111"},
            {'8', "1000"},
            {'9', "1001"},
            {'A', "1010"},
            {'B', "1011"},
            {'C', "1100"},
            {'D', "1101"},
            {'E', "1110"},
            {'F', "1111"},
        };

        public static int ToDecimal(this IEnumerable<int> args)
        {
            var binaryString = string.Join("", args);
            return Convert.ToInt32(binaryString, 2);
        }

        public static IEnumerable<int> InvertBinary(this IEnumerable<int> args)
        {
            return args.Select(arg => arg == 0 ? 1 : 0).ToList();
        }

        public static string ToBinary(this string hex)
        {
            return hex.Aggregate("", (current, bit) => current + HexToBinaryMap[bit]);
        }

        public static string ToBinary(this int number, int leftPadding)
        {
            return Convert.ToString(number, 2).PadLeft(leftPadding, '0');
        }
        
        public static long BinaryToDecimal(this string binary)
        {
            long result = 0;
            var reversed = binary.Reverse().ToList();
            for (var i = 0; i < reversed.Count; i++)
            {
                if (reversed[i] == '1')
                    result += (long)Math.Pow(2, i);
            }

            return result;
        }
    }
}