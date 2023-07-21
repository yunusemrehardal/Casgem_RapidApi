using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Casgem_RapidApi.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityname = "London")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "89fcbeb61amsh1fdb44656d3eb7ap1a545djsnfc5ef26ed6f0" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<LocationCityNameViewModel>>(body);
                return View(value.Take(1).ToList());
            }
        }
    }
}
