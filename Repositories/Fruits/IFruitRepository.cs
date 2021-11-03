using System;
using System.Threading.Tasks;
using FruitApi.DTO.Fruits;

namespace FruitApi.Repositories.Fruits
{
    public interface IFruitRepository
    {
        Task<FruitDto> GetFruit(Guid fruitId);
        Task<Models.Fruits.Fruit> AddFruit(FruitForCreateDto fruitForCreateDto);
    }
}