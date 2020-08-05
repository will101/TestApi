using Microsoft.AspNetCore.Mvc;
using System;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;

        public StatusController(StatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        [Route("All")]
        public string All()
        {
            string jsonResponse = _statusService.GetAll();

            return jsonResponse;
        }

        [HttpGet]
        [Route("GetById/{id?}")]
        public string GetById(int? id)
        {
            string jsonResponse;
            if (id.HasValue == true)
            {
                jsonResponse = _statusService.GetById(id.Value);
            }
            else
            {
                jsonResponse = "Please provide a valid id";
            }

            return jsonResponse;
        }

        [HttpPost]
        [Route("AddStatus")]
        public string AddStatus(StatusModel Status)
        {
            string jsonResponse;
            try
            {
                _statusService.AddStatus(Status);
                jsonResponse = "Status added successfully";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error creating status: {e.Message}";
            }

            return jsonResponse;
        }

        [HttpPut]
        [Route("UpdateStatus")]
        public string UpdateStatus(StatusModel Status)
        {
            string jsonResponse;
            try
            {
                _statusService.UpdateStatus(Status);
                jsonResponse = "Updated successfully";
            }
            catch (Exception ex)
            {
                jsonResponse = $"Error updating status: {ex.Message}";
            }

            return jsonResponse;
        }

        [HttpDelete]
        [Route("DeleteStatus")]
        public string DeleteStatus(int StatusId)
        {
            string jsonResponse;
            try
            {
                _statusService.DeleteStatus(StatusId);
                jsonResponse = "Status deleted successfully";
            }
            catch (Exception e)
            {
                jsonResponse = $"Error deleting status: {e.Message}";
            }

            return jsonResponse;
        }
    }
}