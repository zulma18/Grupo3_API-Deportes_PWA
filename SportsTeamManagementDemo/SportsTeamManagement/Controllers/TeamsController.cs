using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SportsTeamManagementData.Models;
using SportsTeamManagementData.Repositories.Teams;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IValidator<Team> _validator;

        public TeamsController(ITeamRepository teamRepository, IValidator<Team> validator)
        {
            _teamRepository = teamRepository;
            _validator = validator;
        }

        // GET: api/<TeamsController> List
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _teamRepository.GetTeamAsync();

            return Ok(teams);
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var teamById = await _teamRepository.GetTeamByIdAsync(id); 

            if (teamById== null)
                return NotFound();

            return Ok(teamById);
        }

        // POST api/<TeamsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(team);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _teamRepository.AddTeamAsync(team);

            return Created();

        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, [FromBody] Team team)
        {
            var teamEditable = await _teamRepository.GetTeamByIdAsync(id);  

            if (teamEditable == null)
                return NotFound();

            ValidationResult validationResult = await _validator.ValidateAsync(team);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _teamRepository.EditTeamAsync(team);

            return Accepted();
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _teamRepository.DeleteTeamAsync(id);

                return Ok();

            }
            catch (Exception)
            {
                string errorMessage = "No se puede eliminar el equipo";

                return StatusCode(500, new { message = errorMessage });
            }


            
        }
    }
}
