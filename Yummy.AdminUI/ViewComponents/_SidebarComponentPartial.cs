using Microsoft.AspNetCore.Mvc;

namespace Yummy.AdminUI.ViewComponents
{
    public class _SidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
