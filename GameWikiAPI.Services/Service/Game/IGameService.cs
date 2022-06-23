using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWikiAPI.Models.Model.Game;

public interface IGameService
    {
        Task<bool> CreateGameAsync(GameCreate request);
        Task<IEnumerable<GameListDTO>> GetAllGamesAsync();
        Task<IEnumerable<GameListDTO>> GetAllGamesByDevId(int devId);
        Task<GameDetailDTO> GetGameByIdAsync(int gameId);
        Task<bool> UpdateGameAsync(GameEditDTO request);
        Task<bool> DeleteGameAsync(int gameId);
    }