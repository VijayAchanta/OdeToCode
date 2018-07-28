using OdeToCode.Models;
using System.Collections.Generic;

namespace OdeToCode.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
