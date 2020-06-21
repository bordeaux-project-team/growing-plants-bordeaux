namespace GrowingPlants.Infrastructure.Utilities
{
    public static class Constants
    {
        public struct UserRole
        {
            public const string Admin = "Admin";
            public const string Client = "Client";
        }

        public struct TreeSearchPagination
        {
            public const int RecordsPerPage = 10;
        }
    }
}
