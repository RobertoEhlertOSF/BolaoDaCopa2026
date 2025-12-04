using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient _http;

        public MovieController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
        }

        [HttpGet]
        public IActionResult Filme()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Filme(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return View(null);

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://movie-database-alternative.p.rapidapi.com/?s={s}&r=json"
            );

            request.Headers.Add("X-RapidAPI-Key",
                "bf69562179mshd4dd9f49fbf8ebcp197effjsn8c8d7130fa91");

            request.Headers.Add("X-RapidAPI-Host",
                "movie-database-alternative.p.rapidapi.com");

            var resp = await _http.SendAsync(request);
            var json = await resp.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var model = JsonSerializer.Deserialize<MovieSearchResponse>(json, options);

            return View(model);
        }
    }
}
