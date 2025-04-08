using Microsoft.AspNetCore.Mvc;

namespace Yummy.WebUI.ViewComponents
{
    public class _StatsComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
