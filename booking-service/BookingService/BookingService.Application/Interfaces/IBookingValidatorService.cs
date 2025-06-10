using BookingService.Infrastructure.DTOs;

namespace BookingService.Application.Interfaces
{
    public interface IBookingValidatorService
    {
        void Validate(BookingRequestDto dto);
    }
}
