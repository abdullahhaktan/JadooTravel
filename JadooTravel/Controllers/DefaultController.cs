using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace JadooTravel.Controllers
{
    public class DefaultController : Controller
    {
        // HttpClientFactory for creating HTTP clients (better than using HttpClient directly)
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
            // Validate input location
            if (string.IsNullOrEmpty(Location))
            {
                ViewBag.Suggestions = "Lütfen bir şehir ve ülke giriniz";
                return View();
            }

            // Create HTTP client and set OpenAI API authorization header
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "XXXXXXXXXXXXXXXXXXXX"); // API key should be in configuration

            // Prepare request body for OpenAI Chat API
            var requestBody = new
            {
                model = "gpt-4", // Specify GPT-4 model
                messages = new object[]
                {
            new { role = "system", content = "Sen bir seyehat önerisi asistanısın." }, // System prompt
            new { role = "user", content = $"Bana {Location} için gezilecek yer öner ama öne konuşma yapma yani." } // User prompt
                },
                max_tokens = 300, // Limit response length
            };

            // Serialize request to JSON
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Send POST request to OpenAI API
            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            // Parse JSON response to extract the AI-generated suggestion
            using var doc = JsonDocument.Parse(responseString);
            var suggestion = doc.RootElement
                                .GetProperty("choices")[0]     // Get first choice
                                .GetProperty("message")        // Access message object
                                .GetProperty("content")        // Get content property
                                .GetString();                  // Convert to string

            // Pass suggestion to view via ViewBag
            ViewBag.Suggestions = suggestion;
            return View("Index");
        }
    }
}