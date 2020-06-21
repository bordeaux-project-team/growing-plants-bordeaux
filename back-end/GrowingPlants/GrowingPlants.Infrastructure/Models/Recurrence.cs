namespace GrowingPlants.Infrastructure.Models
{
    public class Recurrence : BaseModel
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public int? ProcessStepId { get; set; }
        public ProcessStep ProcessStep { get; set; }
    }
}
