using SportsTeamManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementData.Repositories.Teams
{
    public interface ITeamRepository
    {
        Task AddTeamAsync(Team team);
        Task DeleteTeamAsync(int id);
        Task EditTeamAsync(Team team);
        Task<Team?> GetTeamByIdAsync(int id);
        Task<IEnumerable<Team>> GetTeamAsync();

    }
}
