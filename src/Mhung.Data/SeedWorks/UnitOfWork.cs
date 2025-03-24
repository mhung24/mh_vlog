using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mhung.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MhungBlogContext _context;

        public UnitOfWork(MhungBlogContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
    
}
