using Domain.Command.Inputs;
using Domain.Interfaces;
using FluentValidation;

namespace Domain.Entities.Validators
{
    public class ClientValidator : AbstractValidator<NewClient>
    {
        private readonly IClientRepository _clientRepository;
        public ClientValidator(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;

            //definição das validações
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Necessário informar o nome")
                 .Length(3, 100).WithMessage("O nome deve ter no mínimo 3 caracteres e no máximo 100");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Necessário informa o e-mail")
                .EmailAddress().WithMessage("E-mail inválido");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Necessário informa um nome de usuário")
                .Length(6, 30).WithMessage("O nome de usuário deve ter no mínimo 3 caracteres e no máximo 30");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Necessário informa um nome de usuário")
                .Length(11).WithMessage("O CPF deve ter 9 caracteres");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Necessário informa a senha")
                .Length(6, 100).WithMessage("A senha deve ter no mínimo 6 caracteres e no máximo 100");
            RuleFor(c => c.UserName).Must(UniqueName).WithMessage("Esse nome de usuário já existe");
        }

        private static bool UsuarioSenhaInvalidos(string userOriginal, string user, string passOriginal, string pass)
        {
            return userOriginal == user && passOriginal == pass;
        }

        private bool UniqueName(string usernaname)
        {
            var uniquename = _clientRepository.GetByUsername(usernaname);

            if (uniquename == null)
                return true;
            return false;
        }

    }
}
