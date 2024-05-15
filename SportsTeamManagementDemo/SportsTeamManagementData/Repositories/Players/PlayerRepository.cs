using SportsTeamManagementData.Data;
using SportsTeamManagementData.Models;


namespace SportsTeamManagementData.Repositories.Players
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public PlayerRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _dataAccess.GetDataAsync<Player, dynamic>(
                "dbo.spPlayer_GetAll",
                new { }
                );
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            var product = await _dataAccess.GetDataAsync<Player, dynamic>(
                "dbo.spPlayer_GetById",
                new { Id = id }
                );

            return product.FirstOrDefault();
        }

        public async Task AddPlayerAsync(Player player)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spPlayer_Insert",
                new { player.FirstName, player.LastName, player.Age, player.TeamId }
                );
        }

        public async Task EditPlayerAsync(Player player)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spPlayer_Update",
                new { player.Id, player.FirstName, player.LastName, player.Age, player.TeamId }
                );
        }

        public async Task DeletePlayerAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spPlayer_Delete",
                new { Id = id }
                );
        }
    }
}
