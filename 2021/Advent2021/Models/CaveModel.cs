using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventShared;

namespace Advent2021.Models
{
    public class CaveModel
    {
        public string CaveName { get; set; }

        public List<CaveModel> ConnectedCaves { get; set; } = new List<CaveModel>();
        
        public CaveModel(string caveName)
        {
            CaveName = caveName;
        }

        public bool HasVisited(List<string> visitedCaves, bool allowSingleDup = false)
        {
            if (IsStart())
                return true;
            if (IsExit())
                return false;
            if (Regex.Match(CaveName, @"[A-Z]*").Length > 0)
                return false;
            if (Regex.Match(CaveName, @"[a-z]*").Length > 0 && !allowSingleDup)
                return visitedCaves.Contains(CaveName);
            if (Regex.Match(CaveName, @"[a-z]*").Length > 0 && allowSingleDup)
                return ContainsDupVisited(visitedCaves) && visitedCaves.Contains(CaveName);
            
            return false;
        }
        
        private bool ContainsDupVisited(List<string> original)
        {
            var result = new List<bool>();
            foreach (var item in original)
            {
                result.Add(original.Where(x => Regex.Match(x, @"[a-z]*").Length > 0).Count(x => x == item) > 1);
            }
            return result.Any(x => x);
        }

        public bool IsLargeCave()
        {
            return Regex.Match(CaveName, @"[A-Z]*").Success;
        }
        
        public bool IsStart()
        {
            return CaveName.ToLower() == "start";
        }
        
        public bool IsExit()
        {
            return CaveName.ToLower() == "end";
        }
    }
}