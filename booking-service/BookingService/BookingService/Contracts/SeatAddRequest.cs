using BookingService.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Contracts
{
    public record SeatAddRequest(
        [Required] Guid Id,
        [Required] Guid HallId,
        [Required] PositionDto Position,
        [Required] int NumInHall
        );
}
