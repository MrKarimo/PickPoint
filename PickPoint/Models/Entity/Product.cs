using System.ComponentModel.DataAnnotations;

namespace PickPoint.Models.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
    }
}
