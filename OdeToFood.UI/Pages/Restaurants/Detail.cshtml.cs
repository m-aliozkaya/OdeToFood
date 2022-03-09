using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.UI.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }
        public IRestaurantData RestaurantData { get; }

        public DetailModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestaurantData.GetById(restaurantId);

            if (Restaurant is null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
