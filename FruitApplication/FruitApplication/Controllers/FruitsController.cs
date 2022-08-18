using FruitApplication.BussinessLogic;
using FruitApplication.Entities;
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
        private readonly IBLFruit _bussinessLogicFruit;

        public FruitsController(IBLFruit bussinessLogicFruit)
        {
            _bussinessLogicFruit = bussinessLogicFruit;
        }

        // The method FindAllFruits() should return all existing fruits.
        [HttpGet]
        public async Task<IEnumerable<FruitDTOModel>> FindAllFruits()
        {
            return await _bussinessLogicFruit.FindAllAsync();
        }

        // The method FindFruitById() should return a single fruit by its id.
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FruitDTOModel>> FindFruitById(int id)
        {
            return await _bussinessLogicFruit.FindByIdAsync(id);
        }

        // The method SaveFruit() should add a new fruit to the list.
        [HttpPost]
        public async Task<ActionResult<FruitDTOModel>> SaveFruit(FruitDTOModel fruit)
        {
            if (fruit == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _bussinessLogicFruit.SaveAsync(fruit);

                return fruit;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // The method UpdateFruit() should update an existing fruit.
        [HttpPut("{id:int}")]
        public async Task<ActionResult<FruitDTOModel>> UpdateFruit(FruitDTOModel fruit, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return await _bussinessLogicFruit.UpdateAsync(id, fruit); ;
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
                await _bussinessLogicFruit.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
