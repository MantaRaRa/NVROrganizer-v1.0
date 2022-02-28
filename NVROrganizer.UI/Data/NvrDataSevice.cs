using NvrOrganizer.DataAccess;
using NvrOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NvrOrganizer.UI.Data
{
    public class NvrDataSevice : INvrDataSevice
    {
        private Func<NvrOrganizerDbContext> _contextCreator;

        public NvrDataSevice(Func<NvrOrganizerDbContext> contextCreator )
        {
            _contextCreator = contextCreator;
        }
        public IEnumerable<Nvr> GetAll()
        {
          using(var ctx = _contextCreator())
            {
                return ctx.Nvrs.AsNoTracking().ToList();
            }
        }
    }
}
