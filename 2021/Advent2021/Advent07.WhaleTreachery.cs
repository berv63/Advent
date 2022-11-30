using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;

namespace Advent2021
{
    public static class WhaleTreachery
    {
        public static List<CrabSubmarineModel> MergeCrabSubmarines(List<CrabSubmarineModel> crabSubmarines)
        {
            var tempCrabSubmarines = new List<CrabSubmarineModel>();
            foreach (var submarine in crabSubmarines)
            {
                var existingTempSubs = tempCrabSubmarines.FirstOrDefault(x => x.Position == submarine.Position);
                if (existingTempSubs != null)
                    existingTempSubs.Count += 1;
                else
                    tempCrabSubmarines.Add(submarine);
            }

            return tempCrabSubmarines;
        }
        
        public static int GetFuelCount(List<CrabSubmarineModel> crabSubmarines)
        {
            var currentMinimum = int.MaxValue;
            for (var i = 0; i < crabSubmarines.Max(x => x.Position); i++)
            {
                var runningTotal = 0;
                foreach (var subs in crabSubmarines)
                {
                    if(subs.Position > i)
                        runningTotal += ((subs.Position - i) * subs.Count);
                    else
                        runningTotal += ((i - subs.Position) * subs.Count);
                    
                    if (runningTotal > currentMinimum)
                        break;
                }

                if (runningTotal < currentMinimum)
                    currentMinimum = runningTotal;
            }

            return currentMinimum;
        }
        
        public static int GetIncreasingFuelCount(List<CrabSubmarineModel> crabSubmarines)
        {
            var currentMinimum = int.MaxValue;
            for (var i = 0; i < crabSubmarines.Max(x => x.Position); i++)
            {
                var runningTotal = 0;
                foreach (var subs in crabSubmarines)
                {
                    if (subs.Position > i)
                    {
                        var n = subs.Position - i;
                        runningTotal += ((n * (n + 1)) / 2) * subs.Count;
                    }
                    else
                    {
                        var n = i - subs.Position;
                        runningTotal += ((n * (n + 1)) / 2) * subs.Count;
                    }
                    
                    if (runningTotal > currentMinimum)
                        break;
                }

                if (runningTotal < currentMinimum)
                    currentMinimum = runningTotal;
            }

            return currentMinimum;
        }
    }
}
