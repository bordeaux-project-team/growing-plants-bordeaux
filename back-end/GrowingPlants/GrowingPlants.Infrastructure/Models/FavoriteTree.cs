namespace GrowingPlants.Infrastructure.Models
{
    public class FavoriteTree : BaseModel
    {
        public int? TreeId { get; set; }
        public int? UserId { get; set; }
        public Tree Tree { get; set; }
        public User User { get; set; }
        public bool IsFavorite { get; set; }
    }
}
