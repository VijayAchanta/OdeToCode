using Microsoft.AspNetCore.Mvc;
using OdeToCode.Models;
using OdeToCode.Services;

namespace OdeToCode.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
            //return new ObjectResult(model) ;
            return View(model);
        }
    }
}
