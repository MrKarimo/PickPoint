using System.ComponentModel.DataAnnotations;

namespace PickPoint.Models.Entity
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
