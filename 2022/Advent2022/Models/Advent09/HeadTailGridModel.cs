using AdventShared;

namespace Advent2022.Models.Advent09
{
    public class HeadTailGridModel
    {
        public List<List<HeadTailLocationModel>> Grid { get; set; }
        public HeadTailIndexModel HeadTailIndex { get; set; }

        public HeadTailGridModel(int indices)
        {
            Grid = new List<List<HeadTailLocationModel>> { new (){ new HeadTailLocationModel(indices) } };
            HeadTailIndex = new HeadTailIndexModel(indices);
        }
        
        public void PrintCurrentMapping()
        {
            var gridPrint = Grid.Select(x => x.Select(y => y.CurrentItem != null ? y.CurrentItem.Value.ToString() : "."));
            FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent09", $"GridOutput")}", gridPrint.Select(x => string.Join("", x)));
        }
        
        public void PrintGrid(int index)
        {
            var gridPrint = Grid.Select(x => x.Select(y => y.IndexesVisited.Contains(index) ? index.ToString() : "."));
            FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent09", $"GridOutput{index}")}", gridPrint.Select(x => string.Join("", x)));
        }
        
        public void RunCommand(HeadTailCommandModel command)
        {
            for (var i = 0; i < command.Distance; i++)
            {
                GetCurrentHeadLocation().IsCurrentLocation = false;
                
                HeadTailIndex.UpdateCurrentHeadCoordinates(command);
                
                GetCurrentHeadLocation().IndexesVisited.Add(0);
                GetCurrentHeadLocation().CurrentItem = null;
                HeadTailIndex.HeadCoordinates.DirectionMoved = command.Direction.ToString();
                GetCurrentHeadLocation().IsCurrentLocation = true;

                for (var j = 1; j < HeadTailIndex.Coordinates.Count; j++)
                {
                    if (!HeadTailIndex.AreNodesAdjacent(j-1, j))
                    {
                        HeadTailIndex.UpdateCurrentTailCoordinates(j, command);
                        GetCurrentTailLocation(j).IndexesVisited.Add(j);
                        GetCurrentHeadLocation().CurrentItem = j;
                    }
                }
            }
        }

        private HeadTailLocationModel GetCurrentHeadLocation()
        {
            return Grid[HeadTailIndex.HeadCoordinates.XCoordinate][HeadTailIndex.HeadCoordinates.YCoordinate];
        }

        private HeadTailLocationModel GetCurrentTailLocation(int index)
        {
            return Grid[HeadTailIndex.GetLocationByIndex(index).XCoordinate][HeadTailIndex.GetLocationByIndex(index).YCoordinate];
        }
        
        public void MoveHead(HeadTailCommandModel commandModel)
        {
            switch (commandModel.Direction)
            {
                case 'U':
                    MoveUp(commandModel);
                    break;
                case 'D':
                    MoveDown(commandModel);
                    break;
                case 'L':
                    MoveLeft(commandModel);
                    break;
                case 'R':
                    MoveRight(commandModel);
                    break;
            }
        }

        private void MoveUp(HeadTailCommandModel commandModel)
        {
            for (var i = 0; i < commandModel.Distance; i++)
            {
                if (HeadTailIndex.IsHeadAboutToRunOffTopEdge())
                { 
                    AddNewRowUp();
                }
                else
                {
                    HeadTailIndex.AdjustCurrentHeadCoordinates(-1, 0);
                }
            }
        }

        private void MoveDown(HeadTailCommandModel commandModel)
        {
            for (var i = 0; i < commandModel.Distance; i++)
            {
                if (HeadTailIndex.IsHeadAboutToRunOffBottomEdge(this))
                {
                    AddNewRowDown();
                }
                
                HeadTailIndex.AdjustCurrentHeadCoordinates(1, 0);
            }
        }

        private void MoveLeft(HeadTailCommandModel commandModel)
        {
            for (var i = 0; i < commandModel.Distance; i++)
            {
                if (HeadTailIndex.IsHeadAboutToRunOffLeftEdge())
                {
                    AddNewColumnLeft();
                }
                else
                {
                    HeadTailIndex.AdjustCurrentHeadCoordinates(0, -1);
                }
            }
        }

        private void MoveRight(HeadTailCommandModel commandModel)
        {
            for (var i = 0; i < commandModel.Distance; i++)
            {
                if (HeadTailIndex.IsHeadAboutToRunOffRightEdge(this))
                {
                    AddNewColumnRight();
                }
                
                HeadTailIndex.AdjustCurrentHeadCoordinates(0, 1);
            }
        }
        
        private void AddNewRowUp()
        {
            Grid.Add(new List<HeadTailLocationModel>());
            for (var j = Grid.Count - 1; j >  0; j--)
            {
                Grid[j] = Grid[j - 1].CopyValues();
            }

            for (var j = 0; j < Grid[0].Count; j++)
            {
                Grid[0][j] = new HeadTailLocationModel();
            }
        }

        private void AddNewRowDown()
        {
            var length = Grid.Last().Count();
            Grid.Add(new List<HeadTailLocationModel>());
            for (var j = 0; j < length; j++)
            {
                Grid.Last().Add(new HeadTailLocationModel());
            }
        }

        private void AddNewColumnLeft()
        {
            for (var j = Grid.Count - 1; j >= 0; j--)
            {
                Grid[j].Add(new HeadTailLocationModel());
                Grid[j].ShiftRight(); 
            }
        }

        private void AddNewColumnRight()
        {
            foreach (var item in Grid)
            {
                item.Add(new HeadTailLocationModel());
            }
        }

        public int GetTailVisitCount(int index)
        {
            var result = 0;
            foreach (var row in Grid)
            {
                result += row.Count(x => x.IndexesVisited.Contains(index));
            }

            return result;
        }
    }
}