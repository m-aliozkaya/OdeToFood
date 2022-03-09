using OdeToFood.Core;

namespace OdeToFood.Data;

public class InMemoryRestaurantData : IRestaurantData
{
    private readonly List<Restaurant> restaurants;

    public InMemoryRestaurantData()
    {
        restaurants = new List<Restaurant>()
        {
            new Restaurant{Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Turkish},
            new Restaurant{Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Mexican},
            new Restaurant{Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Indian},
        };
    }

    public Restaurant Add(Restaurant restaurant)
    {
        restaurants.Add(restaurant);
        restaurant.Id = restaurants.Max(x => x.Id) + 1;
        return restaurant;
    }

    public int Commit()
    {
        return 1;
    }

    public Restaurant Delete(int id)
    {
        var restaurant = restaurants.FirstOrDefault(x => x.Id == id);
        if (restaurant != null)
        {
            restaurants.Remove(restaurant);
        }

        return restaurant;
    }

    public IEnumerable<Restaurant> GetAll()
    {
        return restaurants.OrderBy(x => x.Name);
    }

    public Restaurant? GetById(int id)
    {
        return restaurants.FirstOrDefault(x => x.Id == id);
    }

    public int GetCountOfRestaurants()
    {
        return restaurants.Count;
    }

    public IEnumerable<Restaurant> GetRestaurantsByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return restaurants;
        }

        return restaurants.Where(x => x.Name.ToLower().StartsWith(name));
    }

    public Restaurant Update(Restaurant updatedRestaurant)
    {
        var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);

        if (restaurant is not null)
        {
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Cuisine = updatedRestaurant.Cuisine;
        }

        return restaurant;
    }
}

