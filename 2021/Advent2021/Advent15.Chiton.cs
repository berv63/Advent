using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;

namespace Advent2021
{
    public static class Chiton
    {
        public static List<List<List<List<ChitonRiskModel>>>> BuildRiskSegments(List<List<ChitonRiskModel>> chitonRiskMap, ref int index)
        {
            var chitonRiskMapSegments = new List<List<List<List<ChitonRiskModel>>>>();
            
            for (var i = 0; i < 5; i++)
            {
                chitonRiskMapSegments.Add(new List<List<List<ChitonRiskModel>>>());
                for (var j = 0; j < 5; j++)
                {
                    chitonRiskMapSegments[i].Add(new List<List<ChitonRiskModel>>());
                    BuildSegment(chitonRiskMap, chitonRiskMapSegments[i][j], ref index, i, j);
                }
            }
            
            return chitonRiskMapSegments;
        }

        public static List<List<ChitonRiskModel>> ConvertSegments(List<List<List<List<ChitonRiskModel>>>> riskSegments)
        {
            var result = new List<List<ChitonRiskModel>>();
            for (var i = 0; i < riskSegments.Count; i++)
            {
                for (var z = 0; z < riskSegments[i][0].Count; z++)
                {
                    result.Add(new List<ChitonRiskModel>());
                }
                
                for (var j = 0; j < riskSegments[i].Count; j++)
                {
                    for (var x = 0; x < riskSegments[i][j].Count; x++)
                    {
                        for (var y = 0; y < riskSegments[i][j][x].Count; y++)
                        {
                            result[riskSegments[i][j][x].Count * i + x].Add(riskSegments[i][j][x][y]);
                        }
                    }
                }
            }

            return result;
        }

        private static void BuildSegment(IReadOnlyList<List<ChitonRiskModel>> chitonRiskMap, IList<List<ChitonRiskModel>> segment, ref int index, int iDistance, int jDistance)
        {
            for (var i = 0; i < chitonRiskMap.Count; i++)
            {
                segment.Add(new List<ChitonRiskModel>());
                for (var j = 0; j < chitonRiskMap[i].Count; j++)
                {
                    segment[i].Add(new ChitonRiskModel(chitonRiskMap[i][j].Risk, ++index, iDistance + jDistance));
                }
            }
        }

        public static List<List<ChitonRiskModel>> BuildChitonRiskMap(List<List<ChitonRiskModel>> chitonRiskMap)
        {
            for(var i = chitonRiskMap.Count - 1; i >= 0; i--)
            {
                for (var j = chitonRiskMap[0].Count - 1; j >= 0; j--)
                {
                    if (i == 0 && j == 0)
                        chitonRiskMap[i][j].MinRisk = 0;
                    
                    if (j != chitonRiskMap[0].Count - 1)
                    {
                        chitonRiskMap[i][j].Neighbors.Add(chitonRiskMap[i][j + 1]);
                    }
                    
                    if (i != chitonRiskMap.Count - 1)
                    {
                        chitonRiskMap[i][j].Neighbors.Add(chitonRiskMap[i + 1][j]);
                    }
                    
                    if (j != 0)
                    {
                        chitonRiskMap[i][j].Neighbors.Add(chitonRiskMap[i][j - 1]);
                    }
                    
                    if (i != 0)
                    {
                        chitonRiskMap[i][j].Neighbors.Add(chitonRiskMap[i - 1][j]);
                    }
                }
            }
            
            return chitonRiskMap;
        }

        public static long CalculatePathRisk(List<List<ChitonRiskModel>> chitonRiskMap, int index)
        {
            var firstItem = chitonRiskMap[0][0]; 
            var neighborList = new List<ChitonRiskModel> {firstItem};
            ChitonRiskModel smallestNeighbor;
            do
            {
                var minNeighborRisk = neighborList.Min(y => y.MinRisk);
                smallestNeighbor = neighborList.FirstOrDefault(x => x.MinRisk == minNeighborRisk && !x.Visited);

                if (smallestNeighbor != null && smallestNeighbor.Index != index)
                {
                    smallestNeighbor.CalculateNeighborRisk();
                    neighborList.Remove(smallestNeighbor);

                    var neighborListIndices = neighborList.Select(x => x.Index).ToList();
                    neighborList.AddRange(smallestNeighbor.Neighbors.Where(x => !x.Visited && !neighborListIndices.Contains(x.Index)));
                }
                
            } while (smallestNeighbor.Index != index);

            return smallestNeighbor.MinRisk; 
        }
    }
}