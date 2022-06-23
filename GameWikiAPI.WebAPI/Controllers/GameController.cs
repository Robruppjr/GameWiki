using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
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
        [HttpGet]
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
    }
