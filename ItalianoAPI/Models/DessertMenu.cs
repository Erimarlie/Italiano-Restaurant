using System.ComponentModel.DataAnnotations;

namespace ItalianoAPI.Models
{
    public class DessertMenu {

        // Dessert menu table
        [Key]
        public int DessertId { get; set; }

        public string Name { get; set; }

        // New category
        public string Category { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ImgSrc { get; set; }    
    }
}