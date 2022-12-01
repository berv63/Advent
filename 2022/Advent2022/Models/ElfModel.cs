using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2022.Models
{
    public class ElfModel
    {
        public int Index { get; set; }
        public List<int> FoodList { get; set; } = new();
        public int CarryCount => FoodList.Sum();

        public ElfModel(int index)
        {
            Index = index;
        }

        public void AddItem(string item)
        {
            FoodList.Add(int.Parse(item));
        }
    }
}