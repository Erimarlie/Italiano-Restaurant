using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItalianoAPI.Models;

namespace ItalianoAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase {

        private readonly ItalianoContext _context;

        public UserController(ItalianoContext context) {
            _context = context;
        }

        
        /* Food methods */

        // FoodMenu get method
        [HttpGet("/foodmenu")]
        public async Task<IEnumerable<FoodMenu>> GetFood() {
            List<FoodMenu> foodMenuList = await _context.FoodMenu.ToListAsync();
            return foodMenuList;
        }

        // Search Food by Category
        [HttpGet("/foodinfo/{category}")]
        public async Task<IEnumerable<FoodInfo>> GetFoodByCategory(string category) {
            List<FoodInfo> foodMenuList = await _context.FoodInfo
                .Where(
                    food => food.Category.ToLower()
                    .Contains(category.ToLower())
                )
                .ToListAsync();
            return foodMenuList;
        }

        // FoodInfo get method
        // From FoodInfo view
        [HttpGet("/foodinfo")]
        public async Task<IEnumerable<FoodInfo>> GetFoodInfo() {
            List<FoodInfo> foodInfoList = await _context.FoodInfo.ToListAsync();
            return foodInfoList;
        }

        // FoodRatings post method
        [HttpPost("/foodratings")]
        public async Task<FoodRatings> Post(FoodRatings foodratings) {
            _context.FoodRatings.Add(foodratings);
            await _context.SaveChangesAsync();
            return foodratings;
        }

        
        /* Drink methods */

        // DrinkMenu get methods
        [HttpGet("/drinkmenu")]
        public async Task<IEnumerable<DrinkMenu>> GetDrink() {
            List<DrinkMenu> drinkMenuList = await _context.DrinkMenu.ToListAsync();
            return drinkMenuList;
        }

        // Search Drinks by Category
        [HttpGet("/drinkinfo/{category}")]
        public async Task<IEnumerable<DrinkInfo>> GetDrinksByCategory(string category) {
            List<DrinkInfo> drinkMenuList = await _context.DrinkInfo
                .Where(
                    drink => drink.Category.ToLower()
                    .Contains(category.ToLower())
                )
                .ToListAsync();
            return drinkMenuList;
        }

        // DrinkInfo get method
        // From DrinkInfo view
        [HttpGet("/drinkinfo")]
        public async Task<IEnumerable<DrinkInfo>> GetDrinkInfo() {
            List<DrinkInfo> drinkInfoList = await _context.DrinkInfo.ToListAsync();
            return drinkInfoList;
        }

        // DrinkRatings post method
        [HttpPost("/drinkratings")]
        public async Task<DrinkRatings> Post(DrinkRatings drinkratings) {
            _context.DrinkRatings.Add(drinkratings);
            await _context.SaveChangesAsync();
            return drinkratings;
        }

        
        /* Dessert methods */

        // DessertMenu methods
        [HttpGet("/dessertmenu")]
        public async Task<IEnumerable<DessertMenu>> GetDessert() {
            List<DessertMenu> dessertMenuList = await _context.DessertMenu.ToListAsync();
            return dessertMenuList;
        }

        // Search Desserts by Category
        [HttpGet("/dessertinfo/{category}")]
        public async Task<IEnumerable<DessertInfo>> GetDessertsByCategory(string category) {
            List<DessertInfo> dessertMenuList = await _context.DessertInfo
                .Where(
                    dessert => dessert.Category.ToLower()
                    .Contains(category.ToLower())
                )
                .ToListAsync();
            return dessertMenuList;
        }

        // DessertInfo get method
        // From DessertInfo view
        [HttpGet("/dessertinfo")]
        public async Task<IEnumerable<DessertInfo>> GetDessertInfo() {
            List<DessertInfo> dessertInfoList = await _context.DessertInfo.ToListAsync();
            return dessertInfoList;
        }

        // DessertRatings post method
        [HttpPost("/dessertratings")]
        public async Task<DessertRatings> Post(DessertRatings dessertratings) {
            _context.DessertRatings.Add(dessertratings);
            await _context.SaveChangesAsync();
            return dessertratings;
        }
    }
}