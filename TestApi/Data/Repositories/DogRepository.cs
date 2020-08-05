using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestApi.Models;

namespace TestApi.Data.Repositories
{
    public class DogRepository
    {
        private readonly Context _dbContext;

        public DogRepository(Context context)
        {
            _dbContext = context;
        }

        public List<Dog> GetAllDogs()
        {
            return _dbContext.Dog
                .AsNoTracking()
                .OrderBy(n => n.Name)
                .ToList();
        }

        public Dog GetDogById(int DogId)
        {
            return _dbContext.Dog
                   .AsNoTracking()
                   .Where(i => i.DogId == DogId)
                   .FirstOrDefault();
        }

        public List<Dog> SearchByName(string SearchTerm)
        {
            string lowerSearchTerm = SearchTerm.ToLower();

            return _dbContext.Dog
                .Where(d => d.Name.ToLower().Contains(lowerSearchTerm)
                || d.Name.ToLower() == lowerSearchTerm)
                .AsNoTracking()
                .ToList();
        }

        public Dog AddDog(Dog Dog)
        {
            _dbContext.Add(Dog);
            _dbContext.SaveChanges();

            return Dog;
        }

        public Dog UpdateDog(Dog Dog)
        {
            _dbContext.Update(Dog);
            _dbContext.SaveChanges();

            return Dog;
        }

        public void DeleteDog(int DogId)
        {
            Dog dogToDelete = GetDogById(DogId);

            _dbContext.Remove(dogToDelete);
            _dbContext.SaveChanges();
        }

    }
}
