using Newtonsoft.Json;
using System.Collections.Generic;
using TestApi.Data.Repositories;
using TestApi.Models;

namespace TestApi.Services
{
    public class StatusService
    {
        private readonly StatusRepository _statusRepository;

        public StatusService(StatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public string GetAll()
        {
            List<StatusModel> statuses = _statusRepository.GetAll();

            return JsonConvert.SerializeObject(statuses, Constants.JSON_FORMATTING_METHOD);
        }

        public string GetById(int StatusId)
        {
            StatusModel status = _statusRepository.GetById(StatusId);

            return JsonConvert.SerializeObject(status, Constants.JSON_FORMATTING_METHOD);
        }

        public StatusModel AddStatus(StatusModel Status)
        {
            StatusModel addedStatus = _statusRepository.AddStatus(Status);

            return addedStatus;
        }

        public StatusModel UpdateStatus(StatusModel Status)
        {
            StatusModel updatedStatus = _statusRepository.UpdateStatus(Status);

            return updatedStatus;
        }

        public StatusModel DeleteStatus(int StatusId)
        {
            StatusModel status = JsonConvert.DeserializeObject<StatusModel>(GetById(StatusId));
            _statusRepository.DeleteStatus(StatusId);

            return status;
        }
    }
}
