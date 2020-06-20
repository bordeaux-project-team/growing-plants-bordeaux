namespace GrowingPlants.Infrastructure.Models
{
    public class Garden : BaseModel
    {
        public int? TreeId { get; set; }
        public Tree Tree { get; set; }
        public int? PlantingEnvironmentId { get; set; }
        public PlantingEnvironment PlantingEnvironment { get; set; }
        public int Position { get; set; }
        public int Amount { get; set; } // Number of trees in that position
    }
}
