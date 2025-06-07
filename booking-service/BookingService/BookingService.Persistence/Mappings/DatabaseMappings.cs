using AutoMapper;
using BookingService.Domain.Entities;
using BookingService.Persistence.Entities;

namespace BookingService.Persistence.Mappings
{
    public class DatabaseMappings : Profile
    {
        public DatabaseMappings()
        {
            CreateMap<BookingPlaceEntity, BookingPlace>();
            CreateMap<BookingEntity, Booking>();
            CreateMap<HallEntity, Hall>();
            CreateMap<SeatEntity, Seat>();
        }
    }
}
