using SportsTeamManagementData.Data;
using SportsTeamManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SportsTeamManagementData.Repositories.Sport_Discipline
{
    public class Sport_DisciplineRepository : ISport_DisciplineRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public Sport_DisciplineRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Sport_DisciplineRepository>> GetSport_DisciplinesAsync()
        {
            return await _dataAccess.GetDataAsync<Sport_DisciplineRepository, dynamic>(
                "dbo.spSport_Discipline_GetAll",
                new { }
                );
        }

        public async Task<Sport_DisciplineRepository?> GetSport_DisciplineByIdAsync(int id)
        {
            var sport_discipline = await _dataAccess.GetDataAsync<Sport_DisciplineRepository, dynamic>(
                "dbo.spSport_Discipline_GetById",
                new { Id = id }
                );

            return sport_discipline.FirstOrDefault();
        }

        public async Task AddSport_DisciplineAsync(Sport_DisciplineRepository sport_Discipline)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSport_Discipline_Insert",
                new { sport_Discipline.DisciplineName, sport_Discipline.Description }
                );
        }

        public async Task EditSport_DisciplineAsync(Sport_DisciplineRepository sport_Discipline)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSport_Discipline_Update",
                new { sport_Discipline.Id, sport_Discipline.DisciplineName, sport_Discipline.Description }
                );
        }

        public async Task DeleteSport_DisciplineAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSport_Discipline_Delete",
                new { Id = id }
                );
        }

        public Task<IEnumerable<Sport_DisciplineRepository>> GetSport_DisciplineAsync()
        {
            throw new NotImplementedException();
        }
    }
}

