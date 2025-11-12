using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CitiesCountriesWebApp.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        [ValidateNever]
        public Country Country { get; set; }
    }
}
