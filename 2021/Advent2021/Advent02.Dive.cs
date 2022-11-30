using System.Collections.Generic;
using Advent2021.Models;

namespace Advent2021
{
    public static class Dive
    {
        public static int GetFinalAimDestinationMultiplier(List<DiveModel> models)
        {
            var (depth, horizontal) = GetAimPositions(models);
            return depth * horizontal;
        }
        
        private static (int, int) GetAimPositions(List<DiveModel> models)
        {
            var aim = 0;
            var depth = 0;
            var horizontal = 0;

            foreach (var model in models)
            {
                switch (model.Direction)
                {
                    case DirectionEnum.forward:
                        horizontal += model.Distance;
                        depth += aim * model.Distance;
                        break;
                    case DirectionEnum.down:
                        aim += model.Distance;
                        break;
                    case DirectionEnum.up:
                        aim -= model.Distance;
                        break;
                }
            }

            return (depth, horizontal);
        }
        
        public static int GetFinalDestinationMultiplier(List<DiveModel> models)
        {
            var (depth, horizontal) = GetFuturePositions(models);
            return depth * horizontal;
        }
        
        private static (int, int) GetFuturePositions(List<DiveModel> models)
        {
            var depth = 0;
            var horizontal = 0;

            foreach (var model in models)
            {
                switch (model.Direction)
                {
                    case DirectionEnum.forward:
                        horizontal += model.Distance;
                        break;
                    case DirectionEnum.down:
                        depth += model.Distance;
                        break;
                    case DirectionEnum.up:
                        depth -= model.Distance;
                        break;
                }
            }

            return (depth, horizontal);
        }
    }
}