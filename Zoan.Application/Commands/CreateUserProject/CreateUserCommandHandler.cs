using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.Entities;
using Zoan.Core.Services;
using Zoan.Infrastructure.Persistence;

namespace Zoan.Application.Commands.CreateUserProject
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ZoanDbContext _dbContext;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(ZoanDbContext dbContext, IAuthService authService )
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role );

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }

}
