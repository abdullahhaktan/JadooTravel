using JadooTravel.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace JadooTravel.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ShowSuggestions(string Location)
        {
            if (string.IsNullOrEmpty(Location))
            {
                ViewBag.Suggestions = "Lütfen bir şehir ve ülke giriniz";
                return View();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "XXXXXXXXXXXXXXXXXXXX");

            var requestBody = new
            {
                model = "gpt-4",
                messages = new object[]
                {
            new { role = "system", content = "Sen bir seyehat önerisi asistanısın." },
            new { role = "user", content = $"Bana {Location} için gezilecek yer öner ama öne konuşma yapma yani." }
                },
                max_tokens = 300,
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseString);
            var suggestion = doc.RootElement
                                .GetProperty("choices")[0]
                                .GetProperty("message")
                                .GetProperty("content")
                                .GetString();

            ViewBag.Suggestions = suggestion;
            return View("Index");
        }


    }
}