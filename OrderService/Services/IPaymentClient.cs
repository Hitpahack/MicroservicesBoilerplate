using OrderService.DTOs;
using Refit;


namespace OrderService.Services
{

    public interface IPaymentClient
    {
        [Post("/api/payment/process")]
        Task<PaymentResponse> ProcessPayment([Body] PaymentRequest paymentRequest);
    }

}
