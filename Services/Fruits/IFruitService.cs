#nullable enable
using System;
using System.Threading.Tasks;
using FruitApi.DTO.Fruits;

namespace FruitApi.Services.Fruits
{
    public interface IFruitService
    {
        Task<FruitDto> GetFruit(Guid fruitId);
        Task<Models.Fruits.Fruit> AddFruit(FruitForCreateDto fruitForCreateDto);
    }
}