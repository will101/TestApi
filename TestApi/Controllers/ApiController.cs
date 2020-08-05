using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DogService _dogService;

        public ApiController(DogService dService)
        {
            _dogService = dService;
        }

        /// <summary>
        /// Test api is up and can connect to db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Test")]
        public bool TestConnection()
        {
            bool success = true;
            try
            {
                string allDogs = _dogService.GetAll();
                List<Dog> dogs = JsonConvert.DeserializeObject<List<Dog>>(allDogs);
            }
            catch (Exception e)
            {
                success = false;
            }

            return success;
        }
    }
}
