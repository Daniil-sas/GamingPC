using PaymentService.Data;
using PaymentService.Helpers;
using PaymentService.Models.DTOs;
using PaymentService.Models.Entities;
using PaymentService.Models.Enums;

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

        public async Task<PaymentResult> ProcessPayment(PaymentRequest request)
        {
            if (request.Method == PaymentMethod.Card)
            {
                if (string.IsNullOrWhiteSpace(request.CardNumber))
                    throw new ArgumentException("Нужен номер карты");

                if (!CardHelper.IsValidCard(request.CardNumber))
                    throw new ArgumentException("Неверный номер");
            }

            var payment = new Payment
            {
                Method = request.Method,
                Amount = request.Amount,
                Currency = request.Currency
            };

            if (request.Method == PaymentMethod.Card)
            {
                payment.CardNumber = CardHelper.Mask(request.CardNumber!);
                payment.CardHolder = request.CardHolder;
                payment.ExpiryDate = request.ExpiryDate;
            }
            else
            {
                payment.QrContent = _qrService.GenerateQrData(request);
            }

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return new PaymentResult
            {
                Success = true,
                TransactionId = payment.TransactionId,
                Message = request.Method == PaymentMethod.Card
                    ? "Card payment processed successfully"
                    : "QR code generated successfully",
                QrCodeBase64 = request.Method == PaymentMethod.QR
                    ? _qrService.GenerateQrCode(payment.QrContent!)
                    : null
            };
        }
    }
}
