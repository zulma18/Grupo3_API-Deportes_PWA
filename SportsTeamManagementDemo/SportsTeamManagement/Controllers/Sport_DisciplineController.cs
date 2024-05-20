using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SportsTeamManagementData.Models;
using SportsTeamManagementData.Repositories.Sport_Discipline;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sport_DisciplineController : ControllerBase
    {
        private readonly ISport_DisciplineRepository _sport_disciplineRepository;
        private readonly IValidator<SportDiscipline> _validator;

        public Sport_DisciplineController(ISport_DisciplineRepository sport_disciplineRepository, IValidator<SportDiscipline> validator)
        {
            _sport_disciplineRepository = sport_disciplineRepository;
            _validator = validator;
        }

        // GET: api/<Sport_DisciplineController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sport_discipline = await _sport_disciplineRepository.GetSport_DisciplineAsync();

            return Ok(sport_discipline);
        }

        // GET api/<Sport_DisciplineController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sport_disciplineById = await _sport_disciplineRepository.GetSport_DisciplineByIdAsync(id);

            if (sport_disciplineById == null)
                return NotFound();

            return Ok(sport_disciplineById);
        }

        // POST api/<Sport_DisciplineController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SportDiscipline sportDiscipline)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(sportDiscipline);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _sport_disciplineRepository.AddSport_DisciplineAsync(sportDiscipline);

            return Created();
        }

        // PUT api/<Sport_DisciplineController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SportDiscipline sportDiscipline)
        {
            var sport_disciplineEditable = await _sport_disciplineRepository.GetSport_DisciplineByIdAsync(id);

            if (sport_disciplineEditable == null)
                return NotFound();

            ValidationResult validationResult = await _validator.ValidateAsync(sportDiscipline);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _sport_disciplineRepository.EditSport_DisciplineAsync(sportDiscipline);

            return Accepted();
        }

        // DELETE api/<Sport_DisciplineController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sport_disciplineRepository.DeleteSport_DisciplineAsync(id);

                return Ok();

            }
            catch (Exception)
            {
                string errorMessage = "No se puede eliminar la disciplina deportiva";

                return StatusCode(500, new { message = errorMessage });
            }
        }
    }
}
