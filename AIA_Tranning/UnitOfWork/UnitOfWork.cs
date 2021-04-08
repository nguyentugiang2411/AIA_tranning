using AIA_Tranning.Contracts;
using AIA_Tranning.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext,
            ILeaveAllocationRepository leaveAllocations,
            ILeaveHistoryRepository leaveHistories,
            ILeaveTypeRepository leaveTypes)
        {
        }

        public ILeaveAllocationRepository leaveAllocations { get; }

        public ILeaveHistoryRepository leaveHistories { get; }

        public ILeaveTypeRepository leaveTypes { get; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
