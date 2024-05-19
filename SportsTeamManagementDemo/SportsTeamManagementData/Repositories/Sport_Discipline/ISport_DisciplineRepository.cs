using SportsTeamManagementData.Models;

namespace SportsTeamManagementData.Repositories.Sport_Discipline
{
    public interface ISport_DisciplineRepository
    {
        Task AddSport_DisciplineAsync(Sport_DisciplineRepository sport_Discipline);
        Task DeleteSport_DisciplineAsync(int id);
        Task EditSport_DisciplineAsync(Sport_DisciplineRepository sport_Discipline);
        Task<Sport_DisciplineRepository?> GetSport_DisciplineByIdAsync(int id);
        Task<IEnumerable<Sport_DisciplineRepository>> GetSport_DisciplineAsync();
    }
}