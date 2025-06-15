using System.ComponentModel.DataAnnotations;

namespace BookingService.Contracts
{
    public record BookingAddRequest(
        [Required] Guid Id,
        [Required] string UserEmail,
        [Required] Guid SeatId,
        [Required] DateTime Start,
        [Required] DateTime End);
}
