using Microsoft.AspNetCore.Mvc;

namespace OdeToCode.Controllers
{
    //[Route("[controller]")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello from About Controller index method");
        }
        //[Route("")]
        public string Phone()
        {
            return "1-555-555-5555";
        }
        //[Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}