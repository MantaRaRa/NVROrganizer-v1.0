﻿using NvrOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.Data
{
    public interface INvrDataSevice
    {
        Task<List<Nvr>> GetAllAsync();
    }
}