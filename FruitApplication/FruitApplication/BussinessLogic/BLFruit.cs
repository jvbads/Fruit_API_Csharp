using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication
{
    public class BLFruit : IBLFruit
    {
        private readonly IFruitRepository _repository;
        public BLFruit(IFruitRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FruitDTO>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<FruitDTO> FindByIdAsync(long id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<FruitDTO> SaveAsync(FruitDTO fruit)
        {
             return await _repository.SaveAsync(fruit);;
        }

        public async Task<FruitDTO> UpdateAsync(long id, FruitDTO fruit)
        {
            if (fruit.Id != id)
                throw new ArgumentException("Id can not be the same to update.");

            return await _repository.UpdateAsync(id, fruit); ;
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
