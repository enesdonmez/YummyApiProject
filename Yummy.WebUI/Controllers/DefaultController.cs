using Microsoft.AspNetCore.Mvc;

namespace Yummy.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
