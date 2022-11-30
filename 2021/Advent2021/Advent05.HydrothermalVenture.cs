using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;

namespace Advent2021
{
    public static class HydrothermalVenture
    {
        public static int GetDangerCount(List<HydroDirectionModel> models, bool skipDiagonal)
        {
            var maxX = models.Max(x => x.EndX);
            var maxY = models.Max(x => x.EndY);
            var grid = new HydroVentModel(maxX, maxY);

            foreach (var direction in models)
            {
                grid.MapPipe(direction, skipDiagonal);
            }

            return grid.GetCountDanger();
        }
    }
}