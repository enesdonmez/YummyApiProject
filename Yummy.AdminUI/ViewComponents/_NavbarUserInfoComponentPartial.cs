using Microsoft.AspNetCore.Mvc;

namespace Yummy.AdminUI.ViewComponents
{
    public class _NavbarUserInfoComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
