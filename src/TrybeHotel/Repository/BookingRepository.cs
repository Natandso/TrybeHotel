using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
        
        var allRooms = _context.Rooms.Include(x => x.Hotel).ThenInclude(x => x.City).FirstOrDefault(r => r.RoomId == booking.RoomId);
            var userEmail = _context.Users.FirstOrDefault(u => u.Email == email);

            if (allRooms.Capacity < booking.GuestQuant)
            {
                throw new Exception("Guest quantity over room capacity");
            }


            var bookingDB = new Booking
            {
                GuestQuant = booking.GuestQuant,
                RoomId = booking.RoomId,

                CheckIn = DateTime.Parse(booking.CheckIn),
                CheckOut = DateTime.Parse(booking.CheckOut),
                UserId = userEmail.UserId,
                
            };


            _context.Bookings.Add(bookingDB);
            _context.SaveChanges();

            
            return new BookingResponse
            {
                BookingId = bookingDB.BookingId,
                CheckIn = bookingDB.CheckIn.ToString("yyyy-MM-dd"),
                CheckOut = bookingDB.CheckOut.ToString("yyyy-MM-dd"),
                GuestQuant = bookingDB.GuestQuant,
                Room = new RoomDto
                {
                    RoomId = allRooms.RoomId,
                    Name = allRooms.Name,
                    Capacity = allRooms.Capacity,
                    Image = allRooms.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = allRooms.HotelId,
                        Name = allRooms.Hotel.Name,
                        Address = allRooms.Hotel.Address,
                        CityId = allRooms.Hotel.CityId,
                        CityName = allRooms.Hotel.City.Name,
                        State = allRooms.Hotel.City.State
                    }
                }
            };
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            var userEmail = _context.Users.FirstOrDefault(u => u.Email == email);
            var booking = _context.Bookings.Include(x => x.Room).ThenInclude(x => x.Hotel).ThenInclude(x => x.City).FirstOrDefault(b => b.BookingId == bookingId && b.UserId == userEmail.UserId);

            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            return new BookingResponse
            {
                BookingId = booking.BookingId,
                CheckIn = booking.CheckIn.ToString("yyyy-MM-dd"),
                CheckOut = booking.CheckOut.ToString("yyyy-MM-dd"),
                GuestQuant = booking.GuestQuant,
                Room = new RoomDto
                {
                    RoomId = booking.Room.RoomId,
                    Name = booking.Room.Name,
                    Capacity = booking.Room.Capacity,
                    Image = booking.Room.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = booking.Room.HotelId,
                        Name = booking.Room.Hotel.Name,
                        Address = booking.Room.Hotel.Address,
                        CityId = booking.Room.Hotel.CityId,
                        CityName = booking.Room.Hotel.City.Name,
                        State = booking.Room.Hotel.City.State,
                    }
                }
            };
        }

        public Room GetRoomById(int RoomId)
        {
            return _context.Rooms.FirstOrDefault(r => r.RoomId == RoomId);
        }

    }

}