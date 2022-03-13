using NvrOrganizer.DataAccess;
using NvrOrganizer.Model;
using NvrOrganizer.UI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.Data.Repositories
{
    public class NvrRepository : INvrRepository
    {

        private NvrOrganizerDbContext _context;

        public NvrRepository(NvrOrganizerDbContext context)
        {
            _context = context;
        }
        public async Task<Nvr> GetByIdAsync(int nvrId)
        {
            return await _context.Nvrs.SingleAsync(n => n.Id == nvrId);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
