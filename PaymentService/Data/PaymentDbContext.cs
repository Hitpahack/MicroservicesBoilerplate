using Microsoft.EntityFrameworkCore;
using PaymentService.Models;

namespace PaymentService.Data
{
    public class PaymentDbContext :DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> option) : base(option) { }

        public DbSet<Payment> Payments { get; set; }

    }
}
