using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class GameService : IGameService
{
    private readonly int _gameId;
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
            //DevId = request.DevId
        };
        await _context.Game.AddAsync(gameEntity);
        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
        }
}
