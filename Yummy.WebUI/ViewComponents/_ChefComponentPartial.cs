using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yummy.WebUI.Dtos.ChefDtos;

namespace Yummy.WebUI.ViewComponents
{
    public class _ChefComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _ChefComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var responseMessage = await client.GetAsync($"{_configuration.GetSection("ApiUrl").Value}/chefs/ChefList");
                if (responseMessage.IsSuccessStatusCode) 
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
                    return View(result);

                }
            }
            return View();
        }
    }
}
