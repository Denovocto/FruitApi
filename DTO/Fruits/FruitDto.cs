#nullable enable
using System;

namespace FruitApi.DTO.Fruits
{
    public class FruitDto
    {
        public Guid FruitId { get; set; }
        public string Name { get; set; } = null!;
        public int Calories { get; set; }
    }
}