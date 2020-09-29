using System.ComponentModel.DataAnnotations;

namespace ItalianoAPI.Models
{
    public class DrinkMenu {

        // Drink menu table
        [Key]
        public int DrinkId { get; set; }

        public string Name { get; set; }

        // New category
        public string Category { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ImgSrc { get; set; }    
    }
}