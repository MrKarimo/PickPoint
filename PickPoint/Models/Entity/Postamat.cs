using System.ComponentModel.DataAnnotations;

namespace PickPoint.Models.Entity
{
    public class Postamat
    {
        [Key]
        public string PostamatNumber { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
