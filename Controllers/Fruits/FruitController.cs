using System;
using System.Threading.Tasks;
using FruitApi.DTO.Fruits;
using FruitApi.Services.Fruits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitApi.Controllers.Fruits
{ 
    [AllowAnonymous]
    [ApiController]
[Route("[controller]")]
public class FruitController : ControllerBase
{
    private readonly IFruitService _fruitService;

    public FruitController(IFruitService fruitService)
    {
        _fruitService = fruitService;
    }

    [HttpGet]
    public async Task<IActionResult> GetFruit([FromQuery] Guid fruitId)
    {
        var fruit = await _fruitService.GetFruit(fruitId);
        return Ok(fruit);
    }
   [HttpPost]
    public async Task<IActionResult> AddFruit([FromBody] FruitForCreateDto fruitForCreateDto)
    {
        var fruit = await _fruitService.AddFruit(fruitForCreateDto);
        return Ok(fruit.FruitId);
    }
}

}
