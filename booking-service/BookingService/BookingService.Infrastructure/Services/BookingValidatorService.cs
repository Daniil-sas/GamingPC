using BookingService.Application.Interfaces;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Infrastructure.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Infrastructure.Services
{
    public class BookingValidatorService : IBookingValidatorService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IHallRepository _hallRepository;

        public BookingValidatorService(IBookingRepository bookingRepository, IHallRepository hallRepository)
        {
            _bookingRepository = bookingRepository;
            _hallRepository = hallRepository;
        }

        public void Validate(BookingRequestDto dto)
        {
            var errors = new List<string>();

            if (dto.TimeSlot.Start >= dto.TimeSlot.End)
                errors.Add("Время начала должно быть раньше времени окончания.");

            if (dto.TimeSlot.Start < DateTime.UtcNow)
                errors.Add("Нельзя забронировать прошедшее время.");

            if (dto.HallId == Guid.Empty)
                errors.Add("Не указан зал.");

            if (dto.SeatId == Guid.Empty)
                errors.Add("Не указано место.");

            if (string.IsNullOrEmpty(dto.UserId.ToString()))
                errors.Add("Пользователь не авторизован.");

            var hall = _hallRepository.GetByIdAsync(dto.HallId).Result;
            if (hall == null)
                errors.Add("Зал не найден.");

            if (hall?.Seats.All(s => s.Id != dto.SeatId) ?? true)
                errors.Add("Место не найдено в указанном зале.");

            if (_bookingRepository.IsSeatBooked(dto.SeatId, dto.TimeSlot).Result)
                errors.Add("Место занято на выбранное время.");

            if (errors.Count > 0)
            {
                string errorsIn = "";
                foreach (var error in errors)
                    errorsIn += error + "\n";
                throw new ValidationException(errorsIn);
            }
        }
    }
}
