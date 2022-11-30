using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Models
{
    public class ChitonRiskModel
    {
        public int Risk { get; set; }
        public long MinRisk { get; set; }
        public bool Visited { get; set; }
        public int Index { get; set; }

        public List<ChitonRiskModel> Neighbors { get; set; } = new List<ChitonRiskModel>();

        public ChitonRiskModel(int risk, int index)
        {
            Risk = risk;
            Visited = false;
            MinRisk = long.MaxValue;
            Index = index;
        }
        
        public ChitonRiskModel(int risk, int index, int distance)
        {
            Risk = risk + distance > 9 ? (risk + distance) % 9 : risk + distance;
            if (Risk == 0)
                Risk++;
            
            Visited = false;
            MinRisk = long.MaxValue;
            Index = index;
        }

        public void CalculateNeighborRisk()
        {
            if (Visited) return;
            
            foreach (var chitonRiskModel in Neighbors.Where(x => !x.Visited))
            {
                UpdateRisk(chitonRiskModel);
            }

            Visited = true;
        }

        private void UpdateRisk(ChitonRiskModel model)
        {
            if (model == null) return;
            
            var thisRisk = MinRisk + model.Risk;
            if (model.MinRisk >= thisRisk)
                model.MinRisk = thisRisk;
        }
    }
}