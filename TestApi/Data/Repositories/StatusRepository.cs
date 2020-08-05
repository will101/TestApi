using System.Collections.Generic;
using System.Linq;
using TestApi.Models;

namespace TestApi.Data.Repositories
{
    public class StatusRepository
    {
        private readonly Context _dbContext;

        public StatusRepository(Context context)
        {
            _dbContext = context;
        }

        public List<StatusModel> GetAll()
        {
            return _dbContext.Status
                .OrderBy(s => s.Status)
                .ToList();
        }

        public StatusModel GetById(int StatusId)
        {
            return _dbContext.Status
                .Where(s => s.StatusId == StatusId)
                .FirstOrDefault();
        }

        public StatusModel AddStatus(StatusModel Status)
        {
            _dbContext.Add(Status);
            _dbContext.SaveChanges();

            return Status;
        }

        public StatusModel UpdateStatus(StatusModel Status)
        {
            _dbContext.Update(Status);
            _dbContext.SaveChanges();

            return Status;
        }

        public void DeleteStatus(int StatusId)
        {
            StatusModel statusToDelete = GetById(StatusId);
            _dbContext.Remove(statusToDelete);
            _dbContext.SaveChanges();
        }
    }
}
