using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.ValueObjects;

namespace BookingService.Application.Services
{
    public class BookingPlaceService
    {
        private readonly IBookingPlaceRepository _bookingRepository;

        public BookingPlaceService(IBookingPlaceRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingPlace> AddBookingPlace(Address address)
        {
            return await _bookingRepository.AddAsync(address);
        }

        public async Task<List<BookingPlace>> GetAllBookingPlaces()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<List<Hall>> GetAllHallFromPlace(Guid hallId)
        {
            return await _bookingRepository.GetByIdAsync(hallId);
        }
    }
}
