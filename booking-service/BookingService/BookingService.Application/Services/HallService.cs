using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.ValueObjects;
using System.Text.Json;

namespace BookingService.Application.Services
{
    public class HallService
    {
        private readonly IHallRepository _hallRepository;

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public async Task<Guid> CreateHall(
            Guid bookingPlaceId,
            string name,
            string floorUrl,
            string computerSpecJson,
            decimal pricePerHour
        )
        {
            var spec = JsonSerializer.Deserialize<ComputerSpec>(computerSpecJson);

            var hall = new Hall(
                bookingPlaceId,
                name,
                floorUrl,
                pricePerHour,
                spec);

            var hallId = await _hallRepository.AddAsync(hall);

            return hallId;
        }

        public async Task<List<Hall>> GetAllHallsByBookingPlaceIdAsync(Guid bookingPlaceId)
        {
            var halls = await _hallRepository.GetHallsInBookingPlace(bookingPlaceId);

            return halls;
        }
    }
}
