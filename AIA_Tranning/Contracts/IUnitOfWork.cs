using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaveAllocationRepository leaveAllocations { get; }
        ILeaveHistoryRepository leaveHistories { get; }
        ILeaveTypeRepository leaveTypes { get; }

        int Complete();
    }
}
