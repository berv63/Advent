using System.Collections.Generic;
using Advent2021.Models;

namespace Advent2021
{
    public static class DumboOctopus
    {
        public static int AllFlashedStep(List<List<DumboOctopusModel>> octopusMap, int steps)
        {
            var stepFlashes = 0;
            var index = 0;

            do
            {
                index++;
                IncreaseEnergy(octopusMap);
                stepFlashes = GetStepFlashes(octopusMap);
            } while (stepFlashes < 100);
            
            return index;
        }
        
        public static int GetFlashCount(List<List<DumboOctopusModel>> octopusMap, int steps)
        {
            var totalFlashes = 0;
            for (var i = 0; i < steps; i++)
            {
                IncreaseEnergy(octopusMap);
                totalFlashes += GetStepFlashes(octopusMap);
            }
            return totalFlashes;
        }

        private static void IncreaseEnergy(List<List<DumboOctopusModel>> octopusMap)
        {
            for (var i = 0; i < octopusMap.Count; i++)
            {
                for (var j = 0; j < octopusMap[0].Count; j++)
                {
                    octopusMap[i][j].EnergyLevel += 1;
                    octopusMap[i][j].Flashed = false;
                }
            }
        }
        
        private static int GetStepFlashes(List<List<DumboOctopusModel>> octopusMap)
        {
            var result = 0;
            
            for (var i = 0; i < octopusMap.Count; i++)
            {
                for (var j = 0; j < octopusMap[0].Count; j++)
                {
                    if(octopusMap[i][j].EnergyLevel > 9)
                        result += GetFlashCount(i, j, octopusMap);
                }
            }
            return result;
        }

        private static int GetFlashCount(int i, int j, List<List<DumboOctopusModel>> octopusMap)
        {
            if (octopusMap[i][j].Flashed)
                return 0;

            octopusMap[i][j].EnergyLevel += 1;
            
            if (octopusMap[i][j].EnergyLevel > 9)
            {
                var flashCount = 1;
                octopusMap[i][j].EnergyLevel = 0;
                octopusMap[i][j].Flashed = true;

                if (i + 1 < octopusMap.Count)
                {
                    flashCount += GetFlashCount(i + 1, j, octopusMap);
                    
                    if(j + 1 < octopusMap[0].Count)
                        flashCount += GetFlashCount(i + 1, j + 1, octopusMap);

                    if(j - 1 >= 0)
                        flashCount += GetFlashCount(i + 1, j - 1, octopusMap);
                }

                if (i - 1 >= 0)
                {
                    flashCount += GetFlashCount(i - 1, j, octopusMap);
                    
                    if(j + 1 < octopusMap[0].Count)
                        flashCount += GetFlashCount(i - 1, j + 1, octopusMap);

                    if(j - 1 >= 0)
                        flashCount += GetFlashCount(i - 1, j - 1, octopusMap);
                }
                
                if (j + 1 < octopusMap[0].Count)
                    flashCount += GetFlashCount(i, j + 1, octopusMap);
                if (j - 1 >= 0)
                    flashCount += GetFlashCount(i, j - 1, octopusMap);
                
                return flashCount;
            }
            
            return 0;
        }
    }
}
