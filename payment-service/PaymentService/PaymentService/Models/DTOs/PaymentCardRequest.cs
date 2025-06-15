namespace PaymentService.Models.DTOs
{
    public class PaymentCardRequest
    {
        public string? CardNumber { get; set; }
        public string? CardHolder { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }
        public decimal Amount { get; set; }
    }
}
