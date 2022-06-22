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
    }
