using Microsoft.AspNetCore.Mvc;
using System;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/dog")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogService _dogService;

        public DogController(DogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet]
        [Route("All")]
        public string All()
        {
            string data = _dogService.GetAll(); 
            
            return data;
        }

        [HttpGet]
        [Route("GetById/{id?}")]
        public string GetDogById(int? id)
        {
            string message;
            if (id.GetValueOrDefault() == default)
            {
                message = "You have not provided a valid id number for a dog";
            }
            else
            {
                message = _dogService.GetDogById(id.Value);
            }

            return message;
        }

        [HttpGet]
        [Route("SearchByName/{DogName?}")]
        public string SearchByName(string DogName)
        {
            string jsonResponse;
            if (!string.IsNullOrEmpty(DogName))
            {
                jsonResponse = _dogService.SearchByName(DogName);
            }
            else
            {
                jsonResponse = "You didn't provide a dog name";
            }

            return jsonResponse;
        }

        [HttpPost]
        [Route("AddDog")]
        public string AddDog(Dog Dog)
        {
            string jsonResponse;
            try
            {
                _dogService.AddDog(Dog);
                jsonResponse = $"Dog created succesfully. Details: {Dog.Name}, {Dog.FavouriteThing}, {Dog.WouldLike}";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error creating dog: {e.Message}";
            }

            return jsonResponse;
        }

        [HttpPut]
        [Route("UpdateDog")]
        public string UpdateDog(Dog Dog)
        {
            string jsonResponse;
            try
            {
                _dogService.UpdateDog(Dog);
                jsonResponse = $"Dog updated sucessfully. Details: {Dog.Name}, {Dog.FavouriteThing}, {Dog.WouldLike}";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error updating dog: {e.Message}";
            }

            return jsonResponse;
        }

        [HttpDelete]
        [Route("DeleteDog/id")]
        public string DeleteDog(int DogId)
        {
            string jsonResponse;
            try
            {
                _dogService.DeleteDog(DogId);
                jsonResponse = "Dog deleted succesfully";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error deleting dog: {e.Message}";
            }

            return jsonResponse;
        }

    }
}