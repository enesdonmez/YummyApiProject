using Microsoft.AspNetCore.Mvc;

namespace Yummy.WebUI.ViewComponents
{
    public class _RezervationComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
