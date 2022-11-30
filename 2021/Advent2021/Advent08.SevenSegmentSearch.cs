using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;

namespace Advent2021
{
    public static class SevenSegmentSearch
    {
        private static readonly List<int> uniqueResultLengths = new List<int> {2, 3, 4, 7};

        public static int GetResultSummation(List<NumericDisplayModel> models)
        {
            var resultSummation = 0;
            foreach (var displayModel in models)
            {
                displayModel.DeterminePositions();
                displayModel.DetermineResult();
                resultSummation += displayModel.GetResultInt();
            }

            return resultSummation;
        }
        
        public static int GetUniqueCount(IEnumerable<NumericDisplayModel> models)
        {
            return models.Sum(display => display.JumbledResults.Count(x => uniqueResultLengths.Contains(x.Length)));
        }
    }
}
