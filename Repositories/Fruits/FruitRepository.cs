using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FruitApi.DTO.Fruits;
using FruitApi.Models;
using FruitApi.Models.Fruits;
using Microsoft.EntityFrameworkCore;

namespace FruitApi.Repositories.Fruits
{
    public class FruitRepository : IFruitRepository
    {
        private readonly FruitContext _context;

        public FruitRepository(FruitContext context)
        {
            _context = context;
        }

        public async Task<FruitDto> GetFruit(Guid fruitId)
        {
            return await _context.Fruits
                .AsNoTracking()
                .Where(f => f.FruitId == fruitId)
                .Select(f => new FruitDto()
                {
                    Calories = f.Calories,
                    Name = f.Name,
                    FruitId = f.FruitId
                })
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Models.Fruits.Fruit> AddFruit(FruitForCreateDto fruitForCreateDto)
        {
            var fruit = new Models.Fruits.Fruit
            {
                Calories = fruitForCreateDto.Calories,
                Name = fruitForCreateDto.Name,
                FruitId = Guid.NewGuid()
            };
            await _context.AddAsync(fruit);
            await _context.SaveChangesAsync();
            return fruit;
        }
    }
}