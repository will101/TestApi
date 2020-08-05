using Microsoft.AspNetCore.Mvc;
using System;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/breed")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly BreedService _breedService;

        public BreedController(BreedService breedService)
        {
            _breedService = breedService;
        }

        [HttpGet]
        [Route("All")]
        public string All()
        {
            string jsonResponse = _breedService.GetAll();

            return jsonResponse;
        }

        [HttpGet]
        [Route("GetById/{id?}")]
        public string GetById(int? id)
        {
            string response;
            if (id.HasValue == true)
            {
                response = _breedService.GetById((id.Value));
            }
            else
            {
                response = "No id provided";
            }

            return response;
        }

        [HttpGet]
        [Route("SearchBreed/{breed?}")]
        public string SearchBreed(string Breed)
        {
            string jsonResponse;
            if (!string.IsNullOrEmpty(Breed))
            {
                jsonResponse = _breedService.SearchBreedByName(Breed);
            }
            else
            {
                jsonResponse = "No breed name provided";
            }

            return jsonResponse;
        }

        [HttpPost]
        [Route("AddBreed")]
        public string AddBreed(Breed Breed)
        {
            string jsonResponse;
            try
            {
                _breedService.AddBreed(Breed);
                jsonResponse = "Breed created succesfully";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error creating breed: {e.Message}";
            }

            return jsonResponse;
        }

        [HttpPut]
        [Route("UpdateBreed")]
        public string UpdateBreed(Breed Breed)
        {
            string jsonResponse = "";
            try
            {
                _breedService.UpdateBreed(Breed);
                jsonResponse = "Breed updated succesfully";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error updating breed: {e.Message}";
            }

            return jsonResponse;
        }

        [HttpDelete]
        [Route("DeleteBreed")]
        public string DeleteBreed(int BreedId)
        {
            string jsonResponse;
            try
            {
                _breedService.DeleteBreed(BreedId);
                jsonResponse = "Breed deleted successfully";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error deleting breed: {e.Message}";
            }

            return jsonResponse;
        }
    }
}