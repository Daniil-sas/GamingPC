using PaymentService.Models.Enums;

namespace PaymentService.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public Guid BookingId { get; set; }
        public PaymentMethod Method { get; set; }
        public string? CardNumber { get; set; }
        public string? CardHolder { get; set; }
        public string? ExpiryDate { get; set; }
        public string? QrContent { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "RUB";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsSuccessful { get; set; } = true;

        public string TransactionId => $"TXN-{Id}-{CreatedAt:yyyyMMdd}";
    }
}
