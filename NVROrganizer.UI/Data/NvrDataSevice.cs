using NvrOrganizer.DataAccess;
using NvrOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.Data
{
    public class NvrDataSevice : INvrDataSevice
    {
        private Func<NvrOrganizerDbContext> _contextCreator;

        public NvrDataSevice(Func<NvrOrganizerDbContext> contextCreator )
        {
            _contextCreator = contextCreator;
        }
        public async Task<Nvr> GetByIdAsync(int nvrId)
        {
          using (var ctx = _contextCreator())
            {
                return await ctx.Nvrs.AsNoTracking().SingleAsync(n => n.Id == nvrId);
            }
        }

        public async Task SaveAsync(Nvr nvr)
        {
            using (var ctx = _contextCreator())
            {
              ctx.Nvrs.Attach(nvr);
               ctx.Entry(nvr).State = EntityState.Modified;
               await ctx.SaveChangesAsync();
            }
        }
    }
}
