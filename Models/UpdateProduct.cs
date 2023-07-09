using System.ComponentModel.DataAnnotations;

namespace MVCCRUD.Models
{
    public class UpdateProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
