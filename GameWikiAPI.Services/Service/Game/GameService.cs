using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWikiAPI.Models.Model.Game;
using Microsoft.EntityFrameworkCore;

public class GameService : IGameService
{
    private readonly int _gameId;
    private readonly int _devId;
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateGameAsync(GameCreate request)
    {
        var gameEntity = new GameEntity
        {
            Id = _gameId,
            Name = request.Name,
            Description = request.Description,
            DevId = request.DevId
        };
        await _context.Game.AddAsync(gameEntity);
        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
        }


    public async Task<IEnumerable<GameListDTO>> GetAllGamesAsync()
    {
        var games = await _context.Game
            // .Where(entity => entity.DevId == _devId)
            .Select(entity => new GameListDTO
            {
                Id = entity.Id,
                Name = entity.Name
            })
            .ToListAsync();
        return games;
    }

    public async Task<GameDetailDTO> GetGameByIdAsync(int gameId)
    {
        var gameEntity = await _context.Game.FindAsync(gameId);
        
        return gameEntity is null ? null : new GameDetailDTO
            {
                Id = gameEntity.Id,
                Name = gameEntity.Name,
                Description = gameEntity.Description
            };
    }

    public async Task<bool> UpdateGameAsync(GameEditDTO request)
    {
        var gameEntity = await _context.Game.FindAsync(request.Id);

        if (gameEntity == null)
            return false;
        else
            gameEntity.Id = request.Id;
            gameEntity.Name = request.Name;
            gameEntity.Description = request.Description;

        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }
    public async Task<bool> DeleteGameAsync(int gameId)
    {
        var gameEntity = await _context.Game.FindAsync(gameId);

        if(gameEntity == null)
            return false;
        _context.Game.Remove(gameEntity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<GameListDTO>> GetAllGamesByDevId(int devId)
    {
        var gameEntity = await _context.Game.Select(entity => new GameListDTO
        {
            Id = entity.Id,
            Name = entity.Name
        }).ToListAsync();

        return gameEntity;
    }
}
