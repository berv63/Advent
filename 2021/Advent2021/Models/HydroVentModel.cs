using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Models
{
    public class HydroVentModel
    {
        public List<List<int>> Map { get; set; }

        public HydroVentModel(int maxX, int maxY)
        {
            Map = new List<List<int>>();

            for (int i = 0; i <= maxY; i++)
            {
                Map.Add(new List<int>());
                for (int j = 0; j <= maxX; j++)
                {
                    Map[i].Add(0);
                }
            }
        }

        public void MapPipe(HydroDirectionModel directions, bool skipDiagonal)
        {
            if (directions.Direction == VentDirectionEnum.horizontal)
            {
                for (var i = directions.StartY; i <= directions.EndY; i++)
                {
                    Map[directions.StartX][i] += 1;
                }
            }
            
            if (directions.Direction == VentDirectionEnum.vertical)
            {
                for (var i = directions.StartX; i <= directions.EndX; i++)
                {
                    Map[i][directions.StartY] += 1;
                }
            }

            if (directions.Direction == VentDirectionEnum.diagonalUp && !skipDiagonal)
            {
                var steps = directions.EndX - directions.StartX;
                for (int i = 0; i <= steps; i++)
                {
                    Map[directions.StartX + i][directions.StartY - i] += 1;
                }
            }

            if (directions.Direction == VentDirectionEnum.diagonalDown && !skipDiagonal)
            {
                var steps = directions.EndX - directions.StartX;
                for (int i = 0; i <= steps; i++)
                {
                    Map[directions.StartX + i][directions.StartY + i] += 1;
                }
            }
        }

        public int GetCountDanger()
        {
            return Map.Sum(row => row.Count(x => x > 1));
        }
    }
}