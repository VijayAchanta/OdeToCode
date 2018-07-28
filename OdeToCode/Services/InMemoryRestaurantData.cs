using OdeToCode.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToCode.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
            new Restaurant {Id = 1, Name = "Scott's Pizza Place"},
            new Restaurant {Id = 2, Name = "Avanti's Restaurant"},
            new Restaurant {Id = 3, Name = "Blue Margarita"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

    }
}