using PaymentService.Data;
using PaymentService.Helpers;
using PaymentService.Models.DTOs;
using PaymentService.Models.Entities;

namespace PaymentService.Services
{
    public class PaymentsService
    {
        private readonly AppDbContext _context;
        private readonly QrCodeService _qrService;

        public PaymentsService(AppDbContext context, QrCodeService qrService)
        {
            _context = context;
            _qrService = qrService;
        }
        public string GetQrCode(PaymentQRRequest request)
        {
            return _qrService.GenerateQrCode(_qrService.GenerateQrData(request));
        }

        public async Task<PaymentResult> ProcessPayment(PaymentCardRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CardNumber))
                throw new ArgumentException("Нужен номер карты");

            if (!CardHelper.IsValidCard(request.CardNumber))
                throw new ArgumentException("Неверный номер");

            if (string.IsNullOrEmpty(request.CardHolder) || string.IsNullOrEmpty(request.CVV) || string.IsNullOrEmpty(request.ExpiryDate))
            {
                throw new ArgumentException("Не все данные были введены");
            }

            DateTime currentDate = DateTime.Now;
            var expiry = DateTime.Parse("01/" + request.ExpiryDate);

            if (currentDate > expiry)
            {
                throw new ArgumentException("Срок годности карты истёк");
            }

            var payment = new Payment
            {
                Amount = request.Amount,
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return new PaymentResult
            {
                Success = true,
                TransactionId = payment.TransactionId,
                Message = "Оплата прошла успешно"
            };
        }
    }
}
