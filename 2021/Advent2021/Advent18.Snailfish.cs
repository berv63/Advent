using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using Advent2021.Models;

namespace Advent2021
{
    public static class Snailfish
    {
        public static SnailfishNumberModel BuildSnailfishNumber(string row)
        {
            var number = new SnailfishNumberModel(row);
            return number;
        }

        public static SnailfishNumberModel AddSnailfishNumbers(SnailfishNumberModel number1, SnailfishNumberModel number2)
        {
            return new SnailfishNumberModel(number1, number2);
        }
    }
}