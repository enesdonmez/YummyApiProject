using Microsoft.AspNetCore.Mvc;

namespace Yummy.AdminUI.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
