using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int CryptocurrencyId { get; set; }
        public Crypto Cryptocurrency { get; set; }

        [Required]
        [Range(0.0001, double.MaxValue)]
        public decimal Quantity { get; set; } // Amount of crypto purchased

        [Required]
        [Range(0.0001, double.MaxValue)]
        public decimal UnitPrice { get; set; } // Price per unit at time of purchase

        [Required]
        public string Network {  get; set; } // شبکه
    }
}
