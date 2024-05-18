using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementData.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public required string TeamName { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Coach { get; set; }

        [Required]
        public int DisciplineID { get; set; }

        [Required]
        public string? DisciplineName { get; set; }
    }
}
