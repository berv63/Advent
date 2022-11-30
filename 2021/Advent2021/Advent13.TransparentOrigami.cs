using System.Collections.Generic;
using System.Linq;
using AdventShared;

namespace Advent2021
{
    public static class TransparentOrigami
    {
        public static List<List<string>> CreateTransparentPaper(IEnumerable<List<string>> dots, List<List<string>> folds)
        {
            var xyCoordinates = dots.Select(x => (int.Parse(x[0]), int.Parse(x[1]))).ToList();

            var maxYDot = xyCoordinates.Max(x => x.Item2);
            var maxYFold = folds.Where(x => x[0] == "y").Max(x => int.Parse(x[1]) * 2);
            var maxY = maxYDot > maxYFold ? maxYDot : maxYFold;
            
            var maxXDot = xyCoordinates.Max(x => x.Item1);
            var maxXFold = folds.Where(x => x[0] == "x").Max(x => int.Parse(x[1]) * 2);
            var maxX = maxXDot > maxXFold ? maxXDot : maxXFold;
            
            var result = new List<List<string>>();
            for (var i = 0; i <= maxY; i++)
            {
                result.Add(new List<string>());
                for (var j = 0; j <= maxX; j++)
                {
                    var isDot = xyCoordinates.Any(x => x.Item1 == j && x.Item2 == i);
                    result[i].Add(isDot ? "#" : ".");
                }
            }

            return result;
        }

        public static int FoldDotsFinish(List<List<string>> paper, List<List<string>> folds)
        {
            foreach (var fold in folds)
            {
                if (fold[0] == "y")
                    paper = FoldUp(paper, int.Parse(fold[1]));

                if (fold[0] == "x")
                    paper = FoldLeft(paper, int.Parse(fold[1]));
            }
            
            OutputPaper(paper);
            return GetDotsCount(paper);
        }

        private static void OutputPaper(List<List<string>> paper)
        {
            FileExtensions.WriteFile(@"..\..\..\Files\Advent13\result.txt", paper.Select(x => string.Join("", x)).ToList());
        }

        public static int FoldDotsCount(List<List<string>> paper, List<List<string>> folds)
        {
            foreach (var fold in folds)
            {
                if (fold[0] == "y")
                    paper = FoldUp(paper, int.Parse(fold[1]));

                if (fold[0] == "x")
                    paper = FoldLeft(paper, int.Parse(fold[1]));

                break;
            }
            
            return GetDotsCount(paper);
        }

        private static int GetDotsCount(List<List<string>> paper)
        {
            return paper.Sum(x => x.Count(y => y == "#"));
        }
        
        private static List<List<string>> FoldUp(List<List<string>> paper, int yFold)
        {
            var result = new List<List<string>>();
            for (var i = 0; i < yFold; i++)
            {
                result.Add(new List<string>());
                for (var j = 0; j < paper[i].Count; j++)
                {
                    var yCoord = yFold + (yFold - i);
                    result[i].Add(paper[yCoord][j] == "#" || paper[i][j] == "#" ? "#" : ".");
                }
            }
            return result;
        }
        
        private static List<List<string>> FoldLeft(List<List<string>> paper, int xFold)
        {
            var result = new List<List<string>>();
            for (var i = 0; i < paper.Count; i++)
            {
                result.Add(new List<string>());
                for (var j = 0; j < xFold; j++)
                {
                    var xCoord = xFold + (xFold - j);
                    result[i].Add(paper[i][xCoord] == "#" || paper[i][j] == "#" ? "#" : ".");
                }
            }
            return result;
        }
    }
}