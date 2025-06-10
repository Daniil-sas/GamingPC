using Microsoft.AspNetCore.Mvc;
using PaymentService.Models.DTOs;
using PaymentService.Services;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentsService _paymentService;

        public PaymentController(PaymentsService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            try
            {
                if (request.Amount <= 0)
                    return BadRequest("Неверная сумма");

                var result = await _paymentService.ProcessPayment(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new PaymentResult
                {
                    Success = false,
                    Message = $"Неудачный платёж: {ex.Message}"
                });
            }
        }
    }
}
