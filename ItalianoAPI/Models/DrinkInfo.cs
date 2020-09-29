using System.ComponentModel.DataAnnotations;

namespace ItalianoAPI.Models
{
    public class DrinkInfo {

        // This connects to a view that shows both menu information combined with
        // average ratings and total votes
        [Key]
        public int DrinkId { get; set; }

        public string Name { get; set; }

        // New category
        public string Category { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ImgSrc { get; set; }

        public float AvgRating { get; set; }

        public int TotalVotes { get; set; }
        
    }
}