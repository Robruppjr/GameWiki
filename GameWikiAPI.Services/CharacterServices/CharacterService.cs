using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



         public class CharacterService : ICharacterService
    {
        private readonly int _characterId;
        private readonly ApplicationDbContext _context;
        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCharacterAsync(CharacterCreateDTO request)
        {
            var characterEntity = new CharacterEntity
            {
                Id = _characterId,
                Name = request.Name,
                Description = request.Description,
                GameId = request.GameId,
            };
            await _context.Character.AddAsync(characterEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
            
        }

    public async Task<CharacterDetailDTO> GetCharacterByIdASync(int characterId)
    {
        var characterEntity = await _context.Character.FindAsync(characterId);
        if (characterEntity is null)
            return null;

        var characterDetail = new CharacterDetailDTO
        {
            Id = characterEntity.Id,
            Name = characterEntity.Name,
            Description = characterEntity.Description,
            GameId = characterEntity.GameId,
        };

        return characterDetail;
    }

    public async Task<bool> UpdateCharacterAsync(CharacterEditDTO request)
    {
        var characterEntity = await _context.Character.FindAsync(request.Id);

        if (characterEntity == null)
            return false;
        else
            characterEntity.Id = request.Id;
            characterEntity.Name = request.Name;
            characterEntity.Description = request.Description;

        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }

     public async Task<bool> DeleteCharacterAsync(int characterId)
    {
        var characterEntity = await _context.Character.FindAsync(characterId);

        if(characterEntity == null)
        return false;
        _context.Character.Remove(characterEntity);
        return await _context.SaveChangesAsync() == 1;

    }

}
    
