using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yummy.AdminUI.Dtos.MessageDtos;
using Yummy.AdminUI.Dtos.NotificationDtos;

namespace Yummy.AdminUI.ViewComponents
{
    public class _NavbarNotificationListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _NavbarNotificationListComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (var client = _httpClientFactory.CreateClient("YummyApi"))
            {
                var response = await client.GetAsync("Notifications");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                    return View(result);

                }
            }
            return View();
        }
    }
}
