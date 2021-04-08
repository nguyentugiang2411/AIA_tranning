using AIA_Tranning.Contracts;
using AIA_Tranning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Reponsitory
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool create(LeaveType entity)
        {
            _dbContext.LeaveTypes.Add(entity);
            return save();
        }

        public bool delete(LeaveType entity)
        {
            _dbContext.LeaveTypes.Remove(entity);
            return save();
        }

        public ICollection<LeaveType> findAll()
        {
            return _dbContext.LeaveTypes.ToList();
        }

        public LeaveType findById(int i)
        {
            return _dbContext.LeaveTypes.Find(i);
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool update(LeaveType entity)
        {
            _dbContext.LeaveTypes.Update(entity);
            return save();
        }

        public bool isExist(int id)
        {
            return _dbContext.LeaveTypes.Any(el => el.Id == id);
        }
    }
}
