using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementData.Models
{
    public class Sport_Discipline
        {
           public int Id { get; set; }

           [Required]
           public required string DisciplineName { get; set; }

           [Required]
           public required string Description { get; set; }

    }
}

