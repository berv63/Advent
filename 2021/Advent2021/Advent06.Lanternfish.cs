using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;

namespace Advent2021
{
    public static class Lanternfish
    {
        public static long SpawnLanternfish(List<LanternfishModel> fishes, int days)
        {
            for (var i = 0; i < days; i++)
            {
                var fishesToAdd = new List<LanternfishModel>();
                foreach (var fish in fishes)
                {
                    if (fish.Age == 0)
                    {
                        fish.Age = 6;
                        fishesToAdd.Add(new LanternfishModel(8, fish.Count));
                    }
                    else
                    {
                        fish.Age--;
                    }
                }
                
                fishes.AddRange(fishesToAdd);

                var tempFishes = new List<LanternfishModel>();
                foreach (var fish in fishes)
                {
                    var existingTempFishes = tempFishes.FirstOrDefault(x => x.Age == fish.Age);
                    if (existingTempFishes != null)
                        existingTempFishes.Count += fish.Count;
                    else
                        tempFishes.Add(fish);
                }

                fishes = tempFishes;
            }

            return fishes.Sum(x => x.Count);
        }
    }
}