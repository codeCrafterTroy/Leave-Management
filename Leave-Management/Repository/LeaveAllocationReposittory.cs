using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveAllocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckAllocation(int LeaveTypeId, string emmployeeId)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(
                    la => la.EmployeeId == emmployeeId && 
                    la.LeaveTypeId == LeaveTypeId && 
                    la.Period == period)
                .Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _context.LeaveAllocations.Any(la => la.Id == id);
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _context.LeaveAllocations.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _context.LeaveAllocations.Find(id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
