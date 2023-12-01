namespace Advent2022.Models.Advent09
{
    public class HeadTailIndexModel
    {
        public List<CoordinatesModel> Coordinates { get; set; } = new();
        
        public CoordinatesModel HeadCoordinates => Coordinates.Single(x => x.Index == 0);

        public HeadTailIndexModel(int indices)
        {
            for (int i = 0; i <= indices; i++)
            {
                Coordinates.Add(new CoordinatesModel(i, 0, 0));   
            }
        }
        
        public HeadTailIndexModel(List<List<HeadTailLocationModel>> grid, int indices)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[0].Count; j++)
                {
                    if (grid[i][j].IsCurrentLocation)
                    {
                        for (int k = 0; k <= indices; k++)
                        {
                            Coordinates.Add(new CoordinatesModel(k, i, j));   
                        }
                    }
                }
            }
        }

        public void UpdateCurrentHeadCoordinates(HeadTailCommandModel command)
        {
            switch (command.Direction)
            {
                case 'U':
                    AdjustCurrentHeadCoordinates(-1, 0);
                    break;
                case 'D':
                    AdjustCurrentHeadCoordinates(1, 0);
                    break;
                case 'L':
                    AdjustCurrentHeadCoordinates(0, -1);
                    break;
                case 'R':
                    AdjustCurrentHeadCoordinates(0, 1);
                    break;
            }
        }
        
        public void AdjustCurrentHeadCoordinates(int headXDifference, int headYDifference)
        {
            HeadCoordinates.XCoordinate += headXDifference;
            HeadCoordinates.YCoordinate += headYDifference;
        }
        
        public void UpdateCurrentTailCoordinates(int index, HeadTailCommandModel command)
        {
            var previousLocation = GetLocationByIndex(index - 1);
            var currentLocation = GetLocationByIndex(index);

            var xCoord = currentLocation.XCoordinate;
            var yCoord = currentLocation.YCoordinate;
            
            if(previousLocation.DirectionMoved.Contains("U"))
                xCoord = currentLocation.XCoordinate - 1;
            if(previousLocation.DirectionMoved.Contains("D"))
                xCoord = currentLocation.XCoordinate + 1;
            if (previousLocation.DirectionMoved.Contains("L"))
                yCoord = currentLocation.YCoordinate - 1;
            if(previousLocation.DirectionMoved.Contains("R"))
                yCoord = currentLocation.YCoordinate + 1;
            
            SetCurrentTailCoordinates(index, xCoord, yCoord);
        }

        private void SetCurrentTailCoordinates(int index, int xCoordinate, int yCoordinate)
        {
            var currentTail = Coordinates.Single(x => x.Index == index);

            currentTail.DirectionMoved = "";
            if (xCoordinate - currentTail.XCoordinate == 1)
                currentTail.DirectionMoved += "D";
            if (xCoordinate - currentTail.XCoordinate == -1)
                currentTail.DirectionMoved += "U";
            if (yCoordinate - currentTail.YCoordinate == -1)
                currentTail.DirectionMoved += "L";
            if (yCoordinate - currentTail.YCoordinate == 1)
                currentTail.DirectionMoved += "R"; 
                
            currentTail.XCoordinate = xCoordinate;
            currentTail.YCoordinate = yCoordinate;
        }


        public bool IsHeadAboutToRunOffTopEdge()
        {
            return HeadCoordinates.XCoordinate <= 0;
        }

        public bool IsHeadAboutToRunOffBottomEdge(HeadTailGridModel grid)
        {
            return HeadCoordinates.XCoordinate >= grid.Grid.Count - 1;
        }

        public bool IsHeadAboutToRunOffLeftEdge()
        {
            return HeadCoordinates.YCoordinate <= 0;
        }
        
        public bool IsHeadAboutToRunOffRightEdge(HeadTailGridModel grid)
        {
            return HeadCoordinates.YCoordinate >= grid.Grid[HeadCoordinates.XCoordinate].Count - 1;
        }

        public bool AreNodesAdjacent(int index1, int index2)
        {
            return AreClose(GetLocationByIndex(index1).XCoordinate, GetLocationByIndex(index2).XCoordinate) && AreClose(GetLocationByIndex(index1).YCoordinate, GetLocationByIndex(index2).YCoordinate);
        }

        private bool AreClose(int value1, int value2)
        {
            return Math.Abs(value1 - value2) <= 1;
        }

        public CoordinatesModel GetLocationByIndex(int index)
        {
            return Coordinates.Single(x => x.Index == index);
        }
    }
}