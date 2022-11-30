using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Models
{
    public class CrabSubmarineModel
    {
        public int Position { get; set; }
        public int Count { get; set; }

        public CrabSubmarineModel(int position, int count)
        {
            Position = position;
            Count = count;
        }
    }
}