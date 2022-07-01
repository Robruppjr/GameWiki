using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface ICharacterService
    {
        Task<bool> CreateCharacterAsync(CharacterCreateDTO request);
        Task<CharacterDetailDTO> GetCharacterByIdASync (int characterId);
        //Task<CharacterDetailDTO> GetCharacterByGameIdASync (int characterId);
        Task<bool> UpdateCharacterAsync(CharacterEditDTO request);
        Task<bool> DeleteCharacterAsync(int characterId);
    }
