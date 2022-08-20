using FruitApplication.Models;
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

        public async Task<IEnumerable<Fruit>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Fruit> FindByIdAsync(long id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<Fruit> SaveAsync(Fruit fruit)
        {
             return await _repository.SaveAsync(fruit);;
        }

        public async Task<Fruit> UpdateAsync(long id, Fruit fruit)
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
