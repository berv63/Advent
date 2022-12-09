namespace Advent2022.Models
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
            switch (command.Direction)
            {
                case 'U':
                    SetCurrentTailCoordinates(index, HeadCoordinates.XCoordinate + 1, HeadCoordinates.YCoordinate);
                    break;
                case 'D':
                    SetCurrentTailCoordinates(index, HeadCoordinates.XCoordinate - 1, HeadCoordinates.YCoordinate);
                    break;
                case 'L':
                    SetCurrentTailCoordinates(index, HeadCoordinates.XCoordinate, HeadCoordinates.YCoordinate + 1);
                    break;
                case 'R':
                    SetCurrentTailCoordinates(index, HeadCoordinates.XCoordinate, HeadCoordinates.YCoordinate - 1);
                    break;
            }
        }

        private void SetCurrentTailCoordinates(int index, int xCoordinate, int yCoordinate)
        {
            Coordinates.Single(x => x.Index == index).XCoordinate = xCoordinate;
            Coordinates.Single(x => x.Index == index).YCoordinate = yCoordinate;
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