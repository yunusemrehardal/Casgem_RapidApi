using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Casgem_RapidApi.Controllers
{
    public class ImdbController : Controller
    {
        List<ImdbMovieListViewModel> model = new List<ImdbMovieListViewModel>();    

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
        {
                { "X-RapidAPI-Key", "89fcbeb61amsh1fdb44656d3eb7ap1a545djsnfc5ef26ed6f0" },
                { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ImdbMovieListViewModel>>(body);
                return View(model.ToList());
            }
        }
    }
}
