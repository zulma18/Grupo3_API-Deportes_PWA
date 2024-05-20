using SportsTeamManagementData.Models;

namespace SportsTeamManagementData.Repositories.Sport_Discipline
{
    public interface ISport_DisciplineRepository
    {
        Task AddSport_DisciplineAsync(SportDiscipline sportDiscipline);
        Task DeleteSport_DisciplineAsync(int id);
        Task EditSport_DisciplineAsync(SportDiscipline sportDiscipline);
        Task<SportDiscipline?> GetSport_DisciplineByIdAsync(int id);
        Task<IEnumerable<SportDiscipline>> GetSport_DisciplineAsync();
    }
}