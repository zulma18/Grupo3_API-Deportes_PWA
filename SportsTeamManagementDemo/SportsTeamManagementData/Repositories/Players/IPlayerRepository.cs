using SportsTeamManagementData.Models;

namespace SportsTeamManagementData.Repositories.Players
{
    public interface IPlayerRepository
    {
        Task AddPlayerAsync(Player player);
        Task DeletePlayerAsync(int id);
        Task EditPlayerAsync(Player player);
        Task<Player?> GetPlayerByIdAsync(int id);
        Task<IEnumerable<Player>> GetPlayersAsync();
    }
}