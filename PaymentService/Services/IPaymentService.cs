using PaymentService.DTOs;
using PaymentService.Models;

namespace PaymentService.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPayment(PaymentRequestDto request);
    }
}
