using System.ComponentModel.DataAnnotations;

namespace BookingService.Contracts
{
    public record HallAddRequest(
        [Required] Guid Id,
        [Required] Guid BookingPlaceId,
        [Required] string Name,
        [Required] string FloorUrl,
        [Required] string ComputerSpec,
        [Required] decimal PricePerHour);
}
