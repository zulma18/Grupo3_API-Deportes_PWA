using SportsTeamManagementData.Data;
using SportsTeamManagementData.Models;

namespace SportsTeamManagementData.Repositories.Teams
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public TeamRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<IEnumerable<Team>> GetTeamAsync()
        {
            return await _dataAccess.GetDataAsync<Team, dynamic>(
                "dbo.spTeam_GetAll",
                new { }
                );
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            var team = await _dataAccess.GetDataAsync<Team, dynamic>(
                "dbo.spTeam_GetById",
                new { Id = id }
                );

            return team.FirstOrDefault();
        } 

        public async Task AddTeamAsync(Team team)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spTeam_Insert",
                new { team.TeamName, team.City, team.Coach, team.DisciplineID}
                );
        }

        public async Task EditTeamAsync(Team team)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spTeam_Update",
                 new { team.Id ,team.TeamName, team.City, team.Coach, team.DisciplineID }
                );
        }
        public async Task DeleteTeamAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spTeam_Delete",
                new { Id = id }
                );
        }
    }
}
