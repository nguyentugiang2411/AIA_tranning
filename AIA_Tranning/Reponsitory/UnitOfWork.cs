using AIA_Tranning.Contracts;
using AIA_Tranning.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Reponsitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public ILeaveAllocationRepository leaveAllocations { get; }

        public ILeaveHistoryRepository leaveHistories { get; }

        public ILeaveTypeRepository leaveTypes { get; }

        public UnitOfWork(ApplicationDbContext dbContext,
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveHistoryRepository leaveHistoryRepository,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _dbContext = dbContext;
            leaveAllocations = leaveAllocationRepository;
            leaveHistories = leaveHistoryRepository;
            leaveTypes = leaveTypeRepository;
        }

        public bool save()
        {
            return _dbContext.SaveChanges() > 0;
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
