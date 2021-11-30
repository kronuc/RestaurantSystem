using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult MainMenu()
        {
            return View();
        }
    }
}
