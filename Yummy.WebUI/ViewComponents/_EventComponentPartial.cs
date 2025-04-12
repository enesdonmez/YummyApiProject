using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yummy.WebUI.Dtos.EventDtos;

namespace Yummy.WebUI.ViewComponents
{
    public class _EventComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _EventComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync($"{_configuration.GetSection("ApiUrl").Value}/Events/EventList");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<ResultEventDto>>(jsonData);
                    return View(result);

                }
            }
            return View();
        }
    }
}
