using Microsoft.AspNetCore.Mvc;

namespace Yummy.AdminUI.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
