using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Models
{
    public class LanternfishModel
    {
        public int Age { get; set; }
        public long Count { get; set; }

        public LanternfishModel(int age, long count)
        {
            Age = age;
            Count = count;
        }
    }
}