
#nullable enable
using System.ComponentModel.DataAnnotations;

namespace FruitApi.DTO.Fruits
{
    public class FruitForCreateDto
    {
        [Required] 
        public string Name { get; set; } = null!;

        [Required] 
        public int Calories { get; set; }

    }
}