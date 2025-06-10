using BookingService.Domain.Entities;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IBookingPlaceRepository
    {
        Task<BookingPlace> AddAsync(Address address);
        Task<List<Hall>> GetByIdAsync(Guid placeId);
        Task<List<BookingPlace>> GetAllAsync();
    }
}
