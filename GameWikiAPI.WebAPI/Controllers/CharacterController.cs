using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly ILogger<CharacterController> _logger;
        
        public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService)
        {
            _logger = logger;
            _characterService = characterService;
        }

        [HttpPost("Add Character")]
        public async Task<IActionResult> CreateCharacter([FromBody] CharacterCreateDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createResult = await _characterService.CreateCharacterAsync(request);
            if (createResult)
            {
                return Ok("Character added");
            }

            return BadRequest("Character could not be added");
        }

        [HttpGet("{characterId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int characterId)
        {
            var characterDetail = await _characterService.GetCharacterByIdASync(characterId);

            if(characterDetail is null)
                {
                    return NotFound();
                }
            
            return Ok(characterDetail);
        }

        [HttpGet("{characterGameId:int}")]
        public async Task<IActionResult> GetByGameId([FromRoute] int characterGameId)
        {
            var characterDetail = await _characterService.GetCharacterByGameIdASync(characterGameId);

            if(characterDetail is null)
                {
                    return NotFound();
                }
            
            return Ok(characterDetail);
        }


    }