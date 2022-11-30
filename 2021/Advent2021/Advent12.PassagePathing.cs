using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;
using AdventShared;

namespace Advent2021
{
    public static class PassagePathing
    {
        public static int GetDupPathCount(IEnumerable<CaveModel> caves)
        {
            var allPaths = new List<List<string>>();
            var visitedCaves = new List<string>();

            var hasPath = GetDupExitPaths(caves.First(x => x.IsStart()), allPaths, visitedCaves);
            return !hasPath ? 0 : allPaths.Count;
        }
        
        private static bool GetDupExitPaths(CaveModel cave, ICollection<List<string>> allPaths, List<string> visitedCaves)
        {
            visitedCaves.Add(cave.CaveName);

            if (cave.IsExit())
            {
                allPaths.Add(visitedCaves);
                return true;   
            }

            var hasPath = new List<bool>();
            foreach (var connectedCave in cave.ConnectedCaves.Where(x => !x.HasVisited(visitedCaves, true)))
            {
                var newPath = visitedCaves.Copy();
                hasPath.Add(GetDupExitPaths(connectedCave, allPaths, newPath));
            }


            return hasPath.Any();
        } 

        public static List<CaveModel> BuildPassages(List<string> rows)
        {
            var caves = new List<CaveModel>();
            foreach (var row in rows)
            {
                var rowSplit = row.Split('-');
                
                var cave1 = caves.FirstOrDefault(x => x.CaveName == rowSplit[0]);
                var cave2 = caves.FirstOrDefault(x => x.CaveName == rowSplit[1]);

                var addedCave1 = false;
                if (cave1 == null)
                {
                    cave1 = new CaveModel(rowSplit[0]);
                    addedCave1 = true;
                }

                var addedCave2 = false;
                if (cave2 == null)
                {
                    cave2 = new CaveModel(rowSplit[1]);
                    addedCave2 = true;
                }
                
                cave1.ConnectedCaves.Add(cave2);
                cave2.ConnectedCaves.Add(cave1);
                
                if(addedCave1)
                    caves.Add(cave1);
                
                if(addedCave2)
                    caves.Add(cave2);
            }

            return caves;
        }

        public static IEnumerable<CaveModel> CullUselessCaves(List<CaveModel> caves)
        {
            for (var i = 0; i < caves.Count; i++)
            {
                var cave = caves[i];
                if (cave.ConnectedCaves.Count == 1 && !cave.ConnectedCaves.First().IsLargeCave())
                {
                    cave.ConnectedCaves.First().ConnectedCaves = cave.ConnectedCaves.First().ConnectedCaves
                        .Where(x => x.CaveName != cave.CaveName).ToList();

                    caves.Remove(cave);
                    i = 0;
                }
            }

            return caves;
        }

        public static int GetPathCount(IEnumerable<CaveModel> caves)
        {
            var allPaths = new List<List<string>>();
            var visitedCaves = new List<string>();

            var hasPath = GetExitPaths(caves.First(x => x.IsStart()), allPaths, visitedCaves);
            return !hasPath ? 0 : allPaths.Count;
        }
        
        private static bool GetExitPaths(CaveModel cave, ICollection<List<string>> allPaths, List<string> visitedCaves)
        {
            visitedCaves.Add(cave.CaveName);

            if (cave.IsExit())
            {
                allPaths.Add(visitedCaves);
                return true;   
            }

            var hasPath = new List<bool>();
            foreach (var connectedCave in cave.ConnectedCaves.Where(x => !x.HasVisited(visitedCaves)))
            {
                var newPath = visitedCaves.Copy();
                hasPath.Add(GetExitPaths(connectedCave, allPaths, newPath));
            }

            return hasPath.Any();
        }
    }
}