using FluentValidation;
using SportsTeamManagementData.Models;

namespace SportsTeamManagementData.Validations
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre es Obligatorio")
                .MinimumLength(2).WithMessage("Debe contener minimo 3 letras")
                .MaximumLength(75).WithMessage("Solo se permite un maximo de 75 caracteres");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("El Apellido es Obligatorio")
                .MinimumLength(2).WithMessage("Debe contener minimo 2 letras")
                .MaximumLength(75).WithMessage("Solo se permite un maximo de 75 caracteres");

            RuleFor(x => x.Age)
                .NotEmpty()
                .WithMessage("La edad es Obligatoria")
                .GreaterThan(6).WithMessage("La edad minima para contratar jugadores es 7 Años");

            RuleFor(x => x.TeamId)
                .NotEmpty()
                .WithMessage("El Equipo es Obligatorio");
        }
    }
}
