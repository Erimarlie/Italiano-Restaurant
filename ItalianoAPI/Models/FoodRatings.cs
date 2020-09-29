using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalianoAPI.Models {
    public class FoodRatings {

        [Key]
        public int RatingsId { get; set; }

        public int Rating { get; set; }

        [ForeignKey("FoodFK")]
        public FoodMenu FoodMenu { get; set; }

        public int FoodFK { get; set; }
        
    }
}