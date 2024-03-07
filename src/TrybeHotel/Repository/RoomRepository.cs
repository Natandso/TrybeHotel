using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
             var gettingRoom = _context.Hotels.Find(HotelId);
            // abaixo foi necessário adicionar o teste de null para evitar erro de referência nula
            var city = gettingRoom != null ? _context.Cities.Find(gettingRoom.CityId) : null;


            return _context.Rooms
                .Where(room => room.HotelId == HotelId)
                .Select(room => new RoomDto
                {
                    RoomId = room.RoomId,
                    Name = room.Name,
                    Capacity = room.Capacity,
                    Image = room.Image,

                    Hotel = gettingRoom != null ? new HotelDto
                    {
                        HotelId = gettingRoom.HotelId,
                        Name = gettingRoom.Name,
                        Address = gettingRoom.Address,
                        CityId = gettingRoom.CityId,
                        CityName = city != null ? city.Name : null,
                        State = city != null ? city.State : null
                    } : null
                });
        }

        public RoomDto AddRoom(Room room) {
            var newRoom = new Room
            {
                Name = room.Name,
                Capacity = room.Capacity,
                Image = room.Image,
                HotelId = room.HotelId
            };

            _context.Rooms.Add(newRoom);
            _context.SaveChanges();

            var hotel = _context.Hotels.Find(newRoom.HotelId);
            var city = hotel != null ? _context.Cities.Find(hotel.CityId) : null;

            return new RoomDto
            {
                RoomId = newRoom.RoomId,
                Name = newRoom.Name,
                Capacity = newRoom.Capacity,
                Image = newRoom.Image,
                Hotel = hotel != null ? new HotelDto
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CityId = hotel.CityId,
                    CityName = city?.Name,
                    State = city?.State
                } : null
            };
        }

        public void DeleteRoom(int RoomId) {
             var rooms = _context.Rooms.Find(RoomId);
            if (rooms != null)
            {
           _context.Rooms.Remove(rooms);
           _context.SaveChanges();

            } else {
                
                throw new Exception("Room not found");
            }
        }
    }
}