using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(0.0001, double.MaxValue)]
        public decimal TotalAmount { get; set; } // Total in USD

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // e.g., Pending, Processing, Completed, Cancelled

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
