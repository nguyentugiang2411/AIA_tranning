using AIA_Tranning.Contracts;
using AIA_Tranning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Reponsitory
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveAllocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool create(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Add(entity);
            return save();
        }

        public bool delete(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Remove(entity);
            return save();
        }

        public ICollection<LeaveAllocation> findAll()
        {
            return _dbContext.LeaveAllocations.ToList();
        }

        public LeaveAllocation findById(int i)
        {
            return _dbContext.LeaveAllocations.Find(i);
        }

        public bool isExist(int id)
        {
            return _dbContext.LeaveAllocations.Any(el => el.Id == id);
        }

        public bool save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool update(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Update(entity);
            return save();
        }
    }
}
