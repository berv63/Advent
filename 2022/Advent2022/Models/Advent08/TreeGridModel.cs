namespace Advent2022.Models
{
    public class TreeGridModel
    {
        public List<List<int>> TreeGrid { get; set; }
        
        public TreeGridModel(List<string> fileData)
        {
            TreeGrid = fileData.Select(row => row.Select(x => int.Parse(x.ToString())).ToList()).ToList();
        }
        
        public int GetVisibleTreeCount()
        {
            var result = TreeGrid.Count * 2 + TreeGrid[0].Count * 2 - 4;
            for (var row = 1; row < (TreeGrid.Count - 1); row++)
            {
                for (var column = 1; column < TreeGrid[row].Count - 1; column++)
                {
                    var visible = IsVisible(row, column);
                    if (visible != null)
                        result++;
                }
            }

            return result;
        }

        private (int, int)? IsVisible(int row, int column)
        {
            if(IsVisibleLeft(row, column) || IsVisibleRight(row, column)  || IsVisibleUp(row, column) || IsVisibleDown(row, column))
                return (row,column);

            return null;
        }

        private bool IsVisibleLeft(int row, int column)
        {
            var value = TreeGrid[row][column];
            for (var i = 0; i < column; i++)
            {
                if (TreeGrid[row][i] >= value)
                    return false;
            }

            return true;
        }

        private bool IsVisibleRight(int row, int column)
        {
            var value = TreeGrid[row][column];
            for (var i = column + 1; i < TreeGrid[row].Count; i++)
            {
                if (TreeGrid[row][i] >= value)
                    return false;
            }

            return true;
        }

        private bool IsVisibleUp(int row, int column)
        {
            var value = TreeGrid[row][column];
            for (var i = 0; i < row; i++)
            {
                if (TreeGrid[i][column] >= value)
                    return false;
            }

            return true;
        }

        private bool IsVisibleDown(int row, int column)
        {
            var value = TreeGrid[row][column];
            for (var i = row + 1; i < TreeGrid.Count; i++)
            {
                if (TreeGrid[i][column] >= value)
                    return false;
            }

            return true;
        }
        
        
    
        public int GetScenicScore()
        {
            var topScore = 0;
            for (var row = 1; row < (TreeGrid.Count - 1); row++)
            {
                for (var column = 1; column < TreeGrid[row].Count - 1; column++)
                {
                    var score = GetScenicScore(row, column);
                    if (score > topScore)
                    {
                        topScore = score;
                    }
                }
            }

            return topScore;
        }
        
        private int GetScenicScore(int row, int column)
        {
            return GetDistanceLeft(row, column) * GetDistanceRight(row, column) * GetDistanceUp(row, column) * GetDistanceDown(row, column);
        }
        
        private int GetDistanceLeft(int row, int column)
        {
            var result = 0;
            var value = TreeGrid[row][column];
            for (var i = column - 1; i >= 0; i--)
            {
                result++;
                if (TreeGrid[row][i] >= value)
                    break;
            }

            return result;
        }

        private int GetDistanceRight(int row, int column)
        {
            var result = 0;
            var value = TreeGrid[row][column];
            for (var i = column + 1; i < TreeGrid[row].Count; i++)
            {
                result++;
                if (TreeGrid[row][i] >= value)
                    break;
            }

            return result;
        }

        private int GetDistanceUp(int row, int column)
        {
            var result = 0;
            var value = TreeGrid[row][column];
            for (var i = row - 1; i >= 0; i--)
            {
                result++;
                if (TreeGrid[i][column] >= value)
                    break;
            }

            return result;
        }

        private int GetDistanceDown(int row, int column)
        {
            var result = 0;
            var value = TreeGrid[row][column];
            for (var i = row + 1; i < TreeGrid.Count; i++)
            {
                result++;
                if (TreeGrid[i][column] >= value)
                    break;
            }

            return result;
        }
        
    }
}