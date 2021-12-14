using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickPoint.Models.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderStatusId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Check { get; set; }
        [Required]
        public string PostamatId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string RecipientName { get; set; }

        public ICollection<Goods> Goods { get; set; }
        public Postamat Postamat { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
