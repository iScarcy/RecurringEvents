using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Infrastructure.Repository
{
    public class RepositoryDbService<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryDbService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(int ID)
        {
            return await _context.Set<T>().FindAsync(ID);
        }

        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
           _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
