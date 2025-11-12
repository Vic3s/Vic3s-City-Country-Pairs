using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CitiesCountriesWebApp.Models;

namespace CitiesCountriesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CitiesCountriesWebApp.Models.City> City { get; set; } = default!;
        public DbSet<CitiesCountriesWebApp.Models.Country> Country { get; set; } = default!;
    }
}
