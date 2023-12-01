namespace Advent2022.Models.Advent09
{
    public class HeadTailLocationModel
    {
        public bool IsCurrentLocation { get; set; }

        public int? CurrentItem { get; set; }
        public List<int> IndexesVisited { get; set; } = new List<int>();

        public HeadTailLocationModel(int? indices = null)
        {
            IsCurrentLocation = indices.HasValue;
            if (indices.HasValue)
            {
                for (var i = 0; i <= indices; i++)
                {
                    IndexesVisited.Add(i);
                }
            }
        }
    }
}