using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class TreeSearch
    {
        public string Text { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public TreeSearch NextPage { get; set; }
        public List<Tree> Trees { get; set; }
    }
}
