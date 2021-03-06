using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int LeaveTypeId, string emmployeeId);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id);
    }
}
