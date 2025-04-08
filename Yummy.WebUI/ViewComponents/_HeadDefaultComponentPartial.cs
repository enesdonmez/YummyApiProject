using Microsoft.AspNetCore.Mvc;

namespace Yummy.WebUI.ViewComnponents
{
    public class _HeadDefaultComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
