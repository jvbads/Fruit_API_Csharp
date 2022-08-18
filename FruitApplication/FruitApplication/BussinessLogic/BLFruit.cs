using FruitApplication.Entities;
using FruitApplication.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitApplication.BussinessLogic
{
    public class BLFruit : IBLFruit
    {
        private readonly IFruitRepository _repository;
        public BLFruit(IFruitRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FruitDTOModel>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<FruitDTOModel> FindByIdAsync(long id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<FruitDTOModel> SaveAsync(FruitDTOModel fruit)
        {
            await _repository.SaveAsync(fruit);

            return fruit;
        }

        public async Task<FruitDTOModel> UpdateAsync(long id, FruitDTOModel fruit)
        {
            if (fruit.Id != id)
                throw new ArgumentException("Id can not be the same to update.");

            await _repository.UpdateAsync(id, fruit);

            return fruit;
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
