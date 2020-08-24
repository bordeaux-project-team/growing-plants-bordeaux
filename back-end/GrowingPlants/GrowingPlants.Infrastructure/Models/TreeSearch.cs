using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class TreeSearch
    {
        public string Text { get; set; }
        public string PlantType { get; set; }
        public string Temperature { get; set; }
        public int? WaterLevel { get; set; }
        public int PageNumber { get; set; }
        public TreeSearch NextPage { get; set; }
        public List<Tree> Trees { get; set; }
    }
}
