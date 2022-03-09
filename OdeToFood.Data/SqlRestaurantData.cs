using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data;

public class SqlRestaurantData : IRestaurantData
{
    private readonly OdeToFoodDbContext db;

    public SqlRestaurantData(OdeToFoodDbContext db)
    {
        this.db = db;
    }

    public Restaurant Add(Restaurant restaurant)
    {
        db.Add(restaurant);
        return restaurant;
    }

    public int Commit()
    {
        return db.SaveChanges();
    }

    public Restaurant Delete(int id)
    {
        var restaurant = GetById(id);
        if (restaurant is not null)
        {
            db.Restaurants.Remove(restaurant);
        }

        return restaurant;
    }

    public IEnumerable<Restaurant> GetAll()
    {
        return db.Restaurants;
    }

    public Restaurant? GetById(int id)
    {
        return db.Restaurants.Find(id);
    }

    public int GetCountOfRestaurants()
    {
        return db.Restaurants.Count();
    }

    public IEnumerable<Restaurant> GetRestaurantsByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return db.Restaurants;
        }

        return db.Restaurants.Where(x => x.Name.StartsWith(name));
    }

    public Restaurant Update(Restaurant restaurant)
    {
        var entity = db.Restaurants.Attach(restaurant);
        entity.State = EntityState.Modified;
        return restaurant;
    }
}