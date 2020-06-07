namespace GrowingPlants.Infrastructure.ApiModels
{
	public class ApiResult<T>
	{
		public bool Succeed { get; set; }

		public string ErrorCode { get; set; }

		public string ErrorMessage { get; set; }

		public T Result { get; set; }

		public double ExecutionTime { get; set; }
	}
}