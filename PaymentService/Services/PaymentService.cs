using PaymentService.Data;
using PaymentService.DTOs;
using PaymentService.Models;

namespace PaymentService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentDbContext _dbContext;

        public PaymentService(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaymentResponseDto> ProcessPayment(PaymentRequestDto request)
        {
            var payment = new Payment
            {
                OrderId = request.OrderId,
                Amount = request.Amount,
                PaymentDate=DateTime.Now,
                Status = "Completed"
            };

            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();
            return new PaymentResponseDto
            {
                OrderId = payment.OrderId,
                Status= payment.Status,              
            };
        }
    }
}
