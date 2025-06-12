using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string WalletAddress { get; set; } // Customer's crypto wallet address

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
