using BookingService.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Contracts
{
    public record BookingPlaceAddRequest([Required] Guid Id, [Required] AddressDto Address);
}
