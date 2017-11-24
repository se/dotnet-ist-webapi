using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/help");
        }
    }
}