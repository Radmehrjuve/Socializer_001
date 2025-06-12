using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Crypto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } 

        [Required]
        [StringLength(10)]
        public string Symbol { get; set; } 

        [Required]
        [Range(0.0001, double.MaxValue)]
        public decimal Price { get; set; } 
    }
}
