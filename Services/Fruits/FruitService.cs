using System;
using System.Threading.Tasks;
using FruitApi.DTO.Fruits;
using FruitApi.Repositories.Fruits;

namespace FruitApi.Services.Fruits
{
    public class FruitService : IFruitService
    {
        private readonly IFruitRepository _fruitRepository;

        public FruitService(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }
        public async Task<FruitDto> GetFruit(Guid fruitId)
        {
            return await _fruitRepository.GetFruit(fruitId);
        }

        public async Task<Models.Fruits.Fruit> AddFruit(FruitForCreateDto fruitForCreateDto)
        {
            return await _fruitRepository.AddFruit(fruitForCreateDto);
        }
    }
}