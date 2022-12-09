using System.Data;
using AdventShared;

namespace Advent2022.Models
{
    public class HeadTailCommandModel
    {

        public char Direction { get; set; }
        public int Distance { get; set; }
        
        public HeadTailCommandModel(string fileData)
        {
            var fileDataSplit = fileData.Split(" ");
            Direction = fileDataSplit.First()[0];
            Distance = int.Parse(fileDataSplit.Last());
        }
    }
}