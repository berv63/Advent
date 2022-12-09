using System.Data;
using AdventShared;

namespace Advent2022.Models
{
    public class HeadTailGridModel
    {
        public List<List<HeadTailLocationModel>> Grid { get; set; }
        public HeadTailIndexModel HeadTailIndex { get; set; }

        public HeadTailGridModel(int indices)
        {
            Grid = new List<List<HeadTailLocationModel>> { new (){ new HeadTailLocationModel(true) } };
            HeadTailIndex = new HeadTailIndexModel(indices);
        }

        public void RunCommand(HeadTailCommandModel command)
        {
            for (var i = 0; i < command.Distance; i++)
            {
                GetCurrentHeadLocation().IsCurrentLocation = false;
                
                HeadTailIndex.UpdateCurrentHeadCoordinates(command);
                
                GetCurrentHeadLocation().HasHeadVisited = true;
                GetCurrentHeadLocation().IsCurrentLocation = true;

                for (var j = 0; j < HeadTailIndex.Coordinates.Count - 1; j++)
                {
                    if (!HeadTailIndex.AreNodesAdjacent(j, j+1))
                    {
                        HeadTailIndex.UpdateCurrentTailCoordinates(j+1, command);
                        GetCurrentTailLocation(j+1).HasTailVisited = true;
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
        
        public void PrintGrid()
        {
            var gridPrint = Grid.Select(x => x.Select(y => y.HasTailVisited ? "T" : "."));
            FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent09", "GridOutput")}", gridPrint.Select(x => string.Join("", x)));
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
            for (var j = Grid.Count - 1; j > 0; j--)
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
            for (var j = Grid.Count - 1; j > 0; j--)
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

        public int GetTailVisitCount()
        {
            var result = 0;
            foreach (var row in Grid)
            {
                result += row.Count(x => x.HasTailVisited);
            }

            return result;
        }
    }
}