using AIA_Tranning.Contracts;
using AIA_Tranning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Reponsitory
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveHistoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool create(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Add(entity);
            return save();
        }

        public bool delete(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Remove(entity);
            return save();
        }

        public ICollection<LeaveHistory> findAll()
        {
            return _dbContext.LeaveHistories.ToList();
        }

        public LeaveHistory findById(int i)
        {
            return _dbContext.LeaveHistories.Find(i);
        }

        public bool save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool update(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Update(entity);
            return save();
        }

        public bool isExist(int id)
        {
            return _dbContext.LeaveHistories.Any(el => el.Id == id);
        }
    }
}
