using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string CustomerName { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}