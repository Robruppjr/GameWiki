using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWikiAPI.Models.Model.Game;

public interface IGameService
    {
        Task<bool> CreateGameAsync(GameCreate request);
        Task<IEnumerable<GameListDTO>> GetAllGamesAsync();
        Task<GameDetailDTO> GetGameByIdAsync (int gameId);
    }