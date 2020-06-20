namespace GrowingPlants.Infrastructure.Models
{
    public class ApiResult<T>
    {
        public string ApiCode { get; set; }

        public string ErrorMessage { get; set; }

        public T Result { get; set; }

        public double ExecutionTime { get; set; }
    }
}