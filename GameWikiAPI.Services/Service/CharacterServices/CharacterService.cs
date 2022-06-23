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

        public async Task<CharacterDetailDTO> GetCharacterByGameIdASync(int gameId)
    {
        var characterEntity = await _context.Character.FindAsync(gameId);
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
}
    
