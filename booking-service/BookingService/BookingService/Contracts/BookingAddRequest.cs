using System.ComponentModel.DataAnnotations;

namespace BookingService.Contracts
{
    public record BookingAddRequest(
        [Required] Guid Id,
        [Required] Guid BookingPlaceId,
        [Required] Guid UserId,
        [Required] Guid HallId,
        [Required] Guid SeatId,
        [Required] DateTime Start,
        [Required] DateTime End);
}
