using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

       public IEnumerable<CityDto> GetCities()
        {
        var allCities = _context.Cities.Select(city => new CityDto
        {
            CityId = city.CityId,
            Name = city.Name,
            State = city.State
        });

        return allCities;
        }

        public CityDto AddCity(City city)
        {
            var newCity = new City
            {
                Name = city.Name,
                State = city.State
            };

            _context.Cities.Add(newCity);
            _context.SaveChanges();

            return new CityDto
            {
                CityId = newCity.CityId,
                Name = newCity.Name,
                State = newCity.State
            };
        }
        public CityDto UpdateCity(City city)
        {
            var cityToUpdate = _context.Cities.Find(city.CityId);
            {
                cityToUpdate.Name = city.Name;
                cityToUpdate.State = city.State;
            }

            _context.SaveChanges();

            return new CityDto
            {
                CityId = cityToUpdate.CityId,
                Name = cityToUpdate.Name,
                State = cityToUpdate.State
            };
        }

    }
}