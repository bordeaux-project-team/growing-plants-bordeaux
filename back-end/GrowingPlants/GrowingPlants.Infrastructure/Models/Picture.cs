using System.ComponentModel.DataAnnotations.Schema;

namespace GrowingPlants.Infrastructure.Models
{
    public class Picture : BaseModel
    {
        public byte[] Source { get; set; }
        public string Description { get; set; }
        public int? GalleryId { get; set; }
        public Gallery Gallery { get; set; }

        /// <summary>
        /// Decode as String 64 to byte[] for Source
        /// </summary>
        [NotMapped]
        public string SourceAsBase64 { get; set; }
    }
}
