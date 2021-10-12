using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(LeaveRequest entity)
        {
            _context.LeaveRequests.Add(entity);
            return Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            _context.LeaveRequests.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _context.LeaveRequests.Any(lh => lh.Id == id);
        }

        public ICollection<LeaveRequest> FindAll()
        {
            return _context.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToList();
        }

        public LeaveRequest FindById(int id)
        {
            return _context.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .FirstOrDefault(q => q.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(LeaveRequest entity)
        {
            _context.LeaveRequests.Update(entity);
            return Save();
        }
    }
}
