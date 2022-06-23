using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IDeveloperService
    {
        Task<bool> CreateDeveloperAsync (DeveloperCreate developerCreate);

        Task<DeveloperDetail> GetDeveloperByIdASync(int developerId);

        Task<bool> UpdateDeveloperAsync(DeveloperEdit request);

        Task<bool> DeleteDeveloperAsync(int developerId);
    }
