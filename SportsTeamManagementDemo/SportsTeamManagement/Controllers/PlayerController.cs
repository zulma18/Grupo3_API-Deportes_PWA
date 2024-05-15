using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SportsTeamManagementData.Models;
using SportsTeamManagementData.Repositories.Players;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IValidator<Player> _validator;

        public PlayerController(IPlayerRepository playerRepository, IValidator<Player> validator)
        {
            _playerRepository = playerRepository;
            _validator = validator;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var players = await _playerRepository.GetPlayersAsync();

            return Ok(players);
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var playerById = await _playerRepository.GetPlayerByIdAsync(id);

            if (playerById == null)
                return NotFound();

            return Ok(playerById);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(player);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _playerRepository.AddPlayerAsync(player);

            return Created();
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Player player)
        {
            var playerEditable = await _playerRepository.GetPlayerByIdAsync(id);

            if (playerEditable == null)
                return NotFound();

            ValidationResult validationResult = await _validator.ValidateAsync(player);

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _playerRepository.EditPlayerAsync(player);

            return Accepted();
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _playerRepository.DeletePlayerAsync(id);

            return Ok();
        }
    }
}
