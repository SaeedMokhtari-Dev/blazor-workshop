using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
    public class Topping
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string GetFormattedPrice() => Price.ToString("0.00");
    }
}
