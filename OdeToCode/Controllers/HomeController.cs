using Microsoft.AspNetCore.Mvc;
using OdeToCode.Models;
using OdeToCode.Services;
using OdeToCode.ViewModels;

namespace OdeToCode.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
            IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            { 
            Restaurant newRestaurant = new Restaurant();
            newRestaurant.Name = model.Name;
            newRestaurant.Cuisine = model.Cuisine;
            Restaurant restaurant = _restaurantData.Add(newRestaurant);
            //return View("Details", restaurant);
            return RedirectToAction(nameof(Details), new { id = restaurant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
