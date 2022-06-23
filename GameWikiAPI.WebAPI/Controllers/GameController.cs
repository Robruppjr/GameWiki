using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameWikiAPI.Models.Model.Game;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpPost("Create Game")]
        public async Task<IActionResult> CreateGame([FromBody] GameCreate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gameCreateResult = await _gameService.CreateGameAsync(request);
            if(gameCreateResult)
            {
                return Ok("Game has been added to GameWIKI");
            }

            return BadRequest("Failed to add Game to the GameWIKI");
        }
        [HttpGet("Get all Games")]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }
        // Get api/Game/gameId
        [HttpGet("{gameId:int}")]
        public async Task<IActionResult> GetGameById([FromRoute] int gameId)
        {
                var detail = await _gameService.GetGameByIdAsync(gameId);
                return detail is not null
                    ? Ok(detail)
                    : NotFound();
        }
        [HttpPut("Update a Game")]
        public async Task<IActionResult> UpdateGameById([FromBody] GameEditDTO request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _gameService.UpdateGameAsync(request)
                    ? Ok("Game was updated successfully.")
                    : BadRequest("Game could not be updated.");
        }
        [HttpDelete]
        [Route("{gameId}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int gameId)
        {
            return await _gameService.DeleteGameAsync(gameId)
                ? Ok($"Game {gameId} was deleted succesfully.")
                : BadRequest($"{gameId} could not be deleted.");
        }
    }
