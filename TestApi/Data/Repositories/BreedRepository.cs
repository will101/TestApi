using System.Collections.Generic;
using System.Linq;
using TestApi.Models;

namespace TestApi.Data.Repositories
{
    public class BreedRepository
    {
        public Context _dbContext;

        public BreedRepository(Context context)
        {
            _dbContext = context;
        }

        public List<Breed> GetAll()
        {
            return _dbContext.Breed
                .OrderBy(b => b.BreedName)
                .ToList();
        }

        public Breed GetById(int BreedId)
        {
            return _dbContext.Breed
                .Where(b => b.BreedId == BreedId)
                .FirstOrDefault();
        }

        public List<Breed> SearchByBreedName(string BreedName)
        {
            string lowerBreedName = BreedName.ToLower();

            return _dbContext.Breed
                .Where(b => b.BreedName.ToLower() == lowerBreedName
                || b.BreedName.ToLower().Contains(lowerBreedName))
                .OrderBy(b => b.BreedName)
                .ToList();
        }

        public Breed AddBreed(Breed Breed)
        {
            _dbContext.Add(Breed);
            _dbContext.SaveChanges();

            return Breed;
        }

        public Breed UpdateBreed(Breed Breed)
        {
            _dbContext.Update(Breed);
            _dbContext.SaveChanges();

            return Breed;
        }

        public void DeleteBreed(Breed Breed)
        {
            _dbContext.Remove(Breed);
            _dbContext.SaveChanges();
        }
    }
}
