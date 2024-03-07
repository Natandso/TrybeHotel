using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            var allHotels = _context.Hotels.Select(hotel => new HotelDto
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.CityId,
                State = _context.Cities.Where(state => state.CityId == hotel.CityId).Select(state => state.State).FirstOrDefault() ?? string.Empty,
            });

            return allHotels;
        }
        
        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            var newHotel = new Hotel
            {
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.CityId,
        };
            
                _context.Hotels.Add(newHotel);
                _context.SaveChanges();
    
                return new HotelDto
                {
                    HotelId = newHotel.HotelId,
                    Name = newHotel.Name,
                    Address = newHotel.Address,
                    CityId = newHotel.CityId,
                    CityName = _context.Cities.Where(city => city.CityId == newHotel.CityId).Select(city => city.Name).FirstOrDefault(),
                    State = _context.Cities.Where(state => state.CityId == newHotel.CityId).Select(state => state.State).FirstOrDefault() ?? string.Empty,
                };
            }
    }
}