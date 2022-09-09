using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Application.ViewModels;
using Zoan.Core.Repositories;
using Zoan.Core.Services;

namespace Zoan.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {

        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // utilizar o mesmo algoritmo para criar o hash dessa senha

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            // buscar no meu banco de dados em user que tenha meu e-mail e minha senha em formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            //se não existir , erro no login
            if(user == null)
            {
                return null;
            }

            // se existir, gero o token usando os dados do usuario

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
