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

            await _context.Developers.AddAsync(developer);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges ==1;
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
    }

    
