﻿using OdeToFood.Core;

namespace OdeToFood.Data;

public interface IRestaurantData
{
    IEnumerable<Restaurant> GetAll();
    IEnumerable<Restaurant> GetRestaurantsByName(string name);
    Restaurant? GetById(int id);
    Restaurant Update(Restaurant restaurant);
    Restaurant Add(Restaurant restaurant);
    Restaurant Delete(int id);
    int Commit();
    int GetCountOfRestaurants();
}
