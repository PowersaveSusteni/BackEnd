using Microsoft.AspNetCore.Mvc;

namespace SusteniWebServices
{
    public class Susteni : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
