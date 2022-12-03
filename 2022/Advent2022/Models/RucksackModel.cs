using Advent2022.Enums;
using Advent2022.Interfaces;
using AdventShared;

namespace Advent2022.Models
{
    public class RucksackModel
    {
        public List<char> ItemList { get; set; }
        private List<char> CompartmentOne { get; set; }
        private List<char> CompartmentTwo { get; set; }

        private List<char> DuplicatePack => CompartmentOne.FindDupes(CompartmentTwo);

        public int DuplicatePriorityTotal => CalculateDupePriority();

        public RucksackModel(string itemList)
        {
            ItemList = itemList.ToList();
            var halfway = itemList.Length / 2;
            CompartmentOne = itemList.Substring(0, halfway).ToList();
            CompartmentTwo = itemList.Substring(halfway, halfway).ToList();
        }

        private int CalculateDupePriority()
        {
            return DuplicatePack.Sum(ConvertCharToPriority);
        }

        private int ConvertCharToPriority(char item)
        {
            return item.IsUpperCase() ? ConvertUpperToPriority(item) : ConvertLowerToPriority(item);
        }
        
        //todo: refactor so these methods arent dupes
        private int ConvertUpperToPriority(char item)
        {
            return item.ConvertUpperTo0To25() + 26 + 1;
        }

        private int ConvertLowerToPriority(char item)
        {
            return item.ConvertLowerTo0To25() + 1;
        }
    }
}