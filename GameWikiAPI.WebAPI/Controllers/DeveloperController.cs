using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {

        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateDeveloper([FromBody] DeveloperCreate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _developerService.CreateDeveloperAsync(request))
            {
                return Ok("Developer was created.");
            }

            return BadRequest("Developer could not be created.");
        }

        [HttpGet]
        [Route("{developerId}")]
        public async Task<IActionResult> GetDeveloperById([FromRoute] int developerId)
        {
            var developerDetail = await _developerService.GetDeveloperByIdASync(developerId);

            if(developerDetail is null)
                {
                    return NotFound();
                }
            
            return Ok(developerDetail);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeveloperById([FromBody] DeveloperEdit request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                return await _developerService.UpdateDeveloperAsync(request) 
                ? Ok("Developer was updated.") : BadRequest("Developer could not be updated.");
        }

        [HttpDelete]
        [Route("{developerId}")]
        public async Task<IActionResult> DeleteDeveloper([FromRoute] int developerId)
        {
            return await  _developerService.DeleteDeveloperAsync(developerId) 
            ? Ok($"Developer {developerId} was deleted.") : BadRequest($"Developer {developerId} could not be deleted");
        }

    }
