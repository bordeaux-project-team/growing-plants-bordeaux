using System.Text.Json.Serialization;

namespace GrowingPlants.Infrastructure.Models
{
    public class FavoriteTree : BaseModel
    {
        public int? TreeId { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public Tree Tree { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public bool IsFavorite { get; set; }
    }
}
