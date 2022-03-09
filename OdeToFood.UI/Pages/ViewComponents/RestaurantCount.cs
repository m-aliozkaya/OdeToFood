using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.UI.Pages.ViewComponents;

public class RestaurantCount : ViewComponent
{
    private readonly IRestaurantData restaurantData;

    public RestaurantCount(IRestaurantData restaurantData)
    {
        this.restaurantData = restaurantData;
    }

    public IViewComponentResult Invoke()
    {
        var count = restaurantData.GetCountOfRestaurants();
        return View(count);
    }
}
