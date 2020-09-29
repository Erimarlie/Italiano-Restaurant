using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalianoAPI.Models {
    public class DessertRatings {

        [Key]
        public int RatingsId { get; set; }

        public int Rating { get; set; }

        [ForeignKey("DessertFK")]
        public DessertMenu DessertMenu { get; set; }

        public int DessertFK { get; set; }
        
    }
}