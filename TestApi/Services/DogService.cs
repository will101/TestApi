using Newtonsoft.Json;
using System.Collections.Generic;
using TestApi.Data.Repositories;
using TestApi.Models;

namespace TestApi.Services
{
    public class DogService
    {
        private readonly DogRepository _dogRepository;

        public DogService(DogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public string GetAll()
        {
            List<Dog> data = _dogRepository.GetAllDogs();
            string json = JsonConvert.SerializeObject(data, Constants.JSON_FORMATTING_METHOD);

            return json;
        }

        public string GetDogById(int DogId)
        {
            Dog dog = _dogRepository.GetDogById(DogId);
            string json = JsonConvert.SerializeObject(dog, Constants.JSON_FORMATTING_METHOD);

            return json;
        }

        public string SearchByName(string Name)
        {
            List<Dog> result = _dogRepository.SearchByName(Name);
            string json = JsonConvert.SerializeObject(result, Constants.JSON_FORMATTING_METHOD);

            return json;
        }


        public Dog AddDog(Dog Dog)
        {
            return _dogRepository.AddDog(Dog);
        }

        public Dog UpdateDog(Dog Dog)
        {
            return _dogRepository.UpdateDog(Dog);
        }

        public Dog DeleteDog(int DogId)
        {
            string dogJson = GetDogById(DogId);
            Dog dog = JsonConvert.DeserializeObject<Dog>(dogJson);
            _dogRepository.DeleteDog(DogId);

            return dog;
        }
    }
}
