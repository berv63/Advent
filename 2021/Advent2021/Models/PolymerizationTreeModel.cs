using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Models
{
    public class PolymerizationTreeModel
    {
        public List<PolymerizationTreeModel> Parents { get; set; } = new List<PolymerizationTreeModel>();
        public List<PolymerizationTreeModel> Children { get; set; } = new List<PolymerizationTreeModel>();
        public Dictionary<int, Dictionary<char, long>> CharCounts { get; set; } = new Dictionary<int, Dictionary<char, long>>();
        
        public string Rule { get; set; }
        public string Insertion { get; set; }
        
        public bool Visited { get; set; }

        public PolymerizationTreeModel(string rule)
        {
            var ruleSplit = rule.Split(' ');
            Rule = ruleSplit[0];
            Insertion = ruleSplit[2];
        }

        public void AddCharCounts(int index, Dictionary<char, long> charCount)
        {
            CharCounts.Add(index, charCount);
        }
    }
}