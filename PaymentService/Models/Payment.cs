namespace PaymentService.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }  // Pending, Completed, Failed
        public DateTime PaymentDate { get; set; }
    }
}
