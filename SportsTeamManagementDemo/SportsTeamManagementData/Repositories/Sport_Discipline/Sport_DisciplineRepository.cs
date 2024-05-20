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

        public async Task<IEnumerable<SportDiscipline>> GetSport_DisciplineAsync()
        {
            return await _dataAccess.GetDataAsync<SportDiscipline, dynamic>(
                "dbo.spSportDiscipline_GetAll",
                new { }
                );
        }
        public async Task<SportDiscipline?> GetSport_DisciplineByIdAsync(int id)
        {
            var sport_discipline = await _dataAccess.GetDataAsync<SportDiscipline, dynamic>(
                 "dbo.spSportDiscipline_GetById",
                new { Id = id }
                );

            return sport_discipline.FirstOrDefault();
        }

        public async Task AddSport_DisciplineAsync(SportDiscipline sportDiscipline)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSportDiscipline_Insert",
                new { sportDiscipline.DisciplineName, sportDiscipline.Description }
                );
        }
        public async Task EditSport_DisciplineAsync(SportDiscipline sportDiscipline)
        {
            await _dataAccess.SaveDataAsync(
               "dbo.spSportDiscipline_Update",
               new { sportDiscipline.Id, sportDiscipline.DisciplineName, sportDiscipline.Description }
               );
        }

        public async Task DeleteSport_DisciplineAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spSportDiscipline_Delete",
                new { Id = id }
                );
        }

    }
}

