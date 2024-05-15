using System.ComponentModel.DataAnnotations;

namespace SportsTeamManagementData.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int TeamId { get; set; }

        public string ?TeamName { get; set; }
    }
}
