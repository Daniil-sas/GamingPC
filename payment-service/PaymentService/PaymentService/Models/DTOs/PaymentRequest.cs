using PaymentService.Models.Enums;

namespace PaymentService.Models.DTOs
{
    public class PaymentRequest
    {
        public PaymentMethod Method { get; set; }
        public string? CardNumber { get; set; }
        public string? CardHolder { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "RUB";
    }
}
