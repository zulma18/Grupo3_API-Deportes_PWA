using FluentValidation;
using SportsTeamManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementData.Validations
{
    public class Sport_DisciplineValidator : AbstractValidator<SportDiscipline>
    {
        public Sport_DisciplineValidator()
        {
            RuleFor(x => x.DisciplineName)
               .NotEmpty().WithMessage("El Nombre de la Disciplina es Obligatorio")
               .MinimumLength(5).WithMessage("Debe contener minimo 5 letras")
               .MaximumLength(75).WithMessage("Solo se permite un maximo de 75 caracteres");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La Descripcion es Obligatoria")
                .MinimumLength(5).WithMessage("Debe contener minimo 5 letras")
                .MaximumLength(75).WithMessage("Solo se permite un maximo de 75 caracteres");
        }
    }
}
