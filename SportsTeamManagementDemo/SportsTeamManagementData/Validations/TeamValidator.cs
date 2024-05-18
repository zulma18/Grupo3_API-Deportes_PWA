using FluentValidation;
using SportsTeamManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementData.Validations
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.TeamName)
                .NotEmpty().WithMessage("El nombre del equipo es obligatorio ingresarlo")
                .MinimumLength(5).WithMessage("Debe contener minimo 5 letras")
                .MaximumLength(75).WithMessage("Solo se permite un maximo de 75 caracteres");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("El nombre de la ciudad es obligatorio ingresarla")
                .MinimumLength(5).WithMessage("Debe contener minimo 5 letras")
                .MaximumLength(100).WithMessage("Solo se permite un maximo de 100 caracteres")
                .Matches("^[a-zA-Z ]+$").WithMessage("La ciudad solo puede contener letras y espacios.");

            RuleFor(x => x.Coach)
                .NotEmpty().WithMessage("El nombre del entrenador es obligatorio ingresarlo")
                .MinimumLength(5).WithMessage("Debe contener minimo 5 letras")
                .MaximumLength(100).WithMessage("Solo se permite un maximo de 100 caracteres")
                .Matches("^[a-zA-Z ]+$").WithMessage("Solo se permite ingresar letras");

            RuleFor(x => x.DisciplineID)
                .NotEmpty().WithMessage("El Id de la disciplina es obligatorio ingresarlo");

        }
    }
}
