using AutoMapper;
using BookingService.Domain.Entities;
using BookingService.Domain.ValueObjects;
using BookingService.Persistence.Entities;
using Newtonsoft.Json;

namespace BookingService.Persistence.Mappings
{
    public class DatabaseMappings : Profile
    {
        public DatabaseMappings()
        {
            CreateMap<BookingPlaceEntity, BookingPlace>()
                .ForCtorParam("address", opt => opt.MapFrom(src =>
                    JsonConvert.DeserializeObject<Address>(src.Address)))
                .ReverseMap()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src =>
                    JsonConvert.SerializeObject(src.Address)))
                .ForMember(dest => dest.Halls, opt => opt.MapFrom(src =>
                    src.Halls.Select(h => h.Id).ToList()));

            CreateMap<BookingEntity, Booking>();

            CreateMap<HallEntity, Hall>()
                .ForCtorParam("computerSpec", opt => opt.MapFrom(src =>
                    JsonConvert.DeserializeObject<ComputerSpec>(src.ComputerSpec)))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src =>
                    src.Seats.Select(s => s.Id).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.ComputerSpec, opt => opt.MapFrom(src =>
                    JsonConvert.SerializeObject(src.ComputerSpec)));

            CreateMap<SeatEntity, Seat>()
                .ForCtorParam("position", opt => opt.MapFrom(src =>
                    JsonConvert.DeserializeObject<SeatPosition>(src.PositionJson)))
                .ReverseMap()
                .ForMember(dest => dest.PositionJson, opt => opt.MapFrom(src =>
                    JsonConvert.SerializeObject(src.Position)));
        }
    }
}
