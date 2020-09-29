using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItalianoAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ItalianoAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class AdminController : ControllerBase {

        private readonly ItalianoContext _context;

        private readonly IWebHostEnvironment _hosting;

        public AdminController(ItalianoContext context, IWebHostEnvironment hosting) {
            _context = context;
            _hosting = hosting;
        }

        // Upload file/image
        [HttpPost("/savepicture")]
        public void SavePicture(IFormFile file) {
            string webrootpath = _hosting.WebRootPath;
            string absolutepath = Path.Combine($"{webrootpath}/images/{file.FileName}");
            using(var filestream = new FileStream(absolutepath, FileMode.Create)) {
                file.CopyTo(filestream);
            }
        }

        // Edit food
        [HttpPut("/foodmenu")]
        public async Task<FoodMenu> PutFood(FoodMenu food) {
            _context.Update(food);
            await _context.SaveChangesAsync();
            return food;
        }

        // Add food
        [HttpPost("/foodmenu")]
        public async Task<FoodMenu> PostFood(FoodMenu food) {
            _context.FoodMenu.Add(food);
            await _context.SaveChangesAsync();
            return food;
        }

        // Delete food
        [HttpDelete("/foodmenu/{id}")]
        public async Task<FoodMenu> DeleteFood(int id) {
            FoodMenu deleteFood = await _context.FoodMenu.FirstAsync(food => food.FoodId == id);
            _context.FoodMenu.Remove(deleteFood);
            await _context.SaveChangesAsync();
            return deleteFood;
        }

        // Delete ratings associated with the food item deleted
        [HttpDelete("/foodratings/{id}")]
        public async Task<FoodRatings> DeleteFoodRatings(int id) {
            FoodRatings deleteFoodRatings = await _context.FoodRatings.FirstAsync(rating => rating.FoodFK == id);
            _context.FoodRatings.Remove(deleteFoodRatings);
            await _context.SaveChangesAsync();
            return deleteFoodRatings;
        }

        // Edit drink
        [HttpPut("/drinkmenu")]
        public async Task<DrinkMenu> PutDrink(DrinkMenu drink) {
            _context.Update(drink);
            await _context.SaveChangesAsync();
            return drink;
        }

        // Add drink
        [HttpPost("/drinkmenu")]
        public async Task<DrinkMenu> PostDrink(DrinkMenu drink) {
            _context.DrinkMenu.Add(drink);
            await _context.SaveChangesAsync();
            return drink;
        }

        // Delete drink
        [HttpDelete("/drinkmenu/{id}")]
        public async Task<DrinkMenu> DeleteDrink(int id) {
            DrinkMenu deleteDrink = await _context.DrinkMenu.FirstAsync(drink => drink.DrinkId == id);
            _context.DrinkMenu.Remove(deleteDrink);
            await _context.SaveChangesAsync();
            return deleteDrink;
        }

        // Delete ratings associated with the drink item deleted
        [HttpDelete("/drinkratings/{id}")]
        public async Task<DrinkRatings> DeleteDrinkRatings(int id) {
            DrinkRatings deleteDrinkRatings = await _context.DrinkRatings.FirstAsync(rating => rating.DrinkFK == id);
            _context.DrinkRatings.Remove(deleteDrinkRatings);
            await _context.SaveChangesAsync();
            return deleteDrinkRatings;
        }

        // Edit dessert
        [HttpPut("/dessertmenu")]
        public async Task<DessertMenu> PutDessert(DessertMenu dessert) {
            _context.Update(dessert);
            await _context.SaveChangesAsync();
            return dessert;
        }

        // Add dessert
        [HttpPost("/dessertmenu")]
        public async Task<DessertMenu> PostDessert(DessertMenu dessert) {
            _context.DessertMenu.Add(dessert);
            await _context.SaveChangesAsync();
            return dessert;
        }

        // Delete dessert
        [HttpDelete("/dessertmenu/{id}")]
        public async Task<DessertMenu> DeleteDessert(int id) {
            DessertMenu deleteDessert = await _context.DessertMenu.FirstAsync(drink => drink.DessertId == id);
            _context.DessertMenu.Remove(deleteDessert);
            await _context.SaveChangesAsync();
            return deleteDessert;
        }

        // Delete ratings associated with the dessert item deleted
        [HttpDelete("/dessertratings/{id}")]
        public async Task<DessertRatings> DeleteDessertRatings(int id) {
            DessertRatings deleteDessertRatings = await _context.DessertRatings.FirstAsync(rating => rating.DessertFK == id);
            _context.DessertRatings.Remove(deleteDessertRatings);
            await _context.SaveChangesAsync();
            return deleteDessertRatings;
        }
    }
}