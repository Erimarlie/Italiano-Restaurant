using System.ComponentModel.DataAnnotations;

namespace ItalianoAPI.Models
{
    public class FoodMenu {

        // Food menu table
        [Key]
        public int FoodId { get; set; }

        public string Name { get; set; }

        // New category
        public string Category { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ImgSrc { get; set; }    
    }
}
