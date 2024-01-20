using System.ComponentModel.DataAnnotations;

namespace Api_Code.Data.Model
{
    public class Product
    {
        [Key]
        [Required]
        public  int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        public  string Sku { get; set; }
    }
}
