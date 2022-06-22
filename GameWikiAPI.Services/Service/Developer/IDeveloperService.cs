using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IDeveloperService
    {
        Task<bool> CreateDeveloperAsync (DeveloperCreate developerCreate);
    }
