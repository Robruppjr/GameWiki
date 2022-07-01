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


        [HttpPut("Update Character")]
        public async Task<IActionResult> UpdateCharacterById([FromBody] CharacterEditDTO request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _characterService.UpdateCharacterAsync(request)
                ? Ok("Character was updated successfuly.")
                : BadRequest("Character could not be updated.");
        }

        [HttpDelete]
        [Route("{characterId}")]
        public async Task<IActionResult> DeleteCharacter([FromRoute] int characterId)
        {
            return await _characterService.DeleteCharacterAsync(characterId)
                ? Ok($"Character {characterId} was deleted successfully.")
                : BadRequest($"{characterId} could not be deleted.");
        }


    }