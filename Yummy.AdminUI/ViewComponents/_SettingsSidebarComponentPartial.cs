using Microsoft.AspNetCore.Mvc;

namespace Yummy.AdminUI.ViewComponents
{
    public class _SettingsSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
