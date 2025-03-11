using Microsoft.AspNetCore.Mvc;

namespace UmutYapi.Controllers
{
    public class AdminController : Controller 
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
