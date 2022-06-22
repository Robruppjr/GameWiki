using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DeveloperService : IDeveloperService
    {
        private readonly ApplicationDbContext _context;

        private readonly IDeveloperService _developerService;

        public async Task<bool> CreateDeveloperAsync (DeveloperCreate developerCreate)
        {
            DeveloperEntity developer = new DeveloperEntity
            {
                Id = developerCreate.Id,
                Name = developerCreate.Name,
                YearCreated = developerCreate.YearCreated,
                CEO = developerCreate.CEO
            };

            _context.Developers.Add(developer);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges ==1;
        }
    }
