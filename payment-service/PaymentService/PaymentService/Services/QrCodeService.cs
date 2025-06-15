using PaymentService.Models.DTOs;
using QRCoder;

namespace PaymentService.Services
{
    public class QrCodeService
    {
        public string GenerateQrData(PaymentQRRequest request)
        {
            return $"bank://payment?amount={request.Amount}&currency=RUB&txn={Guid.NewGuid()}";
        }

        public string GenerateQrCode(string data, int pixelsPerModule = 20)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            var pngBytes = qrCode.GetGraphic(pixelsPerModule);
            return "data:image/png;base64," + Convert.ToBase64String(pngBytes);
        }
    }
}
