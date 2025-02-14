using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";
    }
}