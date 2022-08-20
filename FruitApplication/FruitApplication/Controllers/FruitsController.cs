using FruitApplication.BussinessLogic;
using FruitApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : ControllerBase
    {
        private readonly IBLFruit _bLFruit;

        public FruitsController(IBLFruit bLFruit)
        {
            _bLFruit = bLFruit;
        }

        // The method FindAllFruits() should return all existing fruits.
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Fruit>>> FindAllFruits()
        {
            var fruits = await _bLFruit.FindAllAsync();

            return Ok(fruits);
        }

        // The method FindFruitById() should return a single fruit by its id.
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Fruit>> FindFruitById(int id)
        {
            var fruit = await _bLFruit.FindByIdAsync(id);

            return Ok(fruit);
        }

        // The method SaveFruit() should add a new fruit to the list.
        [HttpPost]
        public async Task<ActionResult<Fruit>> SaveFruit(Fruit fruit)
        {
            if (fruit == null)
                return NotFound();

            if (ModelState.IsValid)
            {
               var fruitSaved = await _bLFruit.SaveAsync(fruit);

                return Created(nameof(SaveFruit), fruitSaved);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // The method UpdateFruit() should update an existing fruit.
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Fruit>> UpdateFruit(Fruit fruit, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bLFruit.UpdateAsync(id, fruit); ;

                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // The method DeleteFruit() should delete an existing fruit.
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFruit(int id)
        {
            try
            {
                await _bLFruit.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
