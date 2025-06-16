using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Yummy.AdminUI.Dtos.CategoryDtos;
using Yummy.Api.Dtos.CategoryDtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Yummy.AdminUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            using var client = _httpClientFactory.CreateClient("YummyApi");
            var response = await client.GetAsync("Categories/GetAllCategories");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(data);
                return View(categories);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            using var client = _httpClientFactory.CreateClient("YummyApi");
            var data = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Categories/CreateCategory", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            using var client = _httpClientFactory.CreateClient("YummyApi");
            var response = await client.DeleteAsync($"Categories?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            using var client = _httpClientFactory.CreateClient("YummyApi");
            var response = await client.GetAsync($"Categories/GetCategory?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData);
                return View(category);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            using var client = _httpClientFactory.CreateClient("YummyApi");
            var data = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("Categories/UpdateCategory", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
