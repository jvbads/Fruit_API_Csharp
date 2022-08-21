using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication
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

        /// <summary>
        /// The method FindAllFruits() return all existing fruits.
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<FruitDTO>>> FindAllFruits()
        {
            var fruits = await _bLFruit.FindAllAsync();

            if (fruits == null)
                return StatusCode(StatusCodes.Status404NotFound, new { staus = (int)StatusCodes.Status404NotFound, msg = "Fruits not found", date = DateTime.Now });

            return Ok(fruits);
        }

        /// <summary>
        /// The method FindFruitById() return a single fruit by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FruitDTO>> FindFruitById(int id)
        {
            var fruit = await _bLFruit.FindByIdAsync(id);

            if (fruit == null)
                return StatusCode(StatusCodes.Status404NotFound, new { staus = (int)StatusCodes.Status404NotFound, msg = "Fruit not found", date = DateTime.Now });

            return Ok(fruit);
        }

        /// <summary>
        /// The method SaveFruit() add a new fruit to the list.
        /// </summary>
        /// <param name="fruit"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FruitDTO>> SaveFruit(FruitDTO fruit)
        {
            if (fruit == null)
                return StatusCode(StatusCodes.Status404NotFound, new { staus = (int)StatusCodes.Status404NotFound, msg = "Fruit not found", date = DateTime.Now });

            if (ModelState.IsValid)
            {
                var fruitSaved = await _bLFruit.SaveAsync(fruit);

                return Created(nameof(fruitSaved), fruitSaved);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// The method UpdateFruit() update an existing fruit.
        /// </summary>
        /// <param name="fruit"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<FruitDTO>> UpdateFruit(FruitDTO fruit, int id)
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

        /// <summary>
        /// The method DeleteFruit() delete an existing fruit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
