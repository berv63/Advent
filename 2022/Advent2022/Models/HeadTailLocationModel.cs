namespace Advent2022.Models
{
    public class HeadTailLocationModel
    {
        public bool IsCurrentLocation { get; set; }
        public bool HasHeadVisited { get; set; }
        public bool HasTailVisited { get; set; }

        public HeadTailLocationModel(bool isStartingLocation = false)
        {
            IsCurrentLocation = isStartingLocation;
            HasHeadVisited = isStartingLocation;
            HasTailVisited = isStartingLocation;
        }
    }
}