namespace Advent2022.Models
{
    public class CleaningPairsModel
    {
        private int Elf1StartIndex { get; set; }
        private int Elf1EndIndex { get; set; }

        private int Elf2StartIndex { get; set; }
        private int Elf2EndIndex { get; set; }

        public bool IsFullyContainedPair => CalculateIsFullyContainedPair();
        public bool IsOverlappedPair => CalculateIsOverlapped();
        
        public CleaningPairsModel(string itemList)
        {
            var elfRanges = itemList.Split(",");
            var elfIndexes = elfRanges.Select(x => x.Split("-")).ToList(); 
            
            Elf1StartIndex = int.Parse(elfIndexes[0][0]);
            Elf1EndIndex = int.Parse(elfIndexes[0][1]);
            
            Elf2StartIndex = int.Parse(elfIndexes[1][0]);
            Elf2EndIndex = int.Parse(elfIndexes[1][1]);
        }

        private bool CalculateIsFullyContainedPair()
        {
            return DoesOneFullyContainTwo() || DoesTwoFullyContainOne();
        }

        private bool DoesOneFullyContainTwo()
        {
            return Elf1StartIndex <= Elf2StartIndex && Elf1EndIndex >= Elf2EndIndex;
        }

        private bool DoesTwoFullyContainOne()
        {
            return Elf2StartIndex <= Elf1StartIndex && Elf2EndIndex >= Elf1EndIndex;
        }

        private bool CalculateIsOverlapped()
        {
            return DoesOneStartBeforeTwoAndOverlap() || DoesTwoStartBeforeOneAndOverlap();
        }

        private bool DoesOneStartBeforeTwoAndOverlap()
        {
            return Elf1StartIndex <= Elf2StartIndex && Elf1EndIndex >= Elf2StartIndex;
        }
        
        private bool DoesTwoStartBeforeOneAndOverlap()
        {
            return Elf2StartIndex <= Elf1StartIndex && Elf2EndIndex >= Elf1StartIndex;
        }
    }
}