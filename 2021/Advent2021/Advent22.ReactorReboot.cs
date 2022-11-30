using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using Advent2021.Models;

namespace Advent2021
{
    public static class ReactorReboot
    {
        public static List<List<ReactorRebootInstructionModel>> GroupInstructionModels(
            List<ReactorRebootInstructionModel> instructions)
        {
            var result = new List<List<ReactorRebootInstructionModel>>();
            
            var currentList = new List<ReactorRebootInstructionModel>();
            var currentInstruction = instructions.First().OnOff;
            foreach (var instruction in instructions)
            {
                if(instruction.OnOff == currentInstruction)
                    currentList.Add(instruction);
                else
                {
                    result.Add(currentList);
                    currentInstruction = instruction.OnOff;
                    currentList = new List<ReactorRebootInstructionModel> {instruction};
                }
            }

            return result;
        }

        public static long RebootMore(Dictionary<int, Dictionary<int, Dictionary<int, bool>>> reactor,
            List<List<ReactorRebootInstructionModel>> instructionGroups)
        {
            foreach (var instructionGroup in instructionGroups)
            {
                var minX = instructionGroup.Min(x => x.MinX);
                var maxX = instructionGroup.Min(x => x.MaxX);
                
                for (var x = minX; x <= maxX; x++)
                {
                    var subGroupX = instructionGroup.Where(a => a.MinX < x && a.MaxX > x).ToList();
                    if (!subGroupX.Any()) continue;
                    
                    if (!reactor.ContainsKey(x) && subGroupX.First().OnOff)
                        reactor.Add(x, new Dictionary<int, Dictionary<int, bool>>());

                    if (!reactor.ContainsKey(x)) continue;

                    var minY = subGroupX.Min(y => y.MinX);
                    var maxY = subGroupX.Min(y => y.MaxX);

                    for (var y = minY; y <= maxY; y++)
                    {
                        var subGroupXY = subGroupX.Where(a => a.MinY < y && a.MaxY > y).ToList();
                        if (!subGroupXY.Any()) continue;
                        
                        if (!reactor.ContainsKey(x) && subGroupXY.First().OnOff)
                            reactor.Add(x, new Dictionary<int, Dictionary<int, bool>>());
                        
                        if (!reactor[x].ContainsKey(y) && subGroupXY.First().OnOff)
                            reactor[x].Add(y, new Dictionary<int, bool>());

                        if (!reactor[x].ContainsKey(y)) continue;
                        
                        var minZ = subGroupXY.Min(z => z.MinZ);
                        var maxZ = subGroupXY.Min(z => z.MaxZ);

                        for (var z = minZ; z <= maxZ; z++)
                        {
                            var subGroupXYZ = subGroupX.FirstOrDefault(a => a.MinZ < z && a.MaxZ > y);
                            if (subGroupXYZ == null) continue;
                            
                            if (!reactor[x][y].ContainsKey(z) && subGroupXYZ.OnOff)
                                reactor[x][y].Add(z, subGroupXYZ.OnOff);
                            else if (reactor[x][y].ContainsKey(z) && !subGroupXYZ.OnOff)
                                reactor[x][y].Remove(z);
                        }

                        if (!reactor[x][y].Any())
                            reactor[x].Remove(y);
                    }

                    if (!reactor[x].Any())
                        reactor.Remove(x);
                }
            }
            
            return reactor.Values.Sum(x => x.Values.Sum(y => y.Values.Sum(z => z ? (long)1 : 0)));
        }


        public static long RebootMore(Dictionary<int, Dictionary<int, Dictionary<int, bool>>> reactor, IEnumerable<ReactorRebootInstructionModel> instructions)
        {
            foreach (var instruction in instructions)
            {
                for (var x = instruction.MinX; x <= instruction.MaxX; x++)
                {
                    if (!reactor.ContainsKey(x) && instruction.OnOff)
                        reactor.Add(x, new Dictionary<int, Dictionary<int, bool>>());

                    if (!reactor.ContainsKey(x)) continue;
                    
                    for (var y = instruction.MinY; y <= instruction.MaxY; y++)
                    {
                        if (!reactor[x].ContainsKey(y) && instruction.OnOff)
                            reactor[x].Add(y, new Dictionary<int, bool>());
                        
                        if (!reactor[x].ContainsKey(y)) continue;
                        
                        for (var z = instruction.MinZ; z <= instruction.MaxZ; z++)
                        {
                            if (!reactor[x][y].ContainsKey(z) && instruction.OnOff)
                                reactor[x][y].Add(z, instruction.OnOff);
                            else if (reactor[x][y].ContainsKey(z) && !instruction.OnOff)
                                reactor[x][y].Remove(z);
                        }

                        if (!reactor[x][y].Any())
                            reactor[x].Remove(y);
                    }
                    
                    if (!reactor[x].Any())
                        reactor.Remove(x);
                }
            }

            return reactor.Values.Sum(x => x.Values.Sum(y => y.Values.Sum(z => z ? (long)1 : 0)));
        }
        
        public static (int, int, int, int, int, int) GetMinMax(List<ReactorRebootInstructionModel> instructions)
        {
            var minX = instructions.Min(x => x.MinX);
            var maxX = instructions.Max(x => x.MaxX);
            var minY = instructions.Min(x => x.MinY);
            var maxY = instructions.Max(x => x.MaxY);
            var minZ = instructions.Min(x => x.MinZ);
            var maxZ = instructions.Max(x => x.MaxZ);
            return (minX, maxX, minY, maxY, minZ, maxZ);
        }
        
        public static Dictionary<int, Dictionary<int, Dictionary<int, bool>>> BuildReactor((int, int, int, int, int, int) minMax)
        {
            var reactor = new Dictionary<int, Dictionary<int, Dictionary<int, bool>>>();
            for (var i = minMax.Item1; i <= minMax.Item2; i++)
            {
                reactor.Add(i, new Dictionary<int, Dictionary<int, bool>>());
                for (var j = minMax.Item3; j <= minMax.Item4; j++)
                {
                    reactor[i].Add(j, new Dictionary<int, bool>());
                    for (var k = minMax.Item5; k < minMax.Item6; k++)
                    {
                        reactor[i][j].Add(k, false);
                    }
                }
            }

            return reactor;
        }
        
        public static long Reboot(Dictionary<int, Dictionary<int, Dictionary<int, bool>>> reactor, IEnumerable<ReactorRebootInstructionModel> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (!reactor.ContainsKey(instruction.MinX) || !reactor.ContainsKey(instruction.MaxX))
                    continue;
                
                for (var x = instruction.MinX; x <= instruction.MaxX; x++)
                {
                    if (!reactor[x].ContainsKey(instruction.MinY) || !reactor[x].ContainsKey(instruction.MaxY))
                        continue;
                    
                    for (var y = instruction.MinY; y <= instruction.MaxY; y++)
                    {
                        if (!reactor[x][y].ContainsKey(instruction.MinZ) || !reactor[x][y].ContainsKey(instruction.MaxZ))
                            continue;
                        
                        for (var z = instruction.MinZ; z <= instruction.MaxZ; z++)
                        {
                            reactor[x][y][z] = instruction.OnOff;
                        }
                    }
                }
            }

            return reactor.Values.Sum(x => x.Values.Sum(y => y.Values.Sum(z => z ? (long)1 : 0)));
        }
    }
}