using Assignment18WeatherPartial.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment18WeatherPartial.Controllers
{
    public class WeatherController : Controller
    {
        private List<CityWeather> entries = new()
        {
            new() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"), TemperatureFahrenheit = 33},
            new() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"), TemperatureFahrenheit = 60},
            new() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"), TemperatureFahrenheit = 82},
        };

        [Route("/")]
        public IActionResult Index()
        {
            return View(entries); //Views/Weather/Index.cshtml
        }

        [Route("/weather/{cityCode}")]
        public IActionResult Details(string? cityCode)
        {
            CityWeather? entry = entries.Where(e => e.CityUniqueCode == cityCode).FirstOrDefault();

            if (entry == null)
            {
                return BadRequest("No city found for the provided code");
            }

            return View(entry); //Views/Weather/Details.cshtml
        }
    }
}
