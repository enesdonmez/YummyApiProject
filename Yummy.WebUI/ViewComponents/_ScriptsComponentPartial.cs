using Microsoft.AspNetCore.Mvc;

namespace Yummy.WebUI.ViewComponents
{
    public class _ScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
