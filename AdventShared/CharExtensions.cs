using System.Collections.Generic;
using System.Linq;

namespace AdventShared
{
    public static class CharExtensions
    {
        public static bool IsUpperCase(this char item)
        {
            return item >= 'A' && item <= 'Z';
        }
        
        public static int ConvertUpperTo0To25(this char item)
        {
            return item - 'A';
        }
        
        public static int ConvertLowerTo0To25(this char item)
        {
            return item - 'a';
        }

        public static bool IsSymbol(this char character, List<char> excludingChars)
        {
            return character.IsSymbol() && !excludingChars.Contains(character);
        }

        public static bool IsSymbol(this char character)
        {
            return character is >= '!' and <= '/' or >= ':' and <= '@';
        }
    }
}
