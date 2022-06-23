using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DeveloperService : IDeveloperService
    {
        private readonly ApplicationDbContext _context;

        private readonly IDeveloperService _developerService;

        private readonly int _developerId;

        public DeveloperService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDeveloperAsync (DeveloperCreate developerCreate)
        {
            DeveloperEntity developer = new DeveloperEntity
            {
                Id = _developerId,
                Name = developerCreate.Name,
                YearCreated = developerCreate.YearCreated,
                CEO = developerCreate.CEO
            };

            await _context.Developers.AddAsync(developer);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<DeveloperDetail> GetDeveloperByIdASync(int developerId)
        {
            var developerEntity = await _context.Developers.FindAsync(developerId);
            if (developerEntity is null)
            {
                return null;
            }

            var developerDetail = new DeveloperDetail
            {
                Id = developerEntity.Id,
                Name = developerEntity.Name,
                YearCreated = developerEntity.YearCreated,
                CEO = developerEntity.CEO,
                Games = developerEntity.Games,
                // Characters = developerEntity.Characters
            
            };

            return developerDetail;
        }

        //Update
        public async Task<bool> UpdateDeveloperAsync(DeveloperEdit request)
        {
            var developerEntity = await _context.Developers.FindAsync(request.Id);
            if(developerEntity == null)
            {
                return false;
            }
            else
            {
                developerEntity.Name = request.Name;
                developerEntity.CEO = request.CEO;
            }

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges ==1;
        }

        //Delete
           public async Task<bool> DeleteDeveloperAsync(int developerId)
       {
           var developerEntity = await _context.Developers.FindAsync(developerId);
           if(developerEntity == null)
           {
               return false;
           }

           _context.Developers.Remove(developerEntity);
           return await _context.SaveChangesAsync()==1;
       }
       
       public async Task<IEnumerable<DeveloperList>> GetAllDevelopersAsync()
       {
            var developers = await _context.Developers
            .Select(entity => new DeveloperList
            {
                Id = entity.Id,
                Name = entity.Name,
                YearCreated = entity.YearCreated,
                CEO = entity.CEO
            }).ToListAsync();

            return developers;
       }

        public async Task<IEnumerable<DeveloperList>> GetAllDevelopersAlphabeticallyAsync()
       {
            var developers = await _context.Developers
            .Select(entity => new DeveloperList
            {
                Id = entity.Id,
                Name = entity.Name,
                YearCreated = entity.YearCreated,
                CEO = entity.CEO
            }).OrderBy(c => c.Name).ToListAsync();

            return developers;
       }


    }

    
