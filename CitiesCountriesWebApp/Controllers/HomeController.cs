using System.Diagnostics;
using CitiesCountriesWebApp.Data;
using CitiesCountriesWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitiesCountriesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cityData = await _context.City
                .Join(_context.Country,
                    city => city.CountryId,
                    country => country.Id,
                    (city, country) => new ViewModels.CountryCityViewModel
                    {
                        CityId = city.Id,
                        CityName = city.Name,
                        CountryName = country.Name
                        
                    })
                .OrderBy(vm => vm.CityName)
                .ToListAsync();
            return View(cityData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
