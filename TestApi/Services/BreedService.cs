using Newtonsoft.Json;
using System.Collections.Generic;
using TestApi.Data.Repositories;
using TestApi.Models;

namespace TestApi.Services
{
    public class BreedService
    {
        private readonly BreedRepository _breedRepository;

        public BreedService(BreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }

        public string GetAll()
        {
            List<Breed> all = _breedRepository.GetAll();

            return JsonConvert.SerializeObject(all, Constants.JSON_FORMATTING_METHOD);
        }

        public string GetById(int BreedId)
        {
            Breed breed = _breedRepository.GetById(BreedId);

            return JsonConvert.SerializeObject(breed, Constants.JSON_FORMATTING_METHOD);
        }

        public string SearchBreedByName(string BreedName)
        {
            List<Breed> results = _breedRepository.SearchByBreedName(BreedName);

            return JsonConvert.SerializeObject(results, Constants.JSON_FORMATTING_METHOD);
        }

        public Breed AddBreed(Breed Breed)
        {
            Breed addedBreed = _breedRepository.AddBreed(Breed);

            return addedBreed;
        }

        public Breed UpdateBreed(Breed Breed)
        {
            Breed updatedBreed = _breedRepository.UpdateBreed(Breed);

            return updatedBreed;
        }

        public Breed DeleteBreed(int BreedId)
        {
            Breed breed = _breedRepository.GetById(BreedId);
            _breedRepository.DeleteBreed(breed);

            return breed;
        }
    }
}
