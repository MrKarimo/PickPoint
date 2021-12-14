using System.ComponentModel.DataAnnotations;

namespace PickPoint.Models.Entity
{
    public class Goods
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
