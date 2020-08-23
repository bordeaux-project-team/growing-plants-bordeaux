namespace GrowingPlants.Infrastructure.Models
{
    public class Light : BaseModel
    {
        public string Name { get; set; }
        public int FromUnit { get; set; }
        public int ToUnit { get; set; }
        public int? MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
    }
}
