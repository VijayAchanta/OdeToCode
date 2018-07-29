using OdeToCode.Models;
using System.Collections.Generic;

namespace OdeToCode.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
