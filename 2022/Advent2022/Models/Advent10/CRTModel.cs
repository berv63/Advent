using AdventShared;

namespace Advent2022.Models.Advent10
{
    public class CRTModel
    {
        public List<List<char>> Screen { get; set; } = new ();

        public CRTModel()
        {
        }
        
        public int GetCountAt(List<Tuple<int, int>> commands, int tick, bool during = false)
        {
            var commandIndex = 0;
            var tickCount = 0;
            var value = 1;
            do
            {
                var tickCompare = during ? tick + 1 : tick;
                if (tickCount + commands[commandIndex].Item1 >= tickCompare)
                    break;

                value += commands[commandIndex].Item2;
                tickCount += commands[commandIndex].Item1;
            
                commandIndex++;
            } while (commandIndex < commands.Count);

            return value;
        }

        public void PopulateCRTScreen(List<Tuple<int, int>> commands)
        {
            var tickIndex = 0;
            for (var i = 0; i < 6; i++)
            {
                var tickCompare = 0;
                Screen.Add(new List<char>());
                for (var j = 0; j < 40; j++)
                {
                    var count = GetCountAt(commands, tickIndex++, true);
                    Screen[i].Add(Math.Abs(count - tickCompare++) <= 1 ? '#' : '.');
                }
            }
        }

        public void PrintCRT()
        {
            FileExtensions.WriteFile($@"..\..\..\..\{FileExtensions.GetFileOutputLocation("Advent10", $"CRTOutput")}", Screen.Select(x => string.Join("", x)));
        }
    }
}