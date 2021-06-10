using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(LeaveHistory entity)
        {
            _context.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _context.LeaveHistories.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _context.LeaveHistories.Any(lh => lh.Id == id);
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _context.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return _context.LeaveHistories.Find(id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _context.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
