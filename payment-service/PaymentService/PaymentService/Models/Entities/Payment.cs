namespace PaymentService.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string TransactionId => $"TXN-{Id}-{CreatedAt:yyyyMMdd}";
    }
}
