using AdventShared;

namespace Advent2022.Models
{
    public class RucksackGroup
    {
        private List<RucksackModel> Group { get; set; }
        private char Badge => CalculateBadge();
        public int BadgePriority => ConvertCharToPriority();

        public RucksackGroup(params RucksackModel[] rucksacks)
        {
            Group = rucksacks.ToList();
        }
        
        private char CalculateBadge()
        {
            var result = Group[0].ItemList.FindDupes(Group[1].ItemList);
            result = result.FindDupes(Group[2].ItemList);
            return result[0];
        }
        
        private int ConvertCharToPriority()
        {
            return Badge.IsUpperCase() ? ConvertUpperToPriority(Badge) : ConvertLowerToPriority(Badge);
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