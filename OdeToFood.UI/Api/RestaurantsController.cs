using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.UI.Api;

[Route("api/[controller]")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private readonly IRestaurantData restaurantData;

    public RestaurantsController(IRestaurantData restaurantData)
    {
        this.restaurantData = restaurantData;
    }

    public IEnumerable<Restaurant> GetRestaurants()
    {
        return restaurantData.GetAll();
    }
}
