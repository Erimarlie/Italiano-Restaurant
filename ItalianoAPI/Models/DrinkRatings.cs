using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalianoAPI.Models {
    public class DrinkRatings {

        [Key]
        public int RatingsId { get; set; }

        public int Rating { get; set; }

        [ForeignKey("DrinkFK")]
        public DrinkMenu DrinkMenu { get; set; }

        public int DrinkFK { get; set; }
        
    }
}
