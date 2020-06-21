namespace GrowingPlants.Infrastructure.Models
{
    public class Notification : BaseModel
    {
        public string Content { get; set; }
        public int? ProcessStepId { get; set; }
        public ProcessStep ProcessStep { get; set; }
    }
}
