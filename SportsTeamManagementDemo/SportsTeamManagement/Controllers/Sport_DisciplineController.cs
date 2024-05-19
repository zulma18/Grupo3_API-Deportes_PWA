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
        private readonly IValidator<Sport_DisciplineController> _validator;

        public Sport_DisciplineController(ISport_DisciplineRepository sport_disciplineRepository, IValidator<Sport_DisciplineController> validator)
        {
            _sport_disciplineRepository = sport_disciplineRepository;
            _validator = validator;
        }

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
        // GET: api/<Sport_DisciplineController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sport_DisciplineController sport_Discipline)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(sport_Discipline);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _sport_disciplineRepository.AddSport_DisciplineAsync(sport_Discipline);

            return Created();
        }

        // PUT api/<Sport_DisciplineController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sport_DisciplineController sport_Discipline)
        {
            var sport_disciplineEditable = await _sport_disciplineRepository.GetSport_DisciplineByIdAsync(id);

            if (sport_disciplineEditable == null)
                return NotFound();

            ValidationResult validationResult = await _validator.ValidateAsync(sport_Discipline);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _sport_disciplineRepository.EditSport_DisciplineAsync(sport_Discipline);

            return Accepted();
        }

        // DELETE api/<Sport_DisciplineController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sport_disciplineRepository.DeleteSport_DisciplineAsync(id);

            return Ok();
        }
    }
}
